﻿using System.Web;
using System.Web.Mvc;

namespace N01520224_Hari_Assignment3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
