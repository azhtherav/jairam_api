namespace TruckApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TruckApi.Core;
    using TruckApi.Models;

    public class DriverAccess
    {
        public List<Dictionary<string, object>> GetAllDriver()
        {
            return DbAccess.DbASelect("SELECT * FROM driver where status!='commission'");
        }
        public List<Dictionary<string, object>> GetDriverBySearch(Driver objDriver)
        {
            return DbAccess.DbASelect("SELECT * FROM driver where driverid='" + objDriver.driverid + "'");
        }

        public string AddDriver(Driver objAddDriver)
        {
            return DbAccess.DbAInsert("insert into driver VALUES ('NULL','" + objAddDriver.drivername
            + "', '" + objAddDriver.phoneno
            + "', '" + objAddDriver.licenceno
            + "', '" + objAddDriver.address
            + "', '" + objAddDriver.status + "')");
        }

        public string EditDriver(Driver objEditDriver)
        {
            return DbAccess.DbAInsert("UPDATE driver SET "
            + "drivername='" + objEditDriver.drivername + "',"
            + "phoneno='" + objEditDriver.phoneno + "',"
            + "licenceno='" + objEditDriver.licenceno + "',"
            + "address='" + objEditDriver.address
            + "address='" + objEditDriver.status + "' WHERE driverid=" + objEditDriver.driverid + "");
        }

        ////private string driverJoinUser = "dr.*, u.* FROM driver dr INNER JOIN user u ON dr.ownerid = u.userid";
        ////#region "get"
        ////public List<Dictionary<string, object>> GetAllDriver()
        ////{
        ////    return DbAccess.DbASelect("SELECT * FROM driver");
        ////}

        ////public List<Dictionary<string, object>> GetDriverBySearch(Driver objDriver)
        ////{
        ////    if (objDriver != null)
        ////    {
        ////        if (objDriver.driverid != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + driverJoinUser + " where driverid='" + objDriver.driverid + "'");
        ////        }
        ////        if (objDriver.ownerid != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + driverJoinUser + " where ownerid='" + objDriver.ownerid + "'");
        ////        }
        ////        else if (objDriver.drivername != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + driverJoinUser + " where drivername LIKE '%" + objDriver.drivername + "%'");
        ////        }
        ////        else if (objDriver.licenceno != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + driverJoinUser + " where licenceno LIKE '%" + objDriver.licenceno + "%'");
        ////        }
        ////        else if (objDriver.phoneno != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + driverJoinUser + " where phoneno LIKE '%" + objDriver.phoneno + "%'");
        ////        }
        ////        else if (objDriver.email != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + driverJoinUser + " where email LIKE '%" + objDriver.email + "%'");
        ////        }
        ////        else if (objDriver.address != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + driverJoinUser + " where address LIKE '%" + objDriver.address + "%'");
        ////        }
        ////        else if (objDriver.isalive != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + driverJoinUser + " where isalive= '" + objDriver.isalive + "'");
        ////        }
        ////        else if (objDriver.addeddate != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + driverJoinUser + " where addeddate LIKE '%" + objDriver.addeddate + "%'");
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
        ////public string AddDriver(Driver objAddDriver)
        ////{
        ////    return DbAccess.DbAInsert("insert into driver VALUES ('NULL','" + objAddDriver.drivername
        ////    + "', '" + objAddDriver.ownerid
        ////    + "', '" + objAddDriver.licenceno
        ////    + "', '" + objAddDriver.licencepath
        ////    + "', '" + objAddDriver.phoneno
        ////    + "', '" + objAddDriver.email
        ////    + "', '" + objAddDriver.address
        ////    + "', '" + objAddDriver.addeddate
        ////    + "', '1')");
        ////}

        ////public string EditDriver(Driver objEditDriver)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE driver SET "
        ////    + "drivername='" + objEditDriver.drivername + "',"
        ////    + "ownerid='" + objEditDriver.ownerid + "',"
        ////    + "licenceno='" + objEditDriver.licenceno + "',"
        ////    + "licencepath='" + objEditDriver.licencepath + "',"
        ////    + "email='" + objEditDriver.email + "',"
        ////    + "address='" + objEditDriver.address + "',"
        ////    + "addeddate='" + objEditDriver.addeddate + "',"
        ////    + "islive='1' WHERE driverid=" + objEditDriver.driverid + "");
        ////}

        ////public string DeleteUser(int driverId)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE driver SET islive='2' WHERE driverid='" + driverId + "'");
        ////}
        ////#endregion
    }
}