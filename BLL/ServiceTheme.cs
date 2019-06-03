using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class ServiceTheme : IServiceTheme
    {
        private readonly APIReactContext _manager;

        public ServiceTheme(APIReactContext manager)
        {
            _manager = manager;
        }

        public bool Add(Theme theme)
        {
            try
            {


                _manager.Themes.Add(theme);
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


                Theme themetodelete = _manager.Themes.Find(id);
                _manager.Themes.Remove(themetodelete);
                _manager.SaveChanges();
                return true;


            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Theme> FindAll()
        {
            try
            {

                return _manager.Themes.ToList();

            }
            catch (Exception)
            {

                return null;
            }
        }

        public Theme FindById(int id)
        {
            try
            {


                return _manager.Themes.Include(x => x.Films).FirstOrDefault(x => x.Id == id);



            }
            catch
            {

                return null;
            }
        }

        public bool Update(Theme theme)
        {
            try
            {


                Theme themetoupdate = _manager.Themes.Find(theme.Id);
                _manager.Entry(themetoupdate).CurrentValues.SetValues(theme);
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
