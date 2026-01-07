// System
namespace KanbanToDoListMVVM.ViewModels.Stores
{
    public interface IApplicationStore
    {
        //static abstract ApplicationStore Instance { get; }
        string DatabaseName { get; }
        string EfConnectionString { get; }
        string PasswordDatabase { get; }
        string ServerName { get; }
        int UserId { get; set; }
        string Username { get; set; }
        string UsernameDatabase { get; }

        void LoadFromFile();
        void SetConnectionInfo(string server, string database, string user, string password);
        bool TestConnection();
    }
}