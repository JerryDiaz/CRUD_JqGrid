using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class ObjsDB
    {
        public static string SP_PRODUCT_LIST => "dbo.usp_cmaCommerceCategoryList";
        public static string SP_PRODUCT_ADD => "dbo.usp_cmaCommerceCategoryCreate";
        public static string SP_PRODUCT_EDIT => "dbo.usp_cmaCommerceCategoryUpdate";
        public static string SP_PRODUCT_DEACTIVATE => "dbo.usp_cmaCommerceCategoryDeactivate";
    }
}