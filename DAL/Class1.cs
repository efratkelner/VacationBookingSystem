using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DAL
{
    public class FactoryDal
    {
        public IDAL GetDAL()
        {
            return new imp_Dal();
        }
    }
}
