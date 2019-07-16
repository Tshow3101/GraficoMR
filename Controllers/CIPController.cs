using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PANTALLACIP.Models;
using System.Data.SqlClient;
using System.Data;


namespace PANTALLACIP.Controllers
{
    public class CIPController : Controller
    {
        //
        // GET: /CIP/

        public ActionResult Index()
        {
            return View();
        }
        bd_AgviajesEntities modelo = new bd_AgviajesEntities();


        public ActionResult Pantalla1()
        {
            return View(modelo.pantalla());
        }

        public ActionResult Pantalla2()
        {
            return View(modelo.Pantalla2());
        }


        public ActionResult Pantalla3()
        {
            return View(modelo.pantalla3());
        }

        public ActionResult VentaporMes()
        {
            return View(modelo.VENTASPORMES());
        }

        public ActionResult Meta()
        {
            return View(modelo.pantalla());
        }

        public ActionResult MetaNueva()
        {
            return View(modelo.pantalla_facturada());
        }
        public JsonResult SaveDiaAnterior(decimal? monto)
        {
            string connection = "server=52.0.215.100;database=DB_A284C0_admin;uid=sa;pwd=Mund0.R3P2018;";
            string command = "sp_diaanterior";
            bool status = false;

            using (SqlConnection con = new SqlConnection(connection))
            {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@val", monto));
                    cmd.ExecuteNonQuery();

                    status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        public JsonResult GetDiaAnterior()
        {
            string connection = "server=52.0.215.100;database=DB_A284C0_admin;uid=sa;pwd=Mund0.R3P2018;";
            string command = "sp_getdiaanterior";
            decimal result = 0;

            using (SqlConnection con = new SqlConnection(connection))
            {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = Decimal.Parse(reader[0].ToString());
                    }

                    reader.Close();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
