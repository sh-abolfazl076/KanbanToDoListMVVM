// System
using KanbanToDoListMVVM.Models.Models;
// Internal
using KanbanToDoListMVVM.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace KanbanToDoListMVVM.Models.Services
{
    public class UsersRepository : IUsersRepository
    {
        private KanbanToDoListMVVMEntities db;

        public UsersRepository(KanbanToDoListMVVMEntities context)
        {
            db = context;
        }

        public bool AddUser(Users user)
        {
            try
            {
                db.Users.Add(user);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<Users> FilterUserByUsername(string username)
        {
            return db.Users.Where(f => f.UserName.Contains(username));
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public Users GetUserById(int userId)
        {
            return db.Users.Find(userId);
        }

        public Users GetUserByUsernameAndPassword(string username, string password)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username && u.PassWord == password);
        }

        public Users GetUserByUsername(string username)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username);
        }

        public bool RemoveUserById(int userId)
        {
            try
            {
                var user = GetUserById(userId);
                if (user != null)
                {
                    db.Users.Remove(user);
                    return true;
                }
                return false;
            }
            catch
            {

                return false;
            }
        }

        public bool UpdataUser(Users user)
        {
            try
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
