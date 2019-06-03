using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Data;
using DAL.Models;

namespace BLL
{
    public class ServiceUser : IServiceUser
    {
        private readonly APIReactContext _manager;

        public ServiceUser(APIReactContext manager)
        {
            _manager = manager;
        }

        public bool Add(User user)
        {
            try
            {


                _manager.Users.Add(user);
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


                User usertodelete = _manager.Users.Find(id);
                _manager.Users.Remove(usertodelete);
                _manager.SaveChanges();
                return true;


            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<User> FindAll()
        {
            try
            {

                return _manager.Users.ToList();

            }
            catch (Exception)
            {

                return null;
            }
        }

        public User FindById(int id)
        {
            try
            {


                return _manager.Users.Find(id);



            }
            catch
            {

                return null;
            }
        }

        public bool Update(User user)
        {
            try
            {


                User usertoupdate = _manager.Users.Find(user.Id);
                _manager.Entry(usertoupdate).CurrentValues.SetValues(user);
                _manager.SaveChanges();
                return true;


            }
            catch
            {

                return false;
            }
        }

        public User Login(string login, string password)
        {
            try
            {
                return _manager.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
