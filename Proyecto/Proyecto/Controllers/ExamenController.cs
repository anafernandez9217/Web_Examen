using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class ExamenController : Controller
    {
        // GET: Examen
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {

            List<Examen> oLstExamen = new List<Examen>();

            using (DBPRUEBASEntities db = new DBPRUEBASEntities()) {

                oLstExamen = (from p in db.Examen
                               select p).ToList();
            }
            return Json(new { data = oLstExamen }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Obtener(int idexamen) {
            Examen oExamen = new Examen();

            using (DBPRUEBASEntities db = new DBPRUEBASEntities()) {

                oExamen = (from p in db.Examen.Where(x => x.idExamen == idexamen)
                            select p).FirstOrDefault();
            }

            return Json(oExamen, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Examen oExamen) {

            bool respuesta = true;
            try
            {

                if (oExamen.idExamen == 0)
                {
                    using (DBPRUEBASEntities db = new DBPRUEBASEntities())
                    {
                        db.Examen.Add(oExamen);
                        db.SaveChanges();
                    }
                }
                else
                {
                    using (DBPRUEBASEntities db = new DBPRUEBASEntities())
                    {
                        Examen tempExamen = (from p in db.Examen
                                                where p.idExamen == oExamen.idExamen
                                                select p).FirstOrDefault();

                        tempExamen.Nombre = oExamen.Nombre;
                        tempExamen.Descripcion = oExamen.Descripcion;

                        db.SaveChanges();
                    }

                }
            }
            catch {
                respuesta = false;

            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Eliminar(int idexamen)
        {
            bool respuesta = true;
            try
            {
                using (DBPRUEBASEntities db = new DBPRUEBASEntities())
                {
                    Examen oExamen = new Examen();
                    oExamen = (from p in db.Examen.Where(x => x.idExamen == idexamen)
                                select p).FirstOrDefault();

                    db.Examen.Remove(oExamen);

                    db.SaveChanges();
                }
            }
            catch {
                respuesta = false;
            }

            

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


    }
}