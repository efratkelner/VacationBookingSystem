using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDAL
    {
        #region CRUD
        void AddGuestRequest(GuestRequest g);
        void UpDateGuestRequestStatus(GuestRequest g);
        void UpDateGuestRequest(GuestRequest g);
        void UpDateHostingUnit(HostingUnit h);
        void AddHostingUnit(HostingUnit h);
        void DeleteHostingUnit(HostingUnit h);
        void AddOrder(Order o);
        void UpDateOrder(Order o);
        #endregion
        #region data lists
        List<HostingUnit> HostingUnitsList();
        List<GuestRequest> GuestRequestsList();
        List<Order> OrdersList();
        List<BankBranch> BankBranchesList();
        #endregion
    }
}
