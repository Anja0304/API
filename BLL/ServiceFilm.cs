using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class ServiceFilm : IServiceFilm
    {
        private readonly APIReactContext _manager;

        public ServiceFilm(APIReactContext manager)
        {
            _manager = manager;
        }

        public bool Add(Film film)
        {
            try
            {


                _manager.Films.Add(film);
                _manager.SaveChanges();
                return true;


            }
            catch
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {


                Film filmtodelete = _manager.Films.Find(id);
                _manager.Films.Remove(filmtodelete);
                _manager.SaveChanges();
                return true;


            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Film> FindAll()
        {
            try
            {

                return _manager.Films.ToList();

            }
            catch (Exception)
            {

                return null;
            }
        }

        public Film FindById(int id)
        {
            try
            {


                return _manager.Films.Include(x=>x.Theme).FirstOrDefault(x=>x.Id == id);



            }
            catch
            {

                return null;
            }
        }

        public bool Update(Film film)
        {
            try
            {


                Film filmtoupdate = _manager.Films.Find(film.Id);
                _manager.Entry(filmtoupdate).CurrentValues.SetValues(film);
                _manager.SaveChanges();
                return true;


            }
            catch
            {

                return false;
            }
        }
    }
}
