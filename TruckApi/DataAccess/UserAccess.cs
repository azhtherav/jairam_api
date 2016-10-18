namespace TruckApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using MySql.Data.MySqlClient;
    using TruckApi.Core;
    using TruckApi.Models;

    public class UserAccess
    {
        public List<Dictionary<string, object>> GetAllUser()
        {
            return DbAccess.DbASelect("SELECT * FROM transporter");
        }
        public List<Dictionary<string, object>> GetUserBySearch(User objUser)
        {
            return DbAccess.DbASelect("SELECT * FROM transporter where tranporterid='" + objUser.tranporterid + "'");
        }

        public string AddUser(User objAddUser)
        {
            return DbAccess.DbAInsert("insert into transporter VALUES ('NULL', '" + objAddUser.transportername
            + "', '" + objAddUser.transporterphone
            + "', '" + objAddUser.address
            + "', '" + objAddUser.landline
            + "', '" + objAddUser.area
            + "', '" + objAddUser.accountno + "')");
        }

        public string EditUser(User objEditUser)
        {
            return DbAccess.DbAInsert("UPDATE transporter SET "
            + "transportername='" + objEditUser.transportername + "',"
            + "transporterphone='" + objEditUser.transporterphone + "',"
            + "landline='" + objEditUser.landline + "',"
            + "area='" + objEditUser.area + "',"
            + "accountno='" + objEditUser.accountno + "',"
            + "address='" + objEditUser.address + "' WHERE tranporterid=" + objEditUser.tranporterid + "");
        }
        ////#region "get"
        ////public List<Dictionary<string, object>> GetAllUser()
        ////{
        ////    return DbAccess.DbASelect("SELECT * FROM user");
        ////}

        ////public List<Dictionary<string, object>> GetUserBySearch(User objUser)
        ////{

        ////    if (objUser != null)
        ////    {
        ////        if (objUser.UserId != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where userid='" + objUser.UserId + "'");
        ////        }
        ////        else if (objUser.UserName != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where username LIKE '%" + objUser.UserName + "%'");
        ////        }
        ////        else if (objUser.UserTypeId != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where usertypeid='" + objUser.UserTypeId + "'");
        ////        }
        ////        else if (objUser.PhoneNo != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where phoneno LIKE '%" + objUser.PhoneNo + "%'");
        ////        }
        ////        else if (objUser.Email != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where email LIKE '%" + objUser.Email + "%'");
        ////        }
        ////        else if (objUser.Address != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where address LIKE '%" + objUser.Address + "%'");
        ////        }
        ////        else if (objUser.city != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where city='" +objUser.city + "'");
        ////        }
        ////        else if (objUser.state != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where state='" +objUser.state + "'");
        ////        }
        ////        else if (objUser.CellNo != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where cellno LIKE '%" + objUser.CellNo + "%'");
        ////        }
        ////        else if (objUser.IsLive != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where islive= '" + objUser.IsLive + "'");
        ////        }
        ////        else if (objUser.AddedDate != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where addeddate LIKE '%" + objUser.AddedDate + "%'");
        ////        }
        ////        else if (objUser.licenceno != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM user where licenceno LIKE '%" + objUser.licenceno + "%'");
        ////        }
        ////        else
        ////        {
        ////            throw new NotImplementedException("no data");
        ////        }
        ////    }
        ////    else
        ////    {
        ////        throw new NotImplementedException("no data");
        ////    }
        ////}

        ////#endregion

        ////#region "post"
        ////public string AddUser(User objAddUser)
        ////{
        ////    return DbAccess.DbAInsert("insert into user VALUES ('NULL', '" + objAddUser.UserName
        ////    + "', '" + objAddUser.UserTypeId
        ////    + "', '" + objAddUser.PhoneNo
        ////    + "', '" + objAddUser.CellNo
        ////    + "', '" + objAddUser.Email
        ////    + "', '" + objAddUser.Address
        ////    + "', '" + objAddUser.city
        ////    + "', '" + objAddUser.state
        ////    + "', '" + objAddUser.country
        ////    + "', '" + objAddUser.pincode
        ////    + "', '" + objAddUser.CompanyName
        ////    + "', '" + objAddUser.ContactName
        ////    + "', '" + objAddUser.AddedDate
        ////    + "', '1')");
        ////}

        ////public string EditUser(User objEditUser)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE user SET "
        ////    + "username='" + objEditUser.UserName + "',"
        ////    + "usertypeid='" + objEditUser.UserTypeId + "',"
        ////    + "phoneno='" + objEditUser.PhoneNo + "',"
        ////    + "cellno='" + objEditUser.CellNo + "',"
        ////    + "email='" + objEditUser.Email + "',"
        ////    + "address='" + objEditUser.Address + "',"
        ////    + "city='" + objEditUser.city + "',"
        ////    + "state='" + objEditUser.state + "',"
        ////    + "country='" + objEditUser.country + "',"
        ////    + "pincode='" + objEditUser.pincode + "',"
        ////    + "companyname='" + objEditUser.CompanyName + "',"
        ////    + "contactname='" + objEditUser.ContactName + "',"
        ////    + "addeddate='" + objEditUser.AddedDate + "',"
        ////    + "islive='1' WHERE userid=" + objEditUser.UserId + "");
        ////}

        ////public string DeleteUser(int userId)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE user SET islive='2' WHERE userid='" + userId + "'");
        ////}
        ////#endregion
    }
}