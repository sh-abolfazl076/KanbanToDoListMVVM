// System
using System;
using System.IO;
using Newtonsoft.Json;

// Internal
using KanbanToDoListMVVM.Models.Models;


namespace KanbanToDoListMVVM.ViewModels.Stores
{
    public class ApplicationStore : IApplicationStore
    {
        //private static readonly string filePath = "connection.json";

        private static readonly Lazy<ApplicationStore> _instance =
            new Lazy<ApplicationStore>(() => new ApplicationStore());

        public static ApplicationStore Instance => _instance.Value;
        private ApplicationStore() { }

        public string ServerName { get; private set; }
        public string DatabaseName { get; private set; }
        public string UsernameDatabase { get; private set; }
        public string PasswordDatabase { get; private set; }

        public string Username { get; set; }
        public int UserId { get; set; }




        /// <summary>
        /// Save connection info from the form (server, database, username, password)
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public void SetConnectionInfo(string server, string database, string user, string password)
        {
            ServerName = server;
            DatabaseName = database;
            UsernameDatabase = user;
            PasswordDatabase = password;
            SaveToFile();

        }// End

        /// <summary>
        /// Save connection info from the form (server, database, username, password)
        /// </summary>
        public void LoadFromFile()
        {
            if (File.Exists("connection.json"))
            {
                string json = File.ReadAllText("connection.json");
                var info = JsonConvert.DeserializeObject<ConnectionInfo>(json);
                if (info != null)
                {
                    ServerName = info.Server;
                    DatabaseName = info.Database;
                    UsernameDatabase = info.Username;
                    PasswordDatabase = info.Password;
                }
            }
        }//End

        /// <summary>
        /// Save the connection info into connection.json file.
        /// </summary>
        private void SaveToFile()
        {
            var info = new ConnectionInfo
            {
                Server = ServerName,
                Database = DatabaseName,
                Username = UsernameDatabase,
                Password = PasswordDatabase
            };

            string json = JsonConvert.SerializeObject(info, Formatting.Indented);
            File.WriteAllText("connection.json", json);
        }//End


        // Creates and returns the Entity Framework connection string
        public string EfConnectionString =>
                $@"metadata=res://*/Models.ToDoListModel.csdl|
            res://*/Models.ToDoListModel.ssdl|
            res://*/Models.ToDoListModel.msl;
            provider=System.Data.SqlClient;
            provider connection string=""Data Source={ServerName};Initial Catalog={DatabaseName};User ID={UsernameDatabase};Password={PasswordDatabase};MultipleActiveResultSets=True;App=EntityFramework""";


        /// <summary>
        /// Test the database connection.
        /// </summary>
        /// <returns></returns>
        public bool TestConnection()
        {
            try
            {
                using (var ctx = new KanbanToDoListMVVMEntities(EfConnectionString))
                {
                    ctx.Database.Connection.Open();
                    ctx.Database.Connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }// End
    }
}
