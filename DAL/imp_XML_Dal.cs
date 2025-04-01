using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using BE;
using System.Threading;
using System.Xml.Serialization;
using System.Net;
using System.Reflection;

namespace DAL
{
    public class Dal_XML_imp : IDAL
    {
        private XElement ConfigRoot;
        private XElement HostingUnitsRoot;
        private XElement OrderRoot;
        private XElement GuestRequestRoot;

        private const string BanksRootPath = @"atm.xml";
        private const string ConfigRootPath = @"configuration.xml";
        private const string HostingUnitsRootPath = @"hostingUnits.xml";
        private const string OrderRootPath = @"order.xml";
        private const string GuestRequestRootPath = @"gr.xml";

        private static void DownloadBanks()
        {
            WebClient wc = new WebClient();
            try
            {
                bool i = true;
                while (i)
                {
                    try
                    {
                        string xmlServerPath = @"http//www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                        wc.DownloadFile(xmlServerPath, BanksRootPath);
                        i = false;
                    }
                    catch
                    {
                        Thread.Sleep(200);
                    }

                }
            }
            finally
            {
                wc.Dispose();
            }
        }

        public Dal_XML_imp()
        {
            try
            {
                Thread t1 = new Thread(DownloadBanks);
                t1.Start();
            }
            catch
            {
                throw;
            }
            //if (!File.Exists(HostingUnitsRootPath))
            //{
            //    //HostingUnitsRoot = new XElement("hosting units");
            //    //HostingUnitsRoot.Save(HostingUnitsRootPath);
            //    FileStream f = new FileStream(HostingUnitsRootPath, FileMode.Create);
            //    f.Close();
            //}
            try
            {
                if (!File.Exists(HostingUnitsRootPath))
                {
                    FileStream fileHostingUnit = new FileStream(HostingUnitsRootPath, FileMode.Create);

                    fileHostingUnit.Close();
                }
            }
            catch
            {
                // filesWithWrongStruct += "HostingUnits.xml\n";
                HostingUnitsRoot = new XElement("HostingUnits");
            }
            if (!File.Exists(OrderRootPath))
            {
                OrderRoot = new XElement("orders");
                OrderRoot.Save(OrderRootPath);
            }
            else
            {
                try { OrderRoot = XElement.Load(OrderRootPath); }
                catch { throw new KeyNotFoundException("בעיה בטעינת קובץ"); }
            }
            if (!File.Exists(ConfigRootPath))
            {
                ConfigRoot = new XElement("Config");
                ConfigRoot.Add(new XElement("guestRequestKey", 10000000));
                ConfigRoot.Add(new XElement("hostingUnitKey", 10000000));
                ConfigRoot.Add(new XElement("orderKey", 10000000));
                ConfigRoot.Add(new XElement("managerPassword", 12345));
                ConfigRoot.Add(new XElement("commission", 10));
                ConfigRoot.Add(new XElement("expireRequestDays", 500));
                ConfigRoot.Save(ConfigRootPath);
            }
            else
            {
                try { ConfigRoot = XElement.Load(ConfigRootPath); }
                catch { throw new KeyNotFoundException("File upload problem"); }
            }
            if (!File.Exists(GuestRequestRootPath))
            {
                FileStream f = new FileStream(GuestRequestRootPath, FileMode.Create);
                f.Close();
            }
        }

        #region CRUD
        //Add
        public void AddGuestRequest(GuestRequest gr)
        {
            //try
            //{
            //    Load(ref GuestRequestRoot, GuestRequestRootPath);
            //}
            //catch (DirectoryNotFoundException r)
            //{
            //    throw r;
            //}
            //var it = (from item in GuestRequestRoot.Elements()
            //          where item.Element("MailAddress").Value == gr.MailAddress &&
            //                Convert.ToDateTime(item.Element("EntryDate").Value) == gr.EntryDate &&
            //                Convert.ToDateTime(item.Element("ReleaseDate").Value) == gr.ReleaseDate
            //          select item).FirstOrDefault();
            //if (it != null)
            //    throw new Exception("הבקשה כבר קיימת במאגר");
            //gr.GuestRequestKey = GetRunningNumForGR();
            //GuestRequestRoot.Add(GRCreatorToXML(gr));
            //GuestRequestRoot.Save(GuestRequestRootPath);
            List<GuestRequest> lst = loadListFromXML<GuestRequest>(GuestRequestRootPath);
            if (lst.Exists(item => item.GuestRequestKey == gr.GuestRequestKey) == true)
                throw new ArgumentException("This request already exists");
            else
            {

                int config = Convert.ToInt32(ConfigRoot.Element("guestRequestKey").Value);
                config++;
                ConfigRoot.Element("guestRequestKey").Value = Convert.ToString(config);
                ConfigRoot.Save(ConfigRootPath);
                lst.Add(gr.Clone());
            }
            saveListToXML<GuestRequest>(lst, GuestRequestRootPath);
        }

        public void AddHostingUnit(HostingUnit hu)
        {
            List<HostingUnit> lst = loadListFromXML<HostingUnit>(HostingUnitsRootPath);
            if (lst.Exists(item => item.HostingUnitKey == hu.HostingUnitKey) == true)
                throw new ArgumentException("This hosting unit already exists");
            else
            {
                bool[,] Diary = new bool[13, 31];
                for (int i = 0; i < 13; i++)
                    for (int j = 0; j < 31; j++)
                    {
                        Diary[i, j] = false;
                    }
                hu.Diary = Diary;
                lst.Add(hu.Clone());
                int config = Convert.ToInt32(ConfigRoot.Element("hostingUnitKey").Value);
                config++;
                ConfigRoot.Element("hostingUnitKey").Value = Convert.ToString(config);
                ConfigRoot.Save(ConfigRootPath);
                saveListToXML<HostingUnit>(lst, HostingUnitsRootPath);
            }

        }

        public void AddOrder(Order or)
        {
            try
            {
                Load(ref OrderRoot, OrderRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw;
            }
            var it = (from item in OrderRoot.Elements()
                      where (item.Element("GuestRequestKey").Value == Convert.ToString(or.GuestRequestKey))
                      && (item.Element("HostingUnitKey").Value == Convert.ToString(or.HostingUnitKey))
                      && (item.Element("CreateDate").Value == Convert.ToString(or.CreateDate))
                      select item).FirstOrDefault();
            if (it != null)
                throw new Exception("הבקשה כבר קיימת במאגר");

            or.OrderKey = GetRunningNumForOR();
            OrderRoot.Add(OrCreatorToXML(or));
            OrderRoot.Save(OrderRootPath);
        }

        public static void saveListToXML<T>(List<T> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }

        //update
        public void UpDateGuestRequest(GuestRequest gr)
        {
            try
            {
                Load(ref GuestRequestRoot, GuestRequestRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw r;
            }
            XElement original = (from item in GuestRequestRoot.Elements()
                                 where item.Element("GuestRequestKey").Value == Convert.ToString(gr.GuestRequestKey)
                                 select item).FirstOrDefault();
            if (original == null)
            {
                AddGuestRequest(gr);
                throw new Exception("לא קיימת בקשת אירוח כזו");
            }
            original.Remove();
            GuestRequestRoot.Add(GRCreatorToXML(gr));
            GuestRequestRoot.Save(GuestRequestRootPath);
        }

        public void UpDateHostingUnit(HostingUnit hu)
        {
            try
            {
                Load(ref HostingUnitsRoot, HostingUnitsRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw;
            }
            XElement original = (from item in HostingUnitsRoot.Elements()
                                 where item.Element("HostingUnitKey").Value == Convert.ToString(hu.HostingUnitKey)
                                 select item).FirstOrDefault();
            if (original == null)
            {
                AddHostingUnit(hu);
                throw new Exception("לא קיימת יחידת אירוח כזאת במאגר");
            }
            original.Remove();
            HostingUnitsRoot.Add(HUCreatorToXML(hu));
            HostingUnitsRoot.Save(HostingUnitsRootPath);
        }

        public void UpDateGuestRequestStatus(GuestRequest gr)
        {
            try
            {
                Load(ref GuestRequestRoot, GuestRequestRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw;
            }
            XElement original = (from item in GuestRequestRoot.Elements()
                                 where item.Element("GuestRequestKey").Value == Convert.ToString(gr.GuestRequestKey)
                                 select item).FirstOrDefault();
            if (original == null)
            {
                AddGuestRequest(gr);
                throw new Exception("לא קיימת בקשת אירוח כזו");
            }
            original.Remove();
            GuestRequestRoot.Add(GRCreatorToXML(gr));
            GuestRequestRoot.Save(GuestRequestRootPath);
        }

        public void UpDateOrder(Order or)
        {
            try
            {
                Load(ref OrderRoot, OrderRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw r;
            }
            XElement original = (from item in OrderRoot.Elements()
                                 where item.Element("OrderKey").Value == Convert.ToString(or.OrderKey)
                                 select item).FirstOrDefault();
            if (original == null)
            {
                AddOrder(or);
                throw new Exception("לא קיימת הזמנה כזאת");
            }
            original.Remove();
            OrderRoot.Add(OrCreatorToXML(or));
            OrderRoot.Save(OrderRootPath);
        }

        //delete
        public void DeleteHostingUnit(HostingUnit hu)
        {
            try
            {
                Load(ref HostingUnitsRoot, HostingUnitsRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw r;
            }
            XElement original = (from item in HostingUnitsRoot.Elements()
                                 where item.Element("HostingUnitKey").Value == Convert.ToString(hu.HostingUnitKey)
                                 select item).FirstOrDefault();
            if (original == null)
                throw new Exception("לא היתה קיימת יחידה כזו במאגר");
            original.Remove();
        }

        //read
        public GuestRequest GetGuestRequest(int key)
        {
            GuestRequest gr = GuestRequestsList().FirstOrDefault(item => item.GuestRequestKey == key);
            return gr == null ? null : gr.Clone();
        }

        public HostingUnit GetHostingUnit(int key)
        {
            HostingUnit hu = HostingUnitsList().FirstOrDefault(item => item.HostingUnitKey == key);
            return hu == null ? null : hu.Clone();
        }

        public Order GetOrder(int key)
        {
            var or = (from Order item in OrdersList()
                      let Okey = item.OrderKey
                      where Okey == key
                      select new { ThisOrder = item.Clone() }).FirstOrDefault();

            return or == null ? null : or.ThisOrder;
        }

        public List<Order> HostingUnitOrder(int key)
        {
            var list = (from Order item in OrdersList()
                        where item.HostingUnitKey == key
                        select item.Clone()).ToList();
            return (list.Count == 0) ? null : list;
        }
        #endregion

        #region lists
        public static List<T> loadListFromXML<T>(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            try
            {
                XmlSerializer x = new XmlSerializer(typeof(List<T>));
                List<T> R = (List<T>)x.Deserialize(fs);
                fs.Close();
                return R;
            }
            catch
            {
                fs.Close();
                return new List<T>();
            }

        }

        public List<HostingUnit> HostingUnitsList()
        {
            return loadListFromXML<HostingUnit>(HostingUnitsRootPath);
        }

        public List<GuestRequest> GuestRequestsList()
        {
            return loadListFromXML<GuestRequest>(GuestRequestRootPath);
        }

        public List<Order> OrdersList()
        {
            try
            {
                Load(ref OrderRoot, OrderRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw r;
            }
            List<Order> orders;
            try
            {
                orders = (from p in OrderRoot.Elements()
                          select new BE.Order()
                          {
                              HostingUnitKey = int.Parse(p.Element("HostingUnitKey").Value),
                              GuestRequestKey = int.Parse(p.Element("GuestRequestKey").Value),
                              CreateDate = DateTime.Parse(p.Element("CreateDate").Value),
                              OrderDate = DateTime.Parse(p.Element("OrderDate").Value),
                              OrderKey = int.Parse(p.Element("OrderKey").Value),
                              commission = uint.Parse(p.Element("commission").Value),
                              Status = (Enums.GuestRequestStatus)Enum.Parse(typeof(Enums.GuestRequestStatus), p.Element("Status").Value),
                          }).ToList();
                int config = int.Parse(ConfigRoot.Element("orderKey").Value);
                config++;
                ConfigRoot.Element("orderKey").Value = Convert.ToString(config);
                ConfigRoot.Save(ConfigRootPath);
            }
            catch
            {
                orders = null;
            }
            return orders;
            //return loadListFromXML<BE.Order>(OrdersRootPath);
        }


        public List<BankBranch> BankBranchesList()
        {
            List<HostingUnit> ls = HostingUnitsList();
            var list = (from HostingUnit item in ls
                        let hostItem = item.Owner
                        select hostItem.BankBranchDetails.Clone()).Distinct().ToList();
            return (list.Count == 0) ? throw new Exception("אין סניפי בנק") : list;
        }

        //public List<GuestRequest> GuestRequestsList()
        //{
        //    try
        //    {
        //        Load(ref GuestRequestRoot, GuestRequestRootPath);
        //    }
        //    catch (DirectoryNotFoundException r)
        //    {
        //        throw r;
        //    }
        //    return (from item in GuestRequestRoot.Elements()
        //            select new GuestRequest()
        //            {
        //                GuestRequestKey = Convert.ToInt32(item.Element("GuestRequestKey").Value),
        //                PrivateName = item.Element("PrivateName").Value,
        //                FamilyName = item.Element("FamilyName").Value,
        //                MailAddress = item.Element("MailAddress").Value,
        //                Status = (Enums.GuestRequestStatus)Enum.Parse(typeof(Enums.GuestRequestStatus), item.Element("Status").Value),
        //                RegistrationDate = Convert.ToDateTime(item.Element("RegistrationDate").Value),
        //                EntryDate = Convert.ToDateTime(item.Element("EntryDate").Value),
        //                ReleaseDate = Convert.ToDateTime(item.Element("ReleaseDate").Value),
        //                Area = (Enums.Area)Enum.Parse(typeof(Enums.Area), item.Element("Area").Value),
        //                SubArea = item.Element("SubArea").Value,
        //                Type = (Enums.Type)Enum.Parse(typeof(Enums.Type), item.Element("Type").Value),
        //                Adults = Convert.ToUInt32(item.Element("Adults").Value),
        //                Children = Convert.ToUInt32(item.Element("Children").Value),
        //                Pool = (Enums.Pool)Enum.Parse(typeof(Enums.Pool), item.Element("Pool").Value),
        //                Jacuzzi = (Enums.Jacuzzi)Enum.Parse(typeof(Enums.Jacuzzi), item.Element("Jacuzzi").Value),
        //                Garden = (Enums.Garden)Enum.Parse(typeof(Enums.Garden), item.Element("Garden").Value),
        //                ChildrensAttractions = (Enums.ChildrensAttractions)Enum.Parse(typeof(Enums.ChildrensAttractions), item.Element("ChildrensAttractions").Value),
        //                Breakfast = Convert.ToBoolean(item.Element("Status").Value),
        //                Cradle = Convert.ToBoolean(item.Element("Cradle").Value),
        //                Wifi = Convert.ToBoolean(item.Element("Wifi").Value)
        //            }
        //            ).ToList();
        //}

        //public List<HostingUnit> HostingUnitsList()
        //{
        //    try
        //    {
        //        Load(ref HostingUnitsRoot, HostingUnitsRootPath);
        //    }
        //    catch (DirectoryNotFoundException r)
        //    {
        //        throw r;
        //    }
        //    return (from item in HostingUnitsRoot.Elements()
        //            select new HostingUnit()
        //            {
        //                HostingUnitKey = Convert.ToInt32(item.Element("HostingUnitKey").Value),
        //                Owner = new Host()
        //                {
        //                    HostKey = Convert.ToString(item.Element("Owner").Element("HostKey").Value),
        //                    PrivateName = item.Element("Owner").Element("PrivateName").Value,
        //                    FamilyName = item.Element("Owner").Element("FamilyName").Value,
        //                    PhoneNumber = Convert.ToUInt32(item.Element("Owner").Element("PhoneNumber").Value),
        //                    MailAddress = item.Element("Owner").Element("MailAddress").Value,
        //                    BankBranchDetails = new BankBranch()
        //                    {
        //                        BankNumber = Convert.ToUInt32(item.Element("Owner").Element("BankBranchDetails").Element("BankNumber").Value),
        //                        BankName = item.Element("Owner").Element("BankBranchDetails").Element("BankName").Value,
        //                        BranchNumber = Convert.ToUInt32(item.Element("Owner").Element("BankBranchDetails").Element("BranchNumber").Value),
        //                        BranchAddress = item.Element("Owner").Element("BankBranchDetails").Element("BranchAddress").Value,
        //                        BranchCity = item.Element("Owner").Element("BankBranchDetails").Element("BranchCity").Value
        //                    },
        //                    BankAccountNumber = Convert.ToInt32(item.Element("Owner").Element("BankAccountNumber").Value),
        //                    CollectionClearance = Convert.ToBoolean(item.Element("Owner").Element("CollectionClearance").Value),
        //                    Password = item.Element("Owner").Element("Password").Value
        //                },
        //                HostingUnitName = item.Element("HostingUnitName").Value,
        //                DiaryDto = (from it in item.Element("Diary").Elements()
        //                            select Convert.ToBoolean(it.Value)).ToArray(),
        //                area = (Enums.Area)Enum.Parse(typeof(Enums.Area), item.Element("Area").Value),
        //                PriceForAdult = Convert.ToUInt32(item.Element("PriceForAdult")),
        //                PriceForChild = Convert.ToUInt32(item.Element("PriceForAdult"))
        //            }).ToList();
        //}

        public List<Host> AllHosts()
        {
            var list = (from HostingUnit hu in HostingUnitsList()
                        select hu.Owner.Clone()).Distinct().ToList();
            return (list.Count == 0) ? throw new Exception("There is no Hosts!") : list;
        }

        //public List<Order> OrdersList()
        //{
        //    try
        //    {
        //        Load(ref OrderRoot, OrderRootPath);
        //    }
        //    catch (DirectoryNotFoundException r)
        //    {
        //        throw r;
        //    }
        //    return (from item in OrderRoot.Elements()
        //            select new Order()
        //            {
        //                HostingUnitKey = Convert.ToInt32(item.Element("HostingUnitKey").Value),
        //                GuestRequestKey = Convert.ToInt32(item.Element("GuestRequestKey").Value),
        //                OrderKey = Convert.ToInt32(item.Element("OrderKey").Value),
        //                Status = (Enums.orderStatus)Enum.Parse(typeof(Enums.orderStatus), item.Element("Status").Value),
        //                CreateDate = Convert.ToDateTime(item.Element("CreateDate").Value),
        //                OrderDate = Convert.ToDateTime(item.Element("OrderDate").Value),
        //                commission = Convert.ToUInt32(item.Element("commission").Value)
        //            }).ToList();
        //}

        //public List<GuestRequest> GuestRequestsList(Func<GuestRequest, bool> predicat = null)
        //{
        //    var list = (from Order item in AllOrders()
        //                select item.Clone()).ToList();
        //    return (list.Count == 0) ? null : list;
        //}
        #endregion

        #region temp Function
        private void Load(ref XElement t, string a)
        {
            try
            {
                t = XElement.Load(a);
            }
            catch
            {
                throw new DirectoryNotFoundException(" ERROR READIND THE FILE" + a);
            }

        }
        private XElement GRCreatorToXML(GuestRequest gr)
        {
            return new XElement("GuestRequest", new XElement("GuestRequestKey", gr.GuestRequestKey),
                                                new XElement("PrivateName", gr.PrivateName),
                                                new XElement("FamilyName", gr.FamilyName),
                                                new XElement("MailAddress", gr.MailAddress),
                                                new XElement("Status", gr.Status),
                                                new XElement("RegistrationDate", gr.RegistrationDate),
                                                new XElement("EntryDate", gr.EntryDate),
                                                new XElement("ReleaseDate", gr.ReleaseDate),
                                                new XElement("Area", gr.Area),
                                                new XElement("SubArea", gr.SubArea),
                                                new XElement("Type", gr.Type),
                                                new XElement("Adults", gr.Adults),
                                                new XElement("Children", gr.Children),
                                                new XElement("Pool", gr.Pool),
                                                new XElement("Jacuzzi", gr.Jacuzzi),
                                                new XElement("Garden", gr.Garden),
                                                new XElement("Cradle", gr.Cradle),
                                                new XElement("Wifi", gr.Wifi),
                                                new XElement("ChildrensAttractions", gr.ChildrensAttractions),
                                                new XElement("Breakfast", gr.Breakfast));
        }
        public XElement HUCreatorToXML(HostingUnit hostingUnit)
        {
            XElement hostingUnitElement = new XElement("hostingUnit");

            foreach (PropertyInfo item in typeof(HostingUnit).GetProperties())
            {
                if (item.GetValue(hostingUnit, null) != null)
                {
                    if (item.Name != "Owner" && item.Name != "Diary")
                    {
                        hostingUnitElement.Add(new XElement(item.Name, item.GetValue(hostingUnit, null).ToString()));
                    }
                    else if (item.Name == "Owner")
                    {
                        XElement ownerElement = new XElement("owner");
                        foreach (PropertyInfo t in typeof(Host).GetProperties())
                        {
                            if (item.GetValue(hostingUnit.Owner, null) != null)
                            {
                                if (t.Name != "BankBranchDetails")
                                {
                                    ownerElement.Add(new XElement(t.Name, t.GetValue(hostingUnit.Owner, null).ToString()));
                                }
                                else
                                {
                                    XElement BankBranchElement = new XElement("BankBranchDetails");
                                    foreach (PropertyInfo n in typeof(BankBranch).GetProperties())
                                    {
                                        if (item.GetValue(hostingUnit.Owner.BankBranchDetails, null) != null)
                                        {
                                            BankBranchElement.Add(new XElement(n.Name, n.GetValue(hostingUnit.Owner.BankBranchDetails, null).ToString()));
                                        }
                                        else
                                        {
                                            BankBranchElement.Add(new XElement(n.Name, "null"));
                                        }
                                    }
                                    ownerElement.Add(new XElement(BankBranchElement));
                                }
                            }
                            else
                            {
                                ownerElement.Add(new XElement(t.Name, "null"));
                            }
                        }
                        hostingUnitElement.Add(new XElement(ownerElement));
                    }
                    else if (item.Name == "Diary")
                    {
                        //XmlSerializer xmlSer = new XmlSerializer(hostingUnit.Diary.GetType());
                        hostingUnitElement.Add(new XElement(item.Name, hostingUnit.DiaryDto));
                    }
                }
                else
                {
                    hostingUnitElement.Add(new XElement(item.Name, "null"));
                }

            }
            return hostingUnitElement;
        }

        private XElement OrCreatorToXML(Order or)
        {
            return new XElement("Order", new XElement("HostingUnitKey", or.HostingUnitKey),
                                         new XElement("GuestRequestKey", or.GuestRequestKey),
                                         new XElement("OrderKey", or.OrderKey),
                                         new XElement("Status", or.Status),
                                         new XElement("CreateDate", or.CreateDate),
                                         new XElement("OrderDate", or.OrderDate),
                                         new XElement("OrderFee", or.commission));
        }

        private int GetRunningNumForGR()
        {
            try
            {
                Load(ref ConfigRoot, ConfigRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw r;
            }

            XElement it = ConfigRoot.Element("guestRequestKey");
            int currNum = Convert.ToInt32(it.Value);
            it.SetValue(currNum + 1);
            ConfigRoot.Save(ConfigRootPath);

            return currNum;
        }
        private int GetRunningNumForHU()
        {
            try
            {
                Load(ref ConfigRoot, ConfigRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw r;
            }
            XElement it = ConfigRoot.Element("hostingUnitKey");
            int currNum = Convert.ToInt32(it.Value);
            it.SetValue(currNum + 1);
            ConfigRoot.Save(ConfigRootPath);

            return currNum;
        }
        //private int GetRunningNumForHO()
        //{
        //    try
        //    {
        //        Load(ref ConfigRoot, ConfigRootPath);
        //    }
        //    catch (DirectoryNotFoundException r)
        //    {
        //        throw r;
        //    }
        //    XElement it = ConfigRoot.Element("runningNumberForHost");
        //    int currNum = Convert.ToInt32(it.Value);
        //    it.SetValue(currNum + 1);
        //    ConfigRoot.Save(ConfigRootPath);

        //    return currNum;
        //}
        private int GetRunningNumForOR()
        {
            try
            {
                Load(ref ConfigRoot, ConfigRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw r;
            }
            XElement it = ConfigRoot.Element("orderKey");
            int currNum = Convert.ToInt32(it.Value);
            it.SetValue(currNum + 1);
            ConfigRoot.Save(ConfigRootPath);

            return currNum;
        }
        private int GetCommission()
        {
            try
            {
                Load(ref ConfigRoot, ConfigRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw r;
            }
            return Convert.ToInt32(ConfigRoot.Element("commission").Value);

        }
        private int GetNumDaysExpire()
        {
            try
            {
                Load(ref ConfigRoot, ConfigRootPath);
            }
            catch (DirectoryNotFoundException r)
            {
                throw r;
            }
            return Convert.ToInt32(ConfigRoot.Element("numDaysExpire").Value);

        }
        private List<HostingUnit> tempForLoadingFile = new List<HostingUnit>()
        {
            new HostingUnit
            {
                HostingUnitKey=00,
                Owner=new Host()
                {
                    HostKey="211889092",
                    PrivateName="רחלי",
                    FamilyName="בלוך",
                    MailAddress="rachelib427@gmail.com",
                    PhoneNumber=0500002212,
                    BankAccountNumber=126345,
                    Password="1234",
                    CollectionClearance=true,
                    BankBranchDetails=new BankBranch()
                        {
                            BankName="הפועלים",
                            BankNumber=12,
                            BranchCity="אלעד",
                            BranchAddress="יהודה הנשיא 96",
                            BranchNumber=475

                        }
                },
                HostingUnitName="MyPalace",
                area=Enums.Area.מרכז,
                Diary=temp(),
                PriceForAdult=200,
                PriceForChild=100

            },
             new HostingUnit
            {
                HostingUnitKey=01,
                Owner=new Host()
                {
                    HostKey="211554043",
                    PrivateName="אפרת",
                    FamilyName="קלנר",
                    MailAddress="efratkelner@gmail.com",
                    PhoneNumber=0541112212,
                    BankAccountNumber=87475,
                    Password="1234",
                    CollectionClearance=true,
                    BankBranchDetails=new BankBranch()
                        {
                            BankName="פאגי",
                            BankNumber=05,
                            BranchCity="רחובות",
                            BranchAddress="עזרא 38",
                            BranchNumber=74

                        }
                },
                HostingUnitName="Mycastle",
                area=Enums.Area.ירושלים,
                Diary=temp(),
                PriceForAdult=190,
                PriceForChild=90
            },
              new HostingUnit
            {
                HostingUnitKey=02,
                Owner=new Host()
                {
                    HostKey="207274911",
                    PrivateName="שרה",
                    FamilyName="כהן",
                    MailAddress="sarale@gmail.com",
                    PhoneNumber=0536655441,
                    BankAccountNumber=96328,
                    Password="1234",
                    CollectionClearance=false,
                    BankBranchDetails=new BankBranch()
                        {
                            BankName="הפועלים",
                            BankNumber=12,
                            BranchCity="אלעד",
                            BranchAddress="יהודה הנשיא 96",
                            BranchNumber=475

                        }
                },
                HostingUnitName="The Bloch's",
                area=Enums.Area.צפון,
                Diary=temp(),
                PriceForAdult=150,
                PriceForChild=100
            }


        };
        private static bool[,] temp()//temp to initialize the Diary
        {
            bool[,] Diary = new bool[31, 12];
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 30; j++)
                    Diary[j, i] = false;
            return Diary;
        }
        #endregion
    }
}


