// System
using System;


// Internal
using KanbanToDoListMVVM.Models.Models;


namespace KanbanToDoListMVVM.ViewModels.Stores
{
    public class ApplicationStore
    {
        private static readonly Lazy<ApplicationStore> _instance =
            new Lazy<ApplicationStore>(() => new ApplicationStore());

        public static ApplicationStore Instance => _instance.Value;
        private ApplicationStore() { }

        public string ServerNameDatabase { get; private set; }
        public string DatabaseName { get; private set; }
        public string UsernameDatabase { get; private set; }
        public string PasswordDatabase { get; private set; }




        /// <summary>
        /// Get Info from form connetion
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public void SetConnectionInfo(string server, string database, string user, string password)
        {
            ServerNameDatabase = server;
            DatabaseName = database;
            UsernameDatabase = user;
            PasswordDatabase = password;

        }// End


        // make connection
        public string EfConnectionString =>
            $@"metadata=res://*/Model.KanbanModel.csdl|
        res://*/Model.KanbanModel.ssdl|
        res://*/Model.KanbanModel.msl;
        provider=System.Data.SqlClient;
        provider connection string=""Data Source={ServerNameDatabase};Initial Catalog={DatabaseName};User ID={UsernameDatabase};Password={PasswordDatabase};MultipleActiveResultSets=True;App=EntityFramework""";


        /// <summary>
        /// Text connetion
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
