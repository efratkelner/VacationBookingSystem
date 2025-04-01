using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest : Inumerable
    {
        public long GuestRequestKey { set; get; }
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
        public string MailAddress { get; set; }
        public Enums.GuestRequestStatus Status { get; set; }
        public DateTime RegistrationDate { get; set; }//תאריך רישום למערכת
        public DateTime EntryDate { get; set; }//תאריך רצוי לתחילת הנופש
        public DateTime ReleaseDate { get; set; }//תאריך רצוי לסיום הנופש
        public Enums.Area Area { get; set; }
        public string SubArea { get; set; }//city
        public Enums.Type Type { get; set; }
        public uint Adults { set; get; }
        //public uint _Adults
        //{
        //    get { return Adults; }
        //    set
        //    {
        //        if (value == ' ')
        //            throw new Exception("הכנס מספר טלפון");
        //        if (value == 0 || value < 0)
        //            throw new Exception("מספר לא תקין");
        //        Adults = value;
        //    }
        //}
        public uint Children { set; get; }
        //public uint _Children
        //{
        //    get { return Children; }
        //    set
        //    {
        //        if (value == ' ')
        //            throw new Exception("הכנס מספר טלפון");
        //        if (value == 0 || value < 0)
        //            throw new Exception("מספר לא תקין");
        //        Children = value;
        //    }
        //}
        public Enums.Pool Pool { get; set; }
        public Enums.Jacuzzi Jacuzzi { get; set; }
        public Enums.Garden Garden { get; set; }
        public Enums.ChildrensAttractions ChildrensAttractions { get; set; }
        public override string ToString()
        {
            return GuestRequestKey + " " + PrivateName;
        }
        public bool Wifi { get; set; }
        public bool Cradle { get; set; }
        public bool Breakfast { get; set; }
        public int LengthOfVacation()
        {
            int sum = 0;
            DateTime temp = EntryDate;
            while (temp <= ReleaseDate)
            {
                sum++;
                temp.AddDays(1);
            }
            return sum;
        }

    }
}
