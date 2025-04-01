using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FactoryDAL
    {
        static IDAL fDAL = null;
        public static IDAL GetDAL()
        {
            if (fDAL == null)

                fDAL = new Dal_XML_imp();

            return fDAL;
        }
    }
}