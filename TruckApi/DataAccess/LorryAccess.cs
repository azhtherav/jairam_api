namespace TruckApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TruckApi.Core;
    using TruckApi.Models;

    public class LorryAccess
    {
        public List<Dictionary<string, object>> GetAllLorry()
        {
            return DbAccess.DbASelect("SELECT * FROM lorry ORDER BY vid DESC");
        }

        public List<Dictionary<string, object>> GetAllNotes()
        {
            return DbAccess.DbASelect("SELECT * FROM notes");
        }

        public List<Dictionary<string, object>> GetAllLoadNotes()
        {
            return DbAccess.DbASelect("SELECT * FROM loadnote");
        }

        public List<Dictionary<string, object>> GetNotes(string year, string month)
        {
            return DbAccess.DbASelect("SELECT * FROM notes WHERE YEAR(STR_TO_DATE(addeddate, '%d/%m/%Y')) = " + year + " MONTH(STR_TO_DATE(addeddate, '%d/%m/%Y')) = "+month);
        }

        public List<Dictionary<string, object>> GetLoadNotes(string year, string month)
        {
            return DbAccess.DbASelect("SELECT * FROM loadnote WHERE YEAR(STR_TO_DATE(addeddate, '%d/%m/%Y')) = " + year + " MONTH(STR_TO_DATE(addeddate, '%d/%m/%Y')) = " + month);
        }

        public List<Dictionary<string, object>> GetAllTodayNotes()
        {
            string today = DateTime.Now.ToString("dd/MM/yyyy");
            
            if (today.Contains("-"))
                today = today.Replace("-", "/");
            
            return DbAccess.DbASelect("SELECT * FROM notes where addeddate='" + today + "'");
        }

        public List<Dictionary<string, object>> GetAllTodayLoadNotes()
        {
            string today = DateTime.Now.ToString("dd/MM/yyyy");
            
            if (today.Contains("-"))
                today = today.Replace("-", "/");

            return DbAccess.DbASelect("SELECT * FROM loadnote where addeddate='" + today +"'");
        }

        public List<Dictionary<string, object>> GetLorryBySearch(Lorry objLorry)
        {
            return DbAccess.DbASelect("SELECT * FROM lorry where lorryno='" + objLorry.lorryno + "'");
        }
        public string AddLorry(Lorry objAddLorry)
        {
            return DbAccess.DbAInsert("insert into lorry VALUES ('NULL','" + objAddLorry.lorryno
                    + "', '" + objAddLorry.lorrytype
                    + "', '" + objAddLorry.ophone
                    + "', '" + objAddLorry.dphone
                    + "', '" + objAddLorry.currentcity
                    + "', '" + objAddLorry.designation
                    + "', '" + objAddLorry.contactname
                    + "', '" + objAddLorry.ownername
                    + "', '" + objAddLorry.tone
                    + "', 'empty', '" + objAddLorry.nameboard
                    + "', '" + objAddLorry.updateddate
                    + "', '" + objAddLorry.rc
                    + "', '" + objAddLorry.ins
                    + "', '" + objAddLorry.lorryimage
                    + "', '" + objAddLorry.address
                    + "', '" + objAddLorry.accountno
                    + "', '" + objAddLorry.pancard
                    + "', '" + objAddLorry.accountinfo
                    + "')");
        }

        public string AddNotes(Notes objAddNotes)
        {
            return DbAccess.DbAInsert("insert into notes VALUES ('NULL','" + objAddNotes.note
                    + "', '" + objAddNotes.lorryno
                    + "', '" + objAddNotes.addeddate
                    + "')");
        }

        public string AddLoadNotes(LoadNote objAddLoadNotes)
        {
            return DbAccess.DbAInsert("insert into loadnote VALUES ('NULL','" + objAddLoadNotes.note
                    + "', '" + objAddLoadNotes.transportername
                    + "', '" + objAddLoadNotes.addeddate
                    + "')");
        }


        public string EditLorry(Lorry objEditLorry)
        {
            return DbAccess.DbAInsert("UPDATE lorry SET "
            + "lorrytype='" + objEditLorry.lorrytype + "',"
            + "ophone='" + objEditLorry.ophone + "',"
            + "dphone='" + objEditLorry.dphone + "',"
            + "currentcity='" + objEditLorry.currentcity + "',"
            + "designation='" + objEditLorry.designation + "',"
            + "contactname='" + objEditLorry.contactname + "',"
            + "ownername='" + objEditLorry.ownername + "',"
            + "tone='" + objEditLorry.tone + "',"
            + "status='" + objEditLorry.status + "',"
            + "nameboard='" + objEditLorry.nameboard + "',"
            + "rc='" + objEditLorry.rc + "',"
            + "ins='" + objEditLorry.ins + "',"
            + "address='" + objEditLorry.address + "',"
            + "accountno='" + objEditLorry.accountno + "',"
            + "pancard='" + objEditLorry.pancard + "',"
            + "accountinfo='" + objEditLorry.accountinfo + "',"
            + "lorryimage='" + objEditLorry.lorryimage + "' WHERE lorryno='" + objEditLorry.lorryno + "'");
        }

        public string RcLorry(Lorry objEditLorry)
        {
            return DbAccess.DbAInsert("UPDATE lorry SET rc='" + objEditLorry.rc + "' WHERE lorryno='" + objEditLorry.lorryno + "'");
        }

        public string InsLorry(Lorry objEditLorry)
        {
            return DbAccess.DbAInsert("UPDATE lorry SET ins='" + objEditLorry.ins + "' WHERE lorryno='" + objEditLorry.lorryno + "'");
        }
        public string imageLorry(Lorry objEditLorry)
        {
            return DbAccess.DbAInsert("UPDATE lorry SET lorryimage='" + objEditLorry.lorryimage + "' WHERE lorryno='" + objEditLorry.lorryno + "'");
        }

        ////private string lorryJoinUser = "lo.*, u.* FROM lorry lo INNER JOIN user u ON lo.ownerid = u.userid";

        ////#region "get"
        ////public List<Dictionary<string, object>> GetAllLorry()
        ////{
        ////    return DbAccess.DbASelect("SELECT * FROM lorry");
        ////}

        ////public List<Dictionary<string, object>> GetLorryBySearch(Lorry objLorry)
        ////{
        ////    if (objLorry != null)
        ////    {
        ////        if (objLorry.lorrynumber != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where lorrynumber='" + objLorry.lorrynumber + "'");

        ////        }
        ////        else if (objLorry.ownerid != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where ownerid='" + objLorry.ownerid + "'");
        ////        }
        ////        else if (objLorry.lorrytype != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where lorrytype='" + objLorry.lorrytype + "'");
        ////        }
        ////        else if (objLorry.nameboard != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where nameboard LIKE '%" + objLorry.nameboard + "%'");
        ////        }
        ////        else if (objLorry.native != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where native LIKE '%" + objLorry.native + "%'");
        ////        }
        ////        else if (objLorry.ins_status != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where ins_status= '" + objLorry.ins_status + "'");
        ////        }
        ////        else if (objLorry.rc_status != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where rc_status= '" + objLorry.rc_status + "'");
        ////        }
        ////        else if (objLorry.isalive != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where islive= '" + objLorry.isalive + "'");
        ////        }
        ////        else if (objLorry.status != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where status= '" + objLorry.status + "'");
        ////        }
        ////        else if (objLorry.tone != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where tone= '" + objLorry.tone + "'");
        ////        }
        ////        else if (objLorry.addeddate != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT " + this.lorryJoinUser + " where addeddate LIKE '%" + objLorry.addeddate + "%'");
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
        ////public string AddLorry(Lorry objAddLorry)
        ////{
        ////    return DbAccess.DbAInsert("insert into lorry VALUES ('" + objAddLorry.lorrynumber
        ////    + "', '" + objAddLorry.ownerid
        ////    + "', '" + objAddLorry.lorrytype
        ////    + "', '" + objAddLorry.nameboard
        ////    + "', '" + objAddLorry.native
        ////    + "', '" + objAddLorry.rc_status
        ////    + "', '" + objAddLorry.rc_path
        ////    + "', '" + objAddLorry.ins_status
        ////    + "', '" + objAddLorry.ins_path
        ////    + "', '" + objAddLorry.tone
        ////    + "', '" + objAddLorry.addeddate
        ////    + "', '" + objAddLorry.status
        ////    + "', '1')");
        ////}

        ////public string EditLorry(Lorry objEditLorry)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE lorry SET "
        ////    + "ownerid='" + objEditLorry.ownerid + "',"
        ////    + "nameboard='" + objEditLorry.nameboard + "',"
        ////    + "native='" + objEditLorry.native + "',"
        ////    + "rc_status='" + objEditLorry.rc_status + "',"
        ////    + "rc_path='" + objEditLorry.rc_path + "',"
        ////    + "ins_status='" + objEditLorry.ins_status + "',"
        ////    + "ins_path='" + objEditLorry.ins_path + "',"
        ////    + "tone='" + objEditLorry.tone + "',"
        ////    + "addeddate='" + objEditLorry.addeddate + "',"
        ////    + "status='" + objEditLorry.status + "',"
        ////    + "islive='1' WHERE lorrynumber=" + objEditLorry.lorrynumber + "");
        ////}

        public string DeleteUser(string lorryNumber)
        {
            return DbAccess.DbAInsert("Delete from lorry WHERE lorryno='" + lorryNumber + "' and status='empty'");
        }
        ////#endregion
    }
}