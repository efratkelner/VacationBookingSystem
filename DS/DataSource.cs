using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        public static List<HostingUnit> HostingUnits = new List<HostingUnit>()
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
        public static List<Order> Orders = new List<Order>()
        {
            new Order
            {
                HostingUnitKey=00,
                GuestRequestKey=01,
                OrderKey=0000,
                CreateDate=new DateTime(2019,01,02),
                OrderDate=new DateTime(2019,01,03),
                Status=Enums.orderStatus.לא_טופלה,

            },
             new Order
            {
                HostingUnitKey=01,
                GuestRequestKey=02,
                OrderKey=0001,
                CreateDate=new DateTime(2019,02,02),
                OrderDate=new DateTime(2019,02,04),
                Status=Enums.orderStatus.לא_טופלה,

            },
              new Order
            {
                HostingUnitKey=00,
                GuestRequestKey=01,
                OrderKey=0002,
                CreateDate=new DateTime(2019,01,02),
                OrderDate=new DateTime(2019,01,07),
                Status=Enums.orderStatus.לא_טופלה,

            }


        };
        public static List<GuestRequest> GuestRequests = new List<GuestRequest>()
        {
            new GuestRequest()
            {
                GuestRequestKey=00,
                PrivateName="דיקלה",
                FamilyName="לוי",
                Adults=2,
                Children=0,
                Garden=Enums.Garden.אפשרי,
                Pool=Enums.Pool.אפשרי,
                Cradle=false,
                Jacuzzi=Enums.Jacuzzi.נחוץ,
                Breakfast=false,
                ChildrensAttractions=Enums.ChildrensAttractions.לא_מעונין,
                Wifi=true,
                EntryDate=new DateTime(2019,01,02),
                ReleaseDate=new DateTime(2019,01,02),
                MailAddress="diklalevi@gmail.com",
                Area=Enums.Area.צפון,
                RegistrationDate=new DateTime(2019,01,11),
                Type=Enums.Type.מחנאות,
                SubArea="קיסריה",
                Status=Enums.GuestRequestStatus.פתוחה
            },

              new GuestRequest()
            {
                GuestRequestKey=01,
                PrivateName="דנה",
                FamilyName="ישראלי",
                Adults=5,
                Children=7,
                Garden=Enums.Garden.אפשרי,
                Pool=Enums.Pool.אפשרי,
                Cradle=true,
                Jacuzzi=Enums.Jacuzzi.נחוץ,
                Breakfast=true,
                ChildrensAttractions=Enums.ChildrensAttractions.לא_מעונין,
                Wifi=true,
                EntryDate=new DateTime(03,05,19),
                ReleaseDate=new DateTime(05,05,19),
                MailAddress="rachelib427@gmail.com",
                Area=Enums.Area.צפון,
                RegistrationDate=new DateTime(2019,01,13),
                Type=Enums.Type.צימר,
                SubArea="טבריה",
                Status=Enums.GuestRequestStatus.פתוחה
            },
                new GuestRequest()
            {
                GuestRequestKey=02,
                PrivateName="אברהם",
                FamilyName="כץ",
                Adults=1,
                Children=0,
                Garden=Enums.Garden.לא_מעונין,
                Pool=Enums.Pool.לא_מעונין,
                Cradle=false,
                Jacuzzi=Enums.Jacuzzi.אפשרי,
                Breakfast=false,
                ChildrensAttractions=Enums.ChildrensAttractions.לא_מעונין,
                Wifi=false,
                EntryDate=new DateTime(2019,01,02),
                ReleaseDate=new DateTime(2019,01,06),
                MailAddress="avracatz@gmail.com",
                Area=Enums.Area.צפון,
                RegistrationDate=new DateTime(2019,01,19),
                Type=Enums.Type.מחנאות,
                SubArea="ערד",
                Status=Enums.GuestRequestStatus.פתוחה
            }









        };
        public static List<Host> GetHosts()
        {
            List<Host> hosts = new List<Host>();
            foreach (var item in GetHostingUnits())
            {
                hosts.Add(item.Owner);
            }
            return hosts;
        }//to make things more comfortable

        public static List<HostingUnit> GetHostingUnits()
        {
            return HostingUnits;
        }
        public void SetHostingUnits(List<HostingUnit> huList)
        {
            HostingUnits = huList;
        }
        public static List<Order> GetOrders()
        {
            return Orders;
        }
        public void SetOrders(List<Order> oList)
        {
            Orders = oList;
        }
        public static List<GuestRequest> GetGuestRequests()
        {
            return GuestRequests;
        }
        public void SetHostingUnits(List<GuestRequest> grList)
        {
            GuestRequests = grList;
        }
        private static bool[,] temp()//temp to initialize the Diary
        {
            bool[,] Diary = new bool[31, 12];
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 30; j++)
                    Diary[j, i] = false;
            return Diary;
        }
    }
}
