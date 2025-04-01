using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class FactoryBL
    {

        static IBL fBL = null;
        public static IBL GetBL()
        {
            if (fBL == null)
            {
                fBL = new imp_Bl();
            }
            return fBL;
        }

    }
}