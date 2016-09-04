namespace TruckApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TruckApi.Core;
    using TruckApi.Models;
    public class AssignAccess
    {
        private string assignJoinUser = "assig.*, lo.*, lory.*,trans.* FROM assign assig INNER JOIN lorryload lo ON assig.loadid = lo.loadid " +
        "INNER JOIN lorry lory ON assig.lorryno = lory.lorryno "+
        "INNER JOIN transporter trans ON assig.transpoterid = trans.tranporterid";

        public List<Dictionary<string, object>> GetAllAssign()
        {
            return DbAccess.DbASelect("SELECT " + assignJoinUser);
        }

        public List<Dictionary<string, object>> GetAssignBySearch(Assign objAssign)
        {
            return DbAccess.DbASelect("SELECT " + assignJoinUser + " where assignid='" + objAssign.assignid + "'");
        }

        public string AddAssign(Assign objAddAssign)
        {
            string status = DbAccess.DbAInsert("insert into assign VALUES ('NULL','" + objAddAssign.lorryno
             + "', '" + objAddAssign.loadid + "', '" + objAddAssign.transpoterid + "', '" + objAddAssign.assigndate + "')");

            if (status == "success")
            {
                DbAccess.DbAInsert("UPDATE lorry SET status='loadregister' WHERE lorryno='" + objAddAssign.lorryno + "'");
                DbAccess.DbAInsert("UPDATE lorryload SET loadstatus='loadregister' WHERE loadid='" + objAddAssign.loadid + "'");
                return "success";
            }
            else
            {
                return "no added";
            }
        }

        public string EditAssign(Assign objEditAssign)
        {
            return DbAccess.DbAInsert("UPDATE assignload SET "
            + "loadid='" + objEditAssign.loadid + "',"
            + "lorryno='" + objEditAssign.lorryno + "' WHERE assignid=" + objEditAssign.assignid + "");
        }

        ////#region "get"
        ////public List<Dictionary<string, object>> GetAllAssign()
        ////{
        ////    return DbAccess.DbASelect("SELECT * FROM assignload");
        ////}

        ////public List<Dictionary<string, object>> GetAssignBySearch(Assign objAssign)
        ////{
        ////    if (objAssign != null)
        ////    {
        ////        if (objAssign.assignid != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + assignJoinUser + " where assignid='" + objAssign.assignid + "'");
        ////        }
        ////        if (objAssign.loadid != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + assignJoinUser + " where loadid='" + objAssign.loadid + "'");
        ////        }
        ////        else if (objAssign.commissiontype != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + assignJoinUser + " where commissiontype='" + objAssign.commissiontype + "'");
        ////        }
        ////        else if (objAssign.lorryno != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + assignJoinUser + " where lorryno LIKE '%" + objAssign.lorryno + "%'");
        ////        }
        ////        else if (objAssign.addeddate != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + assignJoinUser + " where addeddate LIKE '%" + objAssign.addeddate + "%'");
        ////        }
        ////        else if (objAssign.status != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + assignJoinUser + " where status= '" + objAssign.status + "'");
        ////        }
        ////        else if (objAssign.isalive != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + assignJoinUser + " where islive= '" + objAssign.isalive + "'");
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
        ////public string AddAssign(Assign objAddAssign)
        ////{
        ////    string status = DbAccess.DbAInsert("insert into assignload VALUES ('NULL','" + objAddAssign.loadid
        ////     + "', '" + objAddAssign.lorryno
        ////     + "', '" + objAddAssign.commissiontype
        ////     + "', '" + objAddAssign.addeddate
        ////     + "', '" + objAddAssign.status
        ////     + "', '1')");

        ////    if (status == "success")
        ////    {
        ////        DbAccess.DbAInsert("UPDATE lorry SET status='2' WHERE lorrynumber='" + objAddAssign.lorryno + "'");
        ////        DbAccess.DbAInsert("UPDATE lorryload SET status='2' WHERE loadid='" + objAddAssign.loadid + "'");
        ////        return "success";
        ////    }
        ////    else
        ////    {
        ////        return "no added";
        ////    }
        ////}

        ////public string EditAssign(Assign objEditAssign)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE assignload SET "
        ////    + "loadid='" + objEditAssign.loadid + "',"
        ////    + "lorryno='" + objEditAssign.lorryno + "',"
        ////    + "commissiontype='" + objEditAssign.commissiontype + "',"
        ////    + "addeddate='" + objEditAssign.addeddate + "',"
        ////    + "status='" + objEditAssign.status + "',"
        ////    + "islive='1' WHERE assignid=" + objEditAssign.assignid + "");
        ////}

        ////public string DeleteUser(int AssignId)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE assignload SET islive='2' WHERE assignid='" + AssignId + "'");
        ////}
        ////#endregion
    }
}