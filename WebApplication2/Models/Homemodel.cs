using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Context;

namespace WebApplication2.Models
{
    public class Homemodel
    {
        public List<product> ListProduct { get; set; }
        public List<catalog> ListCatalog { get; set; }
    }
}