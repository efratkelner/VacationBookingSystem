using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        #region CRUD
        void _AddGuestRequest(GuestRequest g);
        void _UpDateGuestRequest(GuestRequest g);
        void _UpDateHostingUnit(HostingUnit h);
        void _AddHostingUnit(HostingUnit h);
        void _DeleteHostingUnit(HostingUnit h);
        void _AddOrder(Order o);
        void _UpDateOrder(Order o);
        #endregion
        #region lists
        List<HostingUnit> _HostingUnitsList();
        List<GuestRequest> _GuestRequestsList();
        List<Order> _OrdersList();
        List<BankBranch> _BankBranchesList();
        List<HostingUnit> _EmptyHostingUnits(DateTime date, int numDays);
        List<Order> _OrdersBefore(int num);
        List<GuestRequest> _SomeGuestRequests(Predicate<GuestRequest> predicate);
        #endregion
        #region extra functions
        int _DaysGap(DateTime date1, DateTime date2);
        int _DaysGap(DateTime date1);
        int _NumOfOrders(GuestRequest gr);
        int _DoneOredrs(GuestRequest gr);
        List<GuestRequest> grListBy(string SubArea);//return guestsrequests in this sub area which require jacuzzi and a pool is not neccesary
        List<HostingUnit> hostsList(string HostKey);//return all the hosting units that belong to this host
        List<HostingUnit> _hostsList(string Area);//return all hosting units which are in this area
        List<Order> oListBy(string _hostKey);//return orders of the host
        List<GuestRequest> guestsList(string mail);//return guest requests by mail 
        string popularArea();//return the most popular area,which area 'has' the most guest requests
        string popularHost();//return the host who has the most "closed through the site" orders
        uint TotalPrice(Order order);//return the total price for the guest
        HostingUnit HostingUnitByName(string hostName);//return an hosting unit search it by its name
        //string popularHost();//return the host who has the most "closed through the site" orders
        uint sumHostingUnits(Host host);//return how many hosting units does the host has
        bool checkCollectionClearance(Order o);// This function checks if the owner of a given hosting unit has a collection clearance
        string enumTrans(string e);//translate the enums to Hebrew
        #endregion
        #region groups
        IEnumerable<IGrouping<uint, Host>> hostsByNumOfHostingUnits();
        IEnumerable<IGrouping<Enums.Area, GuestRequest>> ByArea();
        IEnumerable<IGrouping<Enums.Area, HostingUnit>> ByAnArea();
        IEnumerable<IGrouping<uint, GuestRequest>> ByNumOfGuests();
        IEnumerable<IGrouping<string, Host>> hostsByFamilyeName();
        IEnumerable<IGrouping<long, Host>> hostsByPhoneNumber();
        IEnumerable<IGrouping<string, Host>> hostsByPrivateName();
        IEnumerable<IGrouping<string, Host>> hostsByID();

        IEnumerable<IGrouping<uint, Order>> ordersByCommision();
        IEnumerable<IGrouping<DateTime, Order>> ordersByCreatDate();
        IEnumerable<IGrouping<long, Order>> ordersByHostingUnitKey();
        IEnumerable<IGrouping<long, Order>> ordersByOrderKey();

        IEnumerable<IGrouping<Enums.Area, GuestRequest>> requestByArea(Enums.Area Area);
        IEnumerable<IGrouping<DateTime, GuestRequest>> requestByEntryDate();
        IEnumerable<IGrouping<uint, GuestRequest>> requestByAdults();
        IEnumerable<IGrouping<uint, GuestRequest>> requestByChildren();
        IEnumerable<IGrouping<string, GuestRequest>> requestByPrivateName();
        IEnumerable<IGrouping<int, GuestRequest>> requestByLengthOfVacation();
        IEnumerable<IGrouping<string, GuestRequest>> requestByFamilyName();





        #endregion

    }
}