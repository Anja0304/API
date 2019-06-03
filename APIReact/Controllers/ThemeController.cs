using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIReact.Helpers;
using BLL;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIReact.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ThemeController : BaseController
    {
        private readonly IServiceTheme _iServiceTheme;

        public ThemeController(IServiceTheme serviceTheme)

        {
            _iServiceTheme = serviceTheme;
        }

        [HttpGet]
        public IActionResult GetAll()

        {
            try
            {
                List<Theme> List = _iServiceTheme.FindAll();

                return BuildJsonResponse(200, "Success", List);

            }
            catch (Exception e)
            {

                return BuildJsonResponse(500, "Erreur serveur", null, e.Message);
            }

        }
        [HttpPost]
        [ValidateModel]
        public IActionResult Save([FromBody] Theme theme)
        {


            try
            {

                if (_iServiceTheme.Add(theme))
                    return BuildJsonResponse(201, "Theme enregistré", theme);
                else
                    return BuildJsonResponse(400, "Erreur d'enregistrement");


            }
            catch (Exception e)
            {

                return BuildJsonResponse(500, "Erreur serveur", null, e.Message);
            }

        }
        [HttpPut]
        [ValidateModel] //peut être écrit ValidateModelAttribut aussi
        public IActionResult Update([FromBody] Theme theme)
        {


            try
            {

                if (_iServiceTheme.Update(theme))
                    return BuildJsonResponse(201, "Theme enregistré", theme);
                else
                    return BuildJsonResponse(400, "Erreur d'enregistrement");


            }
            catch (Exception e)
            {

                return BuildJsonResponse(500, "Erreur serveur", null, e.Message);
            }

        }

        [HttpDelete("{id}")] // api/user/id dans postman

        public IActionResult Delete(int id) // à partir de l'url et non du body
        {


            try
            {

                if (_iServiceTheme.Delete(id))
                    return BuildJsonResponse(201, "Theme supprimé", id);
                else
                    return BuildJsonResponse(400, "Erreur de suppression");


            }
            catch (Exception e)
            {

                return BuildJsonResponse(500, "Erreur serveur", null, e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)

        {
            try
            {
                Theme theme = _iServiceTheme.FindById(id);

                return BuildJsonResponse(200, "Success", theme);

            }
            catch (Exception e)
            {

                return BuildJsonResponse(500, "Erreur serveur", null, e.Message);
            }

        }


    }
  
}