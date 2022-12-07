using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.DAO
{
    public class MenuDao
    {
        QUANLITHOITRANGEntities db = null;
        public MenuDao()
        {
            db = new QUANLITHOITRANGEntities();
        }
        public List<catalog> ListByGroupID(int groupID)
        {
            return db.catalogs.Where(x => x.id != groupID).ToList();
        }
    }
}