namespace TruckApi.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TruckApi.DataAccess;
    using TruckApi.Models;

    public class UserService
    {

        private UserAccess objUserAccess;

        public UserService()
        {
            this.objUserAccess = new UserAccess();
        }

        public List<Dictionary<string, object>> GetAllUser()
        {
            return this.objUserAccess.GetAllUser();
        }

        public List<Dictionary<string, object>> GetUserById(uint userId)
        {
            return objUserAccess.GetUserById(userId);
        }

        public List<Dictionary<string, object>> GetUserBySearch(User objUser)
        {
            return this.objUserAccess.GetUserBySearch(objUser);
        }

        public string AddUser(User objAddUser)
        {
            return this.objUserAccess.AddUser(objAddUser);
        }

        public string EditUser(User objEditUser)
        {
            return this.objUserAccess.EditUser(objEditUser);
        }

        public string DeleteUser(uint userId)
        {
            return this.objUserAccess.DeleteUser(userId);
        }
    }
}