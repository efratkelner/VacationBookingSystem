using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;


namespace BE
{
    public class Host
    {
        public string HostKey { set; get; }
        //public string _HostKey
        //{
        //    get { return HostKey; }
        //    set
        //    {
        //        string strID = HostKey;
        //        int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
        //        int count = 0;
        //        bool flag = true;
        //        while (flag)
        //        {
        //            if (strID == null)
        //                flag = false;

        //            strID = strID.PadLeft(9, '0');

        //            for (int i = 0; i < 9; i++)
        //            {
        //                int num = Int32.Parse(strID.Substring(i, 1)) * id_12_digits[i];

        //                if (num > 9)
        //                    num = (num / 10) + (num % 10);

        //                count += num;
        //            }

        //            flag = (count % 10 == 0);
        //        }

        //        if (!flag)
        //            throw new Exception("תעודת זהות לא תקינה");
        //        if (value == "")
        //            throw new Exception("הכנס ת.ז");
        //        HostKey = value;
        //    }
        //}
        public string PrivateName { set; get; }
        //public string _PrivateName
        //{
        //    get { return PrivateName; }
        //    set
        //    {
        //        if (value == "")
        //            throw new Exception("הזן טקסט");
        //        if (value[0] == ' ')
        //            throw new Exception("שם לא מתחיל ברווח");
        //        if (PrivateName.Length < 3 || PrivateName.Length > 35)
        //            throw new Exception("שם מכיל 2-35 אותיות");
        //        PrivateName = value;
        //    }
        //}
        public string FamilyName { set; get; }
        //public string _FamilyName
        //{
        //    get { return FamilyName; }
        //    set
        //    {
        //        if (value == "")
        //            throw new Exception("הזן טקסט");
        //        if (value[0] == ' ')
        //            throw new Exception("שם לא מתחיל ברווח");
        //        if (FamilyName.Length < 3 || FamilyName.Length > 35)
        //            throw new Exception("שם מכיל 2-35 אותיות");
        //        FamilyName = value;
        //    }
        //}
        public long PhoneNumber { set; get; }
        //public long _PhoneNumber
        //{
        //    get { return PhoneNumber; }
        //    set
        //    {
        //        if (value == ' ')
        //            throw new Exception("הכנס מספר טלפון");
        //        if (value == 0 || value < 0)
        //            throw new Exception("מספר לא תקין");
        //        PhoneNumber = value;
        //    }
        //}
        public string MailAddress { get; set; }
        public BankBranch BankBranchDetails;
        public long BankAccountNumber { get; set; }
        public bool CollectionClearance { get; set; }
        public override string ToString()
        {
            return PrivateName + " " + FamilyName + " " + MailAddress;
        }
        public string Password { get; set; }







    }
}
