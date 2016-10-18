namespace TruckApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TruckApi.Core;
    using TruckApi.Models;

    public class LoadAccess
    {
        private string loadJoinUser = "lo.*, u.* FROM lorryload lo INNER JOIN transporter u ON lo.transporterid = u.tranporterid";

        public List<Dictionary<string, object>> GetAllNotes()
        {
            return DbAccess.DbASelect("SELECT * FROM loadnote");
        }

        public List<Dictionary<string, object>> GetAllLoad()
        {
            return DbAccess.DbASelect("SELECT " + loadJoinUser);
        }

        public List<Dictionary<string, object>> GetLoadBySearch(Load objLoad)
        {
            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where loadid='" + objLoad.loadid + "'");
        }

        public string AddLoad(Load objAddLoad)
        {
            return DbAccess.DbAInsert("insert into lorryload VALUES ('NULL','" + objAddLoad.loadname
            + "', '" + objAddLoad.lto
            + "', '" + objAddLoad.lfrom
            + "', '" + objAddLoad.trucktype
            + "', '" + objAddLoad.fright
            + "', '" + objAddLoad.tone
            + "', '" + objAddLoad.loaddate
            + "', '" + objAddLoad.transporterid
            + "', '" + objAddLoad.vfright
            + "', 'new')");
        }

        public string AddNotes(LoadNote objAddNotes)
        {
            return DbAccess.DbAInsert("insert into loadnote VALUES ('NULL','" + objAddNotes.note
                    + "', '" + objAddNotes.transportername
                    + "', '" + objAddNotes.addeddate
                    + "')");
        }

        public string EditLoad(Load objEditLoad)
        {
            return DbAccess.DbAInsert("UPDATE lorryload SET "
            + "loadname='" + objEditLoad.loadname + "',"
            + "lto='" + objEditLoad.lto + "',"
            + "lfrom='" + objEditLoad.lfrom + "',"
            + "trucktype='" + objEditLoad.trucktype + "',"
            + "fright='" + objEditLoad.fright + "',"
            + "tone='" + objEditLoad.tone + "',"
            + "loadstatus='" + objEditLoad.loadstatus + "',"
            + "loaddate='" + objEditLoad.loaddate + "',"
            + "vfright='" + objEditLoad.vfright + "',"
            + "transporterid='" + objEditLoad.transporterid + "' WHERE loadid=" + objEditLoad.loadid + "");
        }


        ////#region "get"
        ////public List<Dictionary<string, object>> GetAllLoad()
        ////{
        ////    return DbAccess.DbASelect("SELECT * FROM lorryload");
        ////}

        ////public List<Dictionary<string, object>> GetLoadBySearch(Load objLoad)
        ////{
        ////    if (objLoad != null)
        ////    {
        ////        if (objLoad.loadid != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where loadid='" + objLoad.loadid + "'");
        ////        }
        ////        else if (objLoad.ownerid != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where ownerid='" + objLoad.ownerid + "'");
        ////        }
        ////        else if (objLoad.lfrom != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where lfrom LIKE '%" + objLoad.lfrom + "%'");
        ////        }
        ////        else if (objLoad.lto != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where lto LIKE '%" + objLoad.lto + "%'");
        ////        }
        ////        else if (objLoad.ton != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where ton='" + objLoad.ton + "'");
        ////        }
        ////        else if (objLoad.loaditem != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where loaditem LIKE '%" + objLoad.loaditem + "%'");
        ////        }
        ////        else if (objLoad.datearival != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where datearival LIKE '%" + objLoad.datearival + "%'");
        ////        }
        ////        else if (objLoad.datedepature != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where datedepature LIKE '%" + objLoad.datedepature + "%'");
        ////        }
        ////        else if (objLoad.addeddate != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where addeddate LIKE '%" + objLoad.addeddate + "%'");
        ////        }
        ////        else if (objLoad.timearival != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where timearival LIKE '%" + objLoad.timearival + "%'");
        ////        }
        ////        else if (objLoad.timedepature != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where timedepature LIKE '%" + objLoad.timedepature + "%'");
        ////        }
        ////        else if (objLoad.freight != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where freight= '" + objLoad.freight + "'");
        ////        }
        ////        else if (objLoad.status != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where status= '" + objLoad.status + "'");
        ////        }
        ////        else if (objLoad.isalive != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + loadJoinUser + " where isalive= '" + objLoad.isalive + "'");
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
        ////public string AddLoad(Load objAddLoad)
        ////{
        ////    return DbAccess.DbAInsert("insert into lorryload VALUES ('NULL','" + objAddLoad.ownerid
        ////    + "', '" + objAddLoad.lfrom
        ////    + "', '" + objAddLoad.lto
        ////    + "', '" + objAddLoad.ton
        ////    + "', '" + objAddLoad.loaditem
        ////    + "', '" + objAddLoad.datearival
        ////    + "', '" + objAddLoad.datedepature
        ////    + "', '" + objAddLoad.timearival
        ////    + "', '" + objAddLoad.timedepature
        ////    + "', '" + objAddLoad.freight
        ////    + "', '" + objAddLoad.addeddate
        ////    + "', '" + objAddLoad.status
        ////    + "', '1')");
        ////}

        ////public string EditLoad(Load objEditLoad)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE lorryload SET "
        ////    + "ownerid='" + objEditLoad.ownerid + "',"
        ////    + "lfrom='" + objEditLoad.lfrom + "',"
        ////    + "lto='" + objEditLoad.lto + "',"
        ////    + "ton='" + objEditLoad.ton + "',"
        ////    + "loaditem='" + objEditLoad.loaditem + "',"
        ////    + "datearival='" + objEditLoad.datearival + "',"
        ////    + "datedepature='" + objEditLoad.datedepature + "',"
        ////    + "timearival='" + objEditLoad.timearival + "',"
        ////    + "timedepature='" + objEditLoad.timedepature + "',"
        ////    + "freight='" + objEditLoad.freight + "',"
        ////    + "addeddate='" + objEditLoad.addeddate + "',"
        ////    + "status='" + objEditLoad.status + "',"
        ////    + "isalive='1' WHERE loadid=" + objEditLoad.loadid + "");
        ////}

        ////public string DeleteUser(int loadId)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE lorryload SET isalive='2' WHERE loadid='" + loadId + "'");
        ////}
        ////#endregion
    }
}