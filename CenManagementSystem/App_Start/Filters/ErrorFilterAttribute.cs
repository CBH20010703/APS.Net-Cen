﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CenManagementSystem.Models;

namespace CenManagementSystem.App_Start.Filters
{
    public class ErrorFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            db_CenSystemEntities2 db = new db_CenSystemEntities2();

            try
            {
               
                Exception ex = filterContext.Exception;
                db.ErrorLog.Add(new ErrorLog
                {
                    error_content = ex.ToString(),
                    error_createdatetime = DateTime.Now,
                });
                db.SaveChanges();
                filterContext.HttpContext.Response.Redirect("/Logoin/Index");
                filterContext.ExceptionHandled = true;
                base.OnException(filterContext);
            }
            catch (Exception err)
            {
                db.ErrorLog.Add(new ErrorLog
                {
                    error_content = err.ToString(),
                    error_createdatetime = DateTime.Now,
                });
                filterContext.HttpContext.Response.Redirect("/Logoin/Index");
            }
           
        }
    }
}