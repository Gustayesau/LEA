using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LEA_Salón.Models;

namespace LEA_Salón.Controllers
{
    public class ComprasController : Controller
    {
        private InvenFacturaEntities db = new InvenFacturaEntities();

        // GET: Compras
        public ActionResult Index()
        {
            var compra = db.Compra.Include(c => c.Producto).Include(c => c.Proveedor);
            return View(compra.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre");
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "NombreProveedor");
            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompra,IdProducto,IdProveedor,PrecioCompra,Cantidad,FechaVencimiento,FechaCompra,Estado,TotalCompra,PrecioVenta")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                double VU = compra.PrecioCompra;
                double total = Convert.ToDouble(compra.Cantidad);
                // Total Compra
                compra.TotalCompra = VU * total;
                db.Compra.Add(compra);
                db.SaveChanges();
                var ingreso = (from p in db.Producto
                               where p.IdProducto == compra.IdProducto
                               select p).FirstOrDefault();
                var incremento = compra.Cantidad;
                var cantidad = ingreso.Existencia;
                //Aumento de Existencias
                ingreso.Existencia = cantidad + incremento;
                db.Entry(ingreso).State = EntityState.Modified;
                db.SaveChanges();

                var precio = (from p in db.Producto
                              where p.IdProducto == compra.IdProducto
                              select p).FirstOrDefault();
                //precio de compra
                var com = compra.PrecioCompra;
                precio.Precio = com;
                db.Entry(precio).State = EntityState.Modified;
                db.SaveChanges();

                var PV = (from p in db.Producto
                              where p.IdProducto == compra.IdProducto
                              select p).FirstOrDefault();
                //precio de venta
                var VEN =Convert.ToDouble(compra.PrecioVenta);
                precio.PrecioVenta = VEN;
                db.Entry(PV).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", compra.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "NombreProveedor", compra.IdProveedor);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", compra.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "NombreProveedor", compra.IdProveedor);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompra,IdProducto,IdProveedor,PrecioCompra,Cantidad,FechaVencimiento,FechaCompra,Estado,TotalCompra,PrecioVenta")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", compra.IdProducto);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "NombreProveedor", compra.IdProveedor);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compra.Find(id);
            db.Compra.Remove(compra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
