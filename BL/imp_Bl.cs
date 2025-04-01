using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DS;

namespace BL
{
    public class imp_Bl : IBL
    {
        IDAL d = FactoryDAL.GetDAL();
        #region CRUD
        public void _AddGuestRequest(GuestRequest g)
        {
            // if (g.LengthOfVacation() != 0)
            if (g.EntryDate < g.ReleaseDate)
            {
                try
                {
                    d.AddGuestRequest(g);
                }
                catch (Exception s)
                {
                    throw s;
                }
            }
            else
            {
                throw new ArgumentException("פחות מיום בין תאריך ההתחלה והסיום...");
            }
        }

        public void _UpDateGuestRequest(GuestRequest g)
        {
            if (g.EntryDate < g.ReleaseDate)
            {
                try
                {
                    d.UpDateGuestRequest(g);
                }
                catch (Exception s)
                {
                    throw s;
                }
            }
            else
            {
                throw new ArgumentException("פחות מיום בין תאריך ההתחלה והסיום...");
            }
        }

        public void _UpDateHostingUnit(HostingUnit h)
        {
            HostingUnit hh = d.HostingUnitsList().Find(x => x.HostingUnitKey == h.HostingUnitKey);
            if (hh.Owner.CollectionClearance && !h.Owner.CollectionClearance)
            {
                var tempList = from item in d.OrdersList()
                               where item.HostingUnitKey == h.HostingUnitKey
                               select new
                               { status = item.Status };
                var temp = tempList.FirstOrDefault(x => (x.status.Equals(Enums.orderStatus.נשלח_מייל) || x.status.Equals(Enums.orderStatus.נסגר_מהיענות)));
                if (temp != null)
                    throw new ArgumentException("ישנן הזמנות פתוחות");
                else
                {
                    try
                    {
                        d.UpDateHostingUnit(h);
                    }
                    catch (Exception s)
                    {
                        throw s;
                    }
                }
            }
            else
            {
                try
                {
                    d.UpDateHostingUnit(h);
                }
                catch (Exception s)
                {
                    throw s;
                }
            }
        }

        public void _AddHostingUnit(HostingUnit h)
        {
            try
            {
                d.AddHostingUnit(h);
            }
            catch (Exception s)
            {
                throw s;
            }
        }

        public void _DeleteHostingUnit(HostingUnit h)
        {
            var tempList = from item in d.OrdersList()
                           where item.HostingUnitKey == h.HostingUnitKey
                           select new
                           { status = item.Status };
            var temp = tempList.FirstOrDefault(x => (x.status.Equals(Enums.orderStatus.נשלח_מייל) || x.status.Equals(Enums.orderStatus.נסגר_מהיענות)));
            if (temp == null)
            {
                d.DeleteHostingUnit(h);
            }
            else
                throw new KeyNotFoundException("קיימת הזמנה פתוחה בקשר ליחידת האירוח");
        }

        public void _AddOrder(Order o)
        {
            if (d.HostingUnitsList().FindIndex(t => t.HostingUnitKey == o.HostingUnitKey) == -1)
                throw new KeyNotFoundException("there is no such hosting unit to this order");
            if (d.GuestRequestsList().FindIndex(t => t.GuestRequestKey == o.GuestRequestKey) == -1)
                throw new KeyNotFoundException("there is no such guest request to this order");
            if (isNotTaken(o) == true)
            {
                try
                {
                    d.AddOrder(o);
                }
                catch (Exception s)
                {
                    throw s;
                }
            }
            else
            {
                throw new ArgumentException("התאריכים תפוסים");
            }
        }

        public void _UpDateOrder(Order o)
        {
            if (orderIsClosed(o))
                throw new ArgumentException("ההזמנה כבר אושרה/עבר תוקפה");
            if (isNotTaken(o))
            {
                if (o.Status.Equals(Enums.orderStatus.נשלח_מייל))
                {
                    if (!checkCollectionClearance(o))
                        throw new ArgumentException("!אין אישור גבייה");
                    o.OrderDate = DateTime.Now;
                    Console.WriteLine("שולח מייל");
                }
                if (o.Status.Equals(Enums.orderStatus.נסגר_מהיענות))
                {
                    approveOrder(o);
                    o.commission = Commission(o);
                }
                if (howLong(o.CreateDate) >= Configuration.expireRequestDays)
                    o.Status = Enums.orderStatus.לא_בתוקף;
                try
                {
                    d.UpDateOrder(o);
                }
                catch (Exception s)
                {
                    throw s;
                }
            }
            else
                throw new ArgumentException("התאריכים תפוסים");
        }
        #endregion
        #region lists
        public List<HostingUnit> _HostingUnitsList()
        {
            var item = d.HostingUnitsList();
            return item;
        }
        public List<GuestRequest> _GuestRequestsList()
        {
            var item = d.GuestRequestsList();
            return item;
        }
        public List<Order> _OrdersList()
        {
            var item = d.OrdersList();
            return item;
        }
        public List<BankBranch> _BankBranchesList()
        {
            var item = d.BankBranchesList();
            return item;
        }
        public List<HostingUnit> _EmptyHostingUnits(DateTime date, int numDays)
        {
            TimeSpan t = new TimeSpan(1);
            List<HostingUnit> hList = new List<HostingUnit>();
            foreach (var item in d.HostingUnitsList())
            {
                bool flag = false;
                DateTime d = new DateTime();
                d = date;
                for (int i = 0; i < numDays; i++)
                {
                    if (item.Diary[d.Month, d.Day])
                    {
                        flag = true;
                        i = numDays;
                    }
                    d += t;

                }
                if (flag)
                {
                    hList.Add(item);
                }
            }
            return hList;

        }
        public List<Order> _OrdersBefore(int num)
        {
            DateTime t = new DateTime();
            t = DateTime.Today;
            List<Order> oList = new List<Order>();
            foreach (var item in d.OrdersList())
            {
                if (item.Status.Equals(Enums.orderStatus.נשלח_מייל))
                {
                    if ((_DaysGap(item.OrderDate, t)) <= num)
                    {
                        oList.Add(item);
                    }
                }
                else
                {
                    if ((_DaysGap(item.CreateDate, t)) <= num)
                    {
                        oList.Add(item);
                    }
                }

            }
            return oList;
        }
        public List<GuestRequest> _SomeGuestRequests(Predicate<GuestRequest> predicate)
        {
            List<GuestRequest> gList = d.GuestRequestsList().FindAll(predicate);
            return gList;
        }

        #endregion
        #region extra functions

        public int _DaysGap(DateTime date)
        {
            TimeSpan t = new TimeSpan(1);
            DateTime d = new DateTime();
            d = DateTime.Today;
            int counter = 0;
            int result = -1;
            while (result <= 0)
            {
                result = DateTime.Compare(date,d);
                counter++;
                date += t;
            }
            return counter;
        }

        public int _DaysGap(DateTime date1, DateTime date2)
        {
            TimeSpan t = new TimeSpan(1);
            int counter = 0;
            int result = -1;
            while (result<=0)
            {
                result = DateTime.Compare(date1, date2);
                counter++;
                date1 += t;
            }
            return counter;


        }

        public int _NumOfOrders(GuestRequest gr)
        {
            int counter = 0;
            foreach (var item in d.OrdersList())
            {
                if (item.GuestRequestKey == gr.GuestRequestKey)
                    counter++;
            }
            return counter;
        }

        public int _DoneOredrs(GuestRequest gr)
        {
            int counter = 0;
            var grKey = gr.GuestRequestKey;
            foreach (var item in d.OrdersList())
            {
                if ((item.GuestRequestKey == grKey) && ((item.Status.Equals(Enums.orderStatus.נשלח_מייל)) || (item.Status.Equals(Enums.orderStatus.נסגר_מהיענות))))
                {
                    counter++;
                }
            }
            return counter;
        }

        public List<GuestRequest> grListBy(string _SubArea)//return guestsrequests in this sub area which require jacuzzi and a pool is not neccesary
        {
            List<GuestRequest> gList = new List<GuestRequest>();
            foreach (var item in d.GuestRequestsList())
            {
                if ((item.SubArea == _SubArea) && !(item.Jacuzzi.Equals(Enums.Jacuzzi.נחוץ)) && !(item.Pool.Equals(Enums.Pool.נחוץ)))
                {
                    gList.Add(item);
                }
            }
            return gList;
        }

        public List<Order> oListBy(string _hostKey)//return orders of the host
        {
            List<HostingUnit> hList = new List<HostingUnit>();
            hList = hostsList(_hostKey);
            List<Order> oList = new List<Order>();
            foreach (var item in d.OrdersList())
            {
                foreach (var Item in hList)
                {
                    if ((item.HostingUnitKey == Item.HostingUnitKey))
                    {
                        oList.Add(item);
                    }
                }
            }
            return oList;
        }

        public List<HostingUnit> hostsList(string HostKey)//return all the hosting units that belong to this host
        {
            List<HostingUnit> hList = new List<HostingUnit>();
            foreach (var item in d.HostingUnitsList())
            {
                if (item.Owner.HostKey == HostKey)
                {
                    hList.Add(item);
                }
            }
            return hList;
        }

        public List<HostingUnit> _hostsList(string Area) //return all hosting units which are in this area
        {
            List<HostingUnit> hList = new List<HostingUnit>();
            foreach (var item in d.HostingUnitsList())
            {
                if (Area.Equals(item.area))
                {
                    hList.Add(item);
                }
            }
            return hList;
        }

        public List<GuestRequest> guestsList(string mail)//return guest requests by mail 
        {
            List<GuestRequest> gList = new List<GuestRequest>();
            foreach (var item in d.GuestRequestsList())
            {
                if (item.MailAddress == mail)
                {
                    gList.Add(item);
                }
            }
            return gList;
        }


        public string popularArea()//return the most popular area,which area 'has' the most guest requests
        {
            int countNorth = 0;
            int countCenter = 0;
            int countSouth = 0;
            int countJerusalem = 0;
            foreach (var item in d.GuestRequestsList())
            {
                switch (item.Area)
                {
                    case Enums.Area.מרכז:
                        countCenter++;
                        break;
                    case Enums.Area.ירושלים:
                        countJerusalem++;
                        break;
                    case Enums.Area.צפון:
                        countNorth++;
                        break;
                    case Enums.Area.דרום:
                        countSouth++;
                        break;
                    default:
                        break;
                }
            }
            if (countCenter >= countSouth && countCenter >= countJerusalem && countCenter >= countNorth)
                return "מרכז";
            if (countNorth >= countJerusalem && countNorth >= countSouth && countNorth >= countCenter)
                return "צפון";
            if (countJerusalem >= countCenter && countJerusalem >= countNorth && countJerusalem >= countSouth)
                return "ירושלים";
            return "דרום";
        }

        public uint TotalPrice(Order order)//return the total price for the guest
        {
            HostingUnit h = d.HostingUnitsList().Find(x => x.HostingUnitKey == order.HostingUnitKey);
            GuestRequest g = d.GuestRequestsList().Find(x => x.GuestRequestKey == order.GuestRequestKey);
            uint childPrice = h.PriceForChild;
            uint adultPrice = h.PriceForAdult;
            uint length = (uint)g.LengthOfVacation();
            uint numOfChildren = g.Children;
            uint numOfAdults = g.Adults;
            return (numOfChildren * childPrice + numOfAdults * adultPrice) * length;
        }

        public string popularHost()//return the host who has the most "closed through the site" orders
        {
            uint max = 0;
            Host maxHost = new Host();

            var hkList = from item in d.OrdersList()
                         where item.Status.Equals(Enums.orderStatus.נסגר_מהיענות)
                         select new
                         {
                             item.HostingUnitKey
                         };
            List<HostingUnit> hostingUnits = new List<HostingUnit>();
            foreach (var item in hkList)
            {
                foreach (var temp in d.HostingUnitsList())
                {
                    if (item.HostingUnitKey == temp.HostingUnitKey)
                        hostingUnits.Add(temp);
                }
            }
            List<Host> hosts = new List<Host>();
            foreach (var item in hostingUnits)
            {
                foreach (var temp in DataSource.GetHosts())
                {
                    if (item.Owner.HostKey == temp.HostKey)
                        hosts.Add(temp);
                }
            }
            List<Host> hList = new List<Host>(DataSource.GetHosts());
            foreach (var item in hList)
            {
                uint counter = 0;
                foreach (var temp in hosts)
                {
                    if (temp.HostKey == item.HostKey)
                        counter++;
                }
                if (counter > max)
                {
                    max = counter;
                    maxHost = item;
                }
            }
            string s = maxHost.PrivateName + " " + maxHost.FamilyName + " " + maxHost.HostKey;
            return s;
        }

        public uint sumHostingUnits(Host host)//return how many hosting units does the host has
        {
            return (uint)d.HostingUnitsList().LongCount(item => item.Owner == host);
        }

        public bool checkCollectionClearance(Order o)// This function checks if the owner of a given hosting unit has a collection clearance
        {
            var v = d.HostingUnitsList().Where(t => t.HostingUnitKey == o.HostingUnitKey);
            if (v.FirstOrDefault().Owner.CollectionClearance)
                return true;
            return false;
        }

        public int howLong(DateTime date1)// This function calculates how much time has passed from a certain date till today 

        {
            DateTime d = DateTime.Now;
            return howLong(date1, d);
        }

        public int howLong(DateTime date1, DateTime date2)// This function calculates how much time has passed between two dates
        {
            int counter = 0;
            int result=-1;
            while (result <= 0)
            {
                result = DateTime.Compare(date1, date2);
                counter++;
                date1 = date1.AddDays(1);
            }
            return counter;
        }

        public HostingUnit HostingUnitByName(string hostName)//return an hosting unit search it by its name
        {
            HostingUnit h = new HostingUnit();
            foreach (var item in d.HostingUnitsList())
            {
                if (item.HostingUnitName == hostName)
                {
                    return item;
                }
            }
            return h;
        }

        private bool orderIsClosed(Order o)// This function checks if an order has been closed
        {
            var v = d.OrdersList().Where(item => item.OrderKey == o.OrderKey);
            if (v.First().Status.Equals(Enums.orderStatus.נסגרה_מחוסר_היענות) || v.First().Status.Equals(Enums.orderStatus.נסגר_מהיענות) || v.First().Status.Equals(Enums.orderStatus.לא_בתוקף))
                return true;
            return false;
        }

        private bool isNotTaken(Order o)//This function checks if certain dates have not been taken yet
        {
            var v1 = d.HostingUnitsList().Where(t => t.HostingUnitKey == o.HostingUnitKey).ToList();
            //var v1 = (from tmp in d.HostingUnitsList()
            //         where tmp.HostingUnitKey == o.HostingUnitKey
            //         select new {diary = tmp.Diary }).ToList();
            //if (v1[0].diary[0,0]==false)
            //    throw new Exception("the error is here");

            //var tm = v1[0];
            var v2 = d.GuestRequestsList().Where(t => t.GuestRequestKey == o.GuestRequestKey);
            DateTime d1 = v2.FirstOrDefault().EntryDate;
            DateTime d2 = v2.FirstOrDefault().ReleaseDate;

            int result = -1;
            while (result<=0)
            {
                result = DateTime.Compare(d1, d2);
                if (v1[0].Diary[d1.Day, d1.Month] == true) //catched
                    return false;
                d1 = d1.AddDays(1);
            }
            return true;
        }

        private void approveOrder(Order o)
        {
            if (isNotTaken(o))
            {
                var v1 = d.HostingUnitsList().Where(item => item.HostingUnitKey == o.HostingUnitKey);
                var v2 = d.GuestRequestsList().Where(item => item.GuestRequestKey == o.GuestRequestKey);
                var v3 = d.OrdersList().Where(item => item.OrderKey == o.OrderKey);
                DateTime day = v2.First().EntryDate;
                while (day <= v2.First().ReleaseDate)
                {
                    v1.First().Diary[day.Day, day.Month] = true;
                    day = day.AddDays(1);
                }
                v3.First().Status = Enums.orderStatus.אושרה;
                foreach (var item in d.OrdersList())
                {
                    if (item.GuestRequestKey == o.GuestRequestKey && item.OrderKey != o.OrderKey)
                        item.Status = Enums.orderStatus.לא_נענתה;
                }
            }
        }

        private uint Commission(Order o)
        {
            var v = d.GuestRequestsList().Where(item => item.GuestRequestKey == o.GuestRequestKey);
            DateTime day = v.FirstOrDefault().EntryDate;
            uint sum = 0;
            while (day <= v.FirstOrDefault().ReleaseDate)
            {
                sum += Configuration.GetCommission();
                day = day.AddDays(1);
            }
            return sum;
        }


        public string enumTrans(string e)
        {
            string translation = "";
            if (e.Equals("zimmer"))
                translation = "צימר";
            else if (e.Equals("tent"))
                translation = "מחנאות";
            else if (e.Equals("hotelRoom"))
                translation = "חדר_מלון";
            else if (e.Equals("apartment"))
                translation = "דירה";
            else if (e.Equals("Center"))
                translation = "מרכז";
            else if (e.Equals("Jerusalem"))
                translation = "ירושלים";
            else if (e.Equals("North"))
                translation = "צפון";
            else if (e.Equals("South"))
                translation = "דרום";
            else if (e.Equals("NotAddressed"))
                translation = "לא_טופלה";
            else if (e.Equals("sentEmail"))
                translation = "נשלח_מייל";
            else if (e.Equals("aproved"))
                translation = "אושרה";
            else if (e.Equals("unanswered"))
                translation = "לא_נענתה";
            else if (e.Equals("expired"))
                translation = "לא_בתוקף";
            else if (e.Equals("closedForCustomerUnresponsiveness"))
                translation = "נסגרה_מחוסר_הענות";
            else if (e.Equals("closedForCustomerResponse"))
                translation = "נסגרה_מהענות";
            else if (e.Equals("Active"))
                translation = "פעילה";
            else if (e.Equals("closedBecauseItExpired"))
                translation = "פגת_תוקף";
            else if (e.Equals("closedThroughTheSite"))
                translation = "נסגרה_דרך_האתר";
            else if (e.Equals("Necessary"))
                translation = "נחוץ";
            else if (e.Equals("optional"))
                translation = "אפשרי";
            else if (e.Equals("uninterested"))
                translation = "לא_רצוי";
            return translation;

        }

        #endregion
        #region groups
        public IEnumerable<IGrouping<Enums.Area, GuestRequest>> ByArea()
        {
            IEnumerable<IGrouping<Enums.Area, GuestRequest>> result = from n in d.GuestRequestsList()
                                                                      group n by n.Area into gs
                                                                      select gs;
            return result;
        }
        public IEnumerable<IGrouping<uint, GuestRequest>> ByNumOfGuests()
        {
            var result = from item in d.GuestRequestsList()
                         group item by item.Adults + item.Children
                         into gr
                         select gr;
            return result;
        }

        public IEnumerable<IGrouping<Enums.Area, HostingUnit>> ByAnArea()
        {
            IEnumerable<IGrouping<Enums.Area, HostingUnit>> result = from n in d.HostingUnitsList()
                                                                     group n by n.area into gs
                                                                     select gs;
            return result;
        }
        //request:
        public IEnumerable<IGrouping<Enums.Area, GuestRequest>> requestByArea(Enums.Area Area)
        {
            var rgList = from n in d.GuestRequestsList()
                         group n by n.Area into hu
                         orderby hu.Key
                         select hu;
            var res = (from n in rgList
                       where n.Key == Area
                       select n).ToList();
            return res;

        }
        public IEnumerable<IGrouping<DateTime, GuestRequest>> requestByEntryDate()
        {
            var rgList = from n in d.GuestRequestsList()
                         group n by n.EntryDate into hu
                         orderby hu.Key
                         select hu;
            var res = (from n in rgList
                       where n.Key != null
                       select n).ToList();
            return res;
        }
        public IEnumerable<IGrouping<uint, GuestRequest>> requestByAdults()
        {
            var rgList = from n in d.GuestRequestsList()
                         group n by n.Adults into hu
                         orderby hu.Key
                         select hu;

            var res = (from n in rgList
                       where n.Key == 2
                       select n).ToList();
            return res;
        }
        public IEnumerable<IGrouping<uint, GuestRequest>> requestByChildren()
        {
            var rgList = from n in d.GuestRequestsList()
                         group n by n.Children into hu
                         orderby hu.Key
                         select hu;
            var res = (from n in rgList
                       where n.Key >= 5
                       select n).ToList();
            return res;
        }
        public IEnumerable<IGrouping<string, GuestRequest>> requestByPrivateName()
        {
            var rgList = from n in d.GuestRequestsList()
                         group n by n.PrivateName into hu
                         orderby hu.Key
                         select hu;
            var res = (from n in rgList
                       where n.Key != null
                       select n).ToList();
            return res;
        }
        public IEnumerable<IGrouping<int, GuestRequest>> requestByLengthOfVacation()
        {
            var rgList = from n in d.GuestRequestsList()
                         group n by n.LengthOfVacation() into hu
                         orderby hu.Key
                         select hu;
            var res = (from n in rgList
                       where n.Key > 7
                       select n).ToList();
            return res;
        }
        public IEnumerable<IGrouping<string, GuestRequest>> requestByFamilyName()
        {
            var rgList = from n in d.GuestRequestsList()
                         group n by n.FamilyName into hu
                         orderby hu.Key
                         select hu;
            var res = (from n in rgList
                       where n.Key != null
                       select n).ToList();
            return res;
        }
        //orders:
        public IEnumerable<IGrouping<uint, Order>> ordersByCommision()
        {
            var oList = from n in d.OrdersList()
                        group n by n.commission into hu
                        orderby hu.Key
                        select hu;
            var res = (from n in oList
                       where n.Key != null
                       select n).ToList();
            return res;
        }
        public IEnumerable<IGrouping<DateTime, Order>> ordersByCreatDate()
        {
            var oList = from n in d.OrdersList()
                        group n by n.CreateDate into hu
                        orderby hu.Key
                        select hu;
            var res = (from n in oList
                       where n.Key != null
                       select n).ToList();
            return res;
        }
        public IEnumerable<IGrouping<long, Order>> ordersByHostingUnitKey()
        {
            var oList = from n in d.OrdersList()
                        group n by n.HostingUnitKey into hu
                        orderby hu.Key
                        select hu;
            var res = (from n in oList
                       where n.Key != null
                       select n).ToList();
            return res;
        }
        public IEnumerable<IGrouping<long, Order>> ordersByOrderKey()
        {
            var oList = from n in d.OrdersList()
                        group n by n.OrderKey into hu
                        orderby hu.Key
                        select hu;
            var res = (from n in oList
                       where n.Key != null
                       select n).ToList();
            return res;
        }
        //hosts:

        public IEnumerable<IGrouping<uint, Host>> hostsByNumOfHostingUnits()
        {
            var hList = from n in d.HostingUnitsList()
                        group n.Owner by sumHostingUnits(n.Owner) into hu
                        select hu;
            IEnumerable<IGrouping<uint, Host>> distinctValues = hList.Distinct();
            return distinctValues;
        }
        public IEnumerable<IGrouping<string, Host>> hostsByPrivateName()
        {
            var hList = from n in d.HostingUnitsList()
                        group n.Owner by (n.Owner).PrivateName into hu
                        orderby hu.Key
                        select hu;
            IEnumerable<IGrouping<string, Host>> distinctValues = hList.Distinct();
            return distinctValues;
        }


        public IEnumerable<IGrouping<string, Host>> hostsByFamilyeName()
        {
            var hList = from n in d.HostingUnitsList()
                        group n.Owner by (n.Owner).FamilyName into hu
                        orderby hu.Key
                        select hu;
            IEnumerable<IGrouping<string, Host>> distinctValues = hList.Distinct();
            return distinctValues;
        }

        public IEnumerable<IGrouping<long, Host>> hostsByPhoneNumber()
        {
            var hList = from n in d.HostingUnitsList()
                        group n.Owner by (n.Owner).PhoneNumber into hu
                        orderby hu.Key
                        select hu;
            IEnumerable<IGrouping<long, Host>> distinctValues = hList.Distinct();
            return distinctValues;
        }

        public IEnumerable<IGrouping<string, Host>> hostsByID()
        {
            var hList = from n in d.HostingUnitsList()
                        group n.Owner by (n.Owner).HostKey into hu
                        orderby hu.Key
                        select hu;
            IEnumerable<IGrouping<string, Host>> distinctValues = hList.Distinct();
            return distinctValues;
        }
    }





}
#endregion