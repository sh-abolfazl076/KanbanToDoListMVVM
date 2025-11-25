// System
using System.Collections.Generic;


// Internal
using KanbanToDoListMVVM.Models.Models;


namespace KanbanToDoListMVVM.Models.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllUsers();
        IEnumerable<Users> FilterUserByUsername(string username);
        bool AddUser(Users user);
        Users GetUserById(int userId);
        Users GetUserByUsernameAndPassword(string username, string password);
        Users GetUserByUsername(string username);
        bool RemoveUserById(int userId);
        bool UpdataUser(Users user);
    }
}
