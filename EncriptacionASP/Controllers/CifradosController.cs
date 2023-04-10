using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;

namespace MvcCoreUtilidades.Controllers
{
    public class CifradosController : Controller
{   
    public IActionResult Encriptacion()
        {
            return View();
        }

    [HttpPost]
    public IActionResult Encriptacion
            (string contenido, string resultado, string accion)
        {
            if(accion.ToLower() == "cifrar")
            {
                //LO QUE HAREMOS SERA GUARDAR EL SALT GENERADO
                string response =
                    HelperCryptography.EncriptarContenido(contenido, false);
                ViewData["TEXTOCIFRADO"] = response;
                ViewData["CONTENIDO"] = contenido;

            }else if (accion.ToLower() == "comparar")
            {
                string response =
                    HelperCryptography.EncriptarContenido(contenido, true);
                if(response != resultado)
                {
                    ViewData["MENSAJE"] = "<h1 style ='color:white'>NO SON IGUALES </h1> ";

                }
                else
                {
                    ViewData["MENSAJE"] = "<h1 style ='color:white'>SON IGUALES </h1> ";
                }
            }


            return View();
        }
    

    
}

}
