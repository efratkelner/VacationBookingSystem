using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Configuration
    {
        static long GuestRequestKey=2;
        // static uint BankNumber;
        static long HostingUnitKey=2;
        static long OrderKey;
        static uint Commission = 10;
        public static uint expireRequestDays = 30;
        static string mPassword="12345";

        public static long GetGuestRequestKey() { return GuestRequestKey; }
        public static void SetGuestRequestKey(long val) { GuestRequestKey += val; }

        //public static uint GetBankNumber(){ return BankNumber; }
        //public static void SetBankNumber(uint val) { BankNumber=val; }

        public static long GetHostingUnitKey() { return HostingUnitKey; }
        public static void SetHostingUnitKey(int val) { HostingUnitKey += val; }

        public static long GetOrderKey() { return OrderKey; }
        public static void SetOrderKey(long val) { OrderKey += val; }

        public static uint GetCommission() { return Commission; }
        public static void SetCommission(uint val) { Commission += val; }

        public static string GetmPassword() { return mPassword; }
        public static void SetManagerP(string val) { mPassword = val; }

    }
}
