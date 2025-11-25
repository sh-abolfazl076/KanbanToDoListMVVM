// System
using System;

// Internal
using KanbanToDoListMVVM.Models.Models;
using KanbanToDoListMVVM.Models.Repository;
using KanbanToDoListMVVM.Models.Services;


namespace KanbanToDoListMVVM.Models.Context
{
    public class UnitOfWork : IDisposable
    {
        private KanbanToDoListMVVMEntities db;

        public UnitOfWork(string connectionString)
        {
            db = new KanbanToDoListMVVMEntities(connectionString);
        }

        private IUsersRepository _usersRepository;
        public IUsersRepository UsersRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new UsersRepository(db);
                }
                return _usersRepository;
            }
        }// End

        private ITasksRepository _tasksRepository;
        public ITasksRepository TasksRepository
        {
            get
            {
                if (_tasksRepository == null)
                {
                    _tasksRepository = new TasksRepository(db);
                }
                return _tasksRepository;
            }
        }// End

        private IUserPermissionsRepository _userPermissionsRepository;
        public IUserPermissionsRepository UserPermissionsRepository
        {
            get
            {
                if (_userPermissionsRepository == null)
                {
                    _userPermissionsRepository = new UserPermissionsRepository(db);
                }
                return _userPermissionsRepository;
            }
        }// End

        private IPermissionsRepository _PermissionsRepository;
        public IPermissionsRepository PermissionsRepository
        {
            get
            {
                if (_PermissionsRepository == null)
                {
                    _PermissionsRepository = new PermissionsRepository(db);
                }
                return _PermissionsRepository;
            }
        }// End



        //
        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
        //
    }
}
