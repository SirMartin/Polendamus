using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Polendamus.Models;
using System.Web.Routing;

namespace Polendamus.Controllers
{
    public class BaseController : Controller
    {
        protected Polendamus.polendamusEntities GetNewDBContext()
        {
            Polendamus.polendamusEntities db = new Polendamus.polendamusEntities();
            db.ContextOptions.LazyLoadingEnabled = false;
            return db;
        }

        private static void RaiseErrorSignal(Exception e)
        {
            var context = System.Web.HttpContext.Current;
            //ErrorSignal.FromContext(context).Raise(e, context);
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            RaiseErrorSignal(filterContext.Exception);
            base.OnException(filterContext);
        }


        public IFormsAuthenticationService FormsService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {

            if (FormsService == null)
            {
                FormsService = new FormsAuthenticationService();
            }

            base.Initialize(requestContext);
        }


    }
}
