using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsuarioPass.AccesoDatos;
using UsuarioPass.Models;

namespace UsuarioPass.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult AltaPersona()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaPersona(Persona model)
        {
            if(ModelState.IsValid)
            {
              bool resultado= AD_Personas.InsertarNuevaPersona(model);

               if(resultado)
                {
                    return RedirectToAction("ListadoPersonas", "Persona");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }


        public ActionResult listadoPersonas()
        {
            List<Persona> lista = AD_Personas.ObtenerPersonas();
            return View(lista);
        }

        public ActionResult DatosPesona(int idPersona)
        {
            Persona resultado = AD_Personas.ObtenerPersona(idPersona);

            return View(resultado);
        }
    }
}