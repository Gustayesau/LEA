using LEA_Salón.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEA_Salón.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult GetEvents()
        //{
        //    using (InvenFacturaEntities dc = new InvenFacturaEntities())
        //    {
        //        var events = dc.Eventos.ToList();
        //        return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    }
        //}

        //[HttpPost]
        //public JsonResult SaveEvent(Eventos e)
        //{
        //    var status = false;
        //    using (InvenFacturaEntities dc = new InvenFacturaEntities())
        //    {
        //        if (e.IdEventos > 0)
        //        {
        //            //Update the event
        //            var v = dc.Eventos.Where(a => a.IdEventos == e.IdEventos).FirstOrDefault();
        //            if (v != null)
        //            {
        //                v.Tema = e.Tema;
        //                v.Inicio = e.Inicio;
        //                v.Final = e.Final;
        //                v.Descripcion = e.Descripcion;
        //                v.ColorTema = e.ColorTema;
        //            }
        //        }
        //        else
        //        {
        //            dc.Eventos.Add(e);
        //        }
        //        dc.SaveChanges();
        //        status = true;
        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}
        //[HttpPost]
        //public JsonResult DeleteEvent(int eventID)
        //{
        //    var status = false;
        //    using (InvenFacturaEntities dc = new InvenFacturaEntities())
        //    {
        //        var v = dc.Eventos.Where(a => a.IdEventos == eventID).FirstOrDefault();
        //        if (v != null)
        //        {
        //            dc.Eventos.Remove(v);
        //            dc.SaveChanges();
        //            status = true;
        //        }
        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}
    }
}