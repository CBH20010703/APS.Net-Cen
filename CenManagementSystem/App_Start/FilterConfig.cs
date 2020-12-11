using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CenManagementSystem.App_Start.Filters;

namespace CenManagementSystem.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
          filters.Add(new LogoinFilterAttribute());
            filters.Add(new ErrorFilterAttribute());
        }
    }
}