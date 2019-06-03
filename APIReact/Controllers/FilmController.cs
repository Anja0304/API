using System;
using System.Collections.Generic;
using System.Linq;
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
    //[ApiController]
    public class FilmController : BaseController
    {
        private readonly IServiceFilm _iServiceFilm;

        public FilmController(IServiceFilm serviceFilm)

        {
            _iServiceFilm = serviceFilm;
        }

        [HttpGet]
        public IActionResult GetAll()

        {
            try
            {
                List<Film> List = _iServiceFilm.FindAll();

                return BuildJsonResponse(200, "Success", List);

            }
            catch (Exception e)
            {

                return BuildJsonResponse(500, "Erreur serveur", null, e.Message);
            }

        }
        [HttpPost]
        [ValidateModel]
        public IActionResult Save([FromBody] Film film)
        {


            try
            {

                if (_iServiceFilm.Add(film))
                    return BuildJsonResponse(201, "Film enregistré", film);
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
        public IActionResult Update([FromBody] Film film)
        {


            try
            {

                if (_iServiceFilm.Update(film))
                    return BuildJsonResponse(201, "Film enregistré", film);
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

                if (_iServiceFilm.Delete(id))
                    return BuildJsonResponse(201, "Film supprimé", id);
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
                Film film = _iServiceFilm.FindById(id);

                return BuildJsonResponse(200, "Success", film);

            }
            catch (Exception e)
            {

                return BuildJsonResponse(500, "Erreur serveur", null, e.Message);
            }

        }



    }
}