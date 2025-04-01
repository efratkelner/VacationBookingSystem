using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;


namespace DAL
{
    public class imp_Dal : IDAL
    {

        #region CRUD
        void IDAL.AddGuestRequest(GuestRequest g)
        {
            GuestRequest temp = DataSource.GetGuestRequests().Find(x => g.GuestRequestKey == x.GuestRequestKey);
            if (temp != null)//if there is request such like that in the list-> add
            {
                throw new ArgumentException("This request already exists");
            }
            else
            {
                DataSource.GetGuestRequests().Add(g);
            }
        }

        void IDAL.UpDateGuestRequestStatus(GuestRequest g)
        {
            int x = DataSource.GetGuestRequests().FindIndex(item => item.GuestRequestKey == g.GuestRequestKey);
            if (x != -1)
            {
                g.Status = DataSource.GetGuestRequests()[x].Status;
                return;
            }
            throw new KeyNotFoundException("There is no such a request");
        }

        void IDAL.UpDateGuestRequest(GuestRequest g)
        {

            int x = DataSource.GetGuestRequests().FindIndex(item => item.GuestRequestKey == g.GuestRequestKey);
            if (x == -1)//אין כזה מפתח יחידת אירוח ברשימה
            {
                throw new KeyNotFoundException("There is no such request");
            }
            DataSource.GetGuestRequests()[x] = g;
        }



        void IDAL.AddHostingUnit(HostingUnit h)
        {
            if (DataSource.GetHostingUnits().Exists(item => item.HostingUnitKey == h.HostingUnitKey) == true)
                throw new ArgumentException("This hosting unit already exists");
            else
            {
                DataSource.GetHostingUnits().Add(h);
            }

        }

        void IDAL.UpDateHostingUnit(HostingUnit h)
        {
            int x = DataSource.GetHostingUnits().FindIndex(item => item.HostingUnitKey == h.HostingUnitKey);
            if (x == -1)//אין כזה מפתח יחידת אירוח ברשימה
            {
                throw new KeyNotFoundException("There is no such a hosting unit");
            }
            DataSource.GetHostingUnits()[x] = h;
        }

        void IDAL.DeleteHostingUnit(HostingUnit h)
        {
            if (DataSource.GetHostingUnits().Exists(item => item.HostingUnitKey == h.HostingUnitKey) == true)
            {
                DataSource.GetHostingUnits().Remove(h);
                return;
            }
            throw new KeyNotFoundException("There is no such a hosting unit");
        }

        void IDAL.AddOrder(Order o)
        {
            if (DataSource.GetOrders().Exists(item => item.OrderKey == o.OrderKey) == true)
                throw new ArgumentException("This order already exists");
            else
            {
                DataSource.GetOrders().Add(o);
                var v = DataSource.GetOrders().Where(item => item.OrderKey == o.OrderKey);
                v.FirstOrDefault().Status = Enums.orderStatus.לא_טופלה;
            }
        }

        void IDAL.UpDateOrder(Order o)
        {
            int index = DataSource.GetOrders().FindIndex(item => item.OrderKey == o.OrderKey);
            if (index == -1)
            {
                throw new KeyNotFoundException("There is no such an order");
            }
            o.Status = DataSource.GetOrders()[index].Status;
        }
        #endregion
        #region data lists
        List<HostingUnit> IDAL.HostingUnitsList()
        {
            return DataSource.GetHostingUnits();
        }
        List<GuestRequest> IDAL.GuestRequestsList()
        {
            return DataSource.GetGuestRequests();
        }
        List<Order> IDAL.OrdersList()
        {
            return DataSource.GetOrders();
        }
        List<BankBranch> IDAL.BankBranchesList()
        {

            var BankBranches = DataSource.GetHostingUnits().Select(x => x.Owner.BankBranchDetails).ToList();
            return BankBranches;
        }
        #endregion
    }
}