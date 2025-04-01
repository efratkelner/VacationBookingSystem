using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class HostingUnit
    {
        public long HostingUnitKey { get; set; }
        public Host Owner;
        public uint PriceForAdult { set; get; }
        //public uint _PriceForAdult
        //{
        //    get { return PriceForAdult; }
        //    set
        //    {
        //        if (value == ' ')
        //            throw new Exception("הכנס מחיר");
        //        if (PriceForAdult < 10)
        //            throw new Exception("מחיר לא הגיוני");
        //        PriceForAdult = value;
        //    }
        //}
        public uint PriceForChild { set; get; }
        //public uint _PriceForChild
        //{
        //    get { return PriceForChild; }
        //    set
        //    {
        //        if (value == ' ')
        //            throw new Exception("הכנס מחיר");
        //        if (PriceForChild < 10)
        //            throw new Exception("מחיר לא הגיוני");
        //        PriceForChild = value;
        //    }
        //}
        public string HostingUnitName { set; get; }
        //public string _HostingUnitName
        //{
        //    get { return HostingUnitName; }
        //    set
        //    {
        //        if (value == "")
        //            throw new Exception("הזן טקסט");
        //        if (value[0] == ' ')
        //            throw new Exception("שם לא מתחיל ברווח");
        //        if (HostingUnitName.Length < 3 || HostingUnitName.Length > 35)
        //            throw new Exception("שם מכיל 2-35 אותיות");
        //        HostingUnitName = value;
        //    }
        //}
       


        [XmlIgnore]
        public bool[,] Diary { get; set; }

        //optional. tell the XmlSerializer to name the Array Element as'Diary'
        // instead of 'DiaryDto'
        [XmlArray("Diary")]
        public bool[] DiaryDto
        {
            get { return Diary.Flatten(); }
            set { Diary = value.Expand(13); } //31 is the number of rows in the matrix
        }

        public override string ToString()
        {
            return HostingUnitName;
        }
        public Enums.Area area;

    }
}
