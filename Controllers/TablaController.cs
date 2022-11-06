using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPracticaDCL.Models;
using WebAppPracticaDCL.Models.ViewModels;

namespace WebAppPracticaDCL.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (CrudEntities db = new CrudEntities())
            {
             lst= (from d in db.tabla
                      select new ListTablaViewModel
                      {
                      Id=d.id,
                      Nombre=d.nombre,
                      Fecha_Nacimiento=d.fecha_nacimiento,
                      Correo=d.correo,
                      }).ToList();
            }
                return View(lst);
        }
        public ActionResult Nuevo() 
        {
        return View();
        }
        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = new tabla();
                        oTabla.correo = model.Correo;
                        oTabla.fecha_nacimiento = model.Fecha_Nacimiento;
                        oTabla.nombre = model.Nombre;

                        db.tabla.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("/");
                }

                return View(model);

            }
            catch (Exception ex)
            {
            throw new Exception(ex.Message);
            }
        }
    }
}