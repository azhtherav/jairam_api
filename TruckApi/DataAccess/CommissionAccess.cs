namespace TruckApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TruckApi.Core;
    using TruckApi.Models;
    public class CommissionAccess
    {
        private string commitionJoinUser = "commit.*, lo.*, lory.*, trans.*, dri.* FROM comision commit "+
            "INNER JOIN lorryload lo ON commit.loadid = lo.loadid " +
            "INNER JOIN lorry lory ON commit.lorryno = lory.lorryno " +
            "INNER JOIN driver dri ON commit.driverid = dri.driverid " +
            "INNER JOIN transporter trans ON commit.transportid = trans.tranporterid";

        public List<Dictionary<string, object>> GetAllCommission()
        {
            return DbAccess.DbASelect("SELECT " + commitionJoinUser);
        }

        public List<Dictionary<string, object>> GetAllTooPay()
        {
            return DbAccess.DbASelect("SELECT " + commitionJoinUser+ " where paymentmode='too pay'");
        }

        public List<Dictionary<string, object>> GetAllAdvancePay()
        {
            return DbAccess.DbASelect("SELECT " + commitionJoinUser + " where paymentmode='advance'");
        }

        public List<Dictionary<string, object>> GetCommissionBySearch(Commission objCommission)
        {
            return DbAccess.DbASelect("SELECT " + commitionJoinUser + " where commissionid='" + objCommission.commissionid + "'");
        }

        public List<Dictionary<string, object>> GetSingleCommission(int commissionid)
        {
            return DbAccess.DbASelect("SELECT " + commitionJoinUser + " where commissionid='" + commissionid + "'");
        }

        public List<Dictionary<string, object>> GetNotAckCommission()
        {
            string today= DateTime.Now.ToString("dd/MM/yyyy");

            if (today.Contains("-"))
                today = today.Replace("-", "/");

            return DbAccess.DbASelect("SELECT * FROM  comision WHERE DATEDIFF(DATE_FORMAT(STR_TO_DATE('"+today+"', '%d/%m/%Y'), '%Y-%m-%d'), DATE_FORMAT(STR_TO_DATE(loadingdate, '%d/%m/%Y'), '%Y-%m-%d'))>10 and ackdate=''");
        }

        public List<Dictionary<string, object>> GetBalanceReceivedDateCommission()
        {
            string today = DateTime.Now.ToString("dd/MM/yyyy");
            
            if (today.Contains("-"))
                today = today.Replace("-", "/");

            return DbAccess.DbASelect("SELECT * FROM  comision WHERE DATEDIFF(DATE_FORMAT(STR_TO_DATE('" + today + "', '%d/%m/%Y'), '%Y-%m-%d'), DATE_FORMAT(STR_TO_DATE(ackdate, '%d/%m/%Y'), '%Y-%m-%d'))>2 and amountsentdate=''");
        }

        public List<Dictionary<string, object>> GetBalanceErrorCommission()
        {
            return DbAccess.DbASelect("SELECT * FROM  comision WHERE balanceerrorchecking < 0");
        }

        public List<Dictionary<string, object>> GetAllOpenCommission()
        {
            string today = DateTime.Now.ToString("dd/MM/yyyy");
                        
            if(today.Contains("-"))
                today = today.Replace("-", "/");

            return DbAccess.DbASelect("SELECT * FROM  comision WHERE DATEDIFF(DATE_FORMAT(STR_TO_DATE('" + today + "', '%d/%m/%Y'), '%Y-%m-%d'), DATE_FORMAT(STR_TO_DATE(loadingdate, '%d/%m/%Y'), '%Y-%m-%d'))>13 and commitionstatus = 'open'");
            //return DbAccess.DbASelect("SELECT * FROM  comision WHERE commitionstatus = 'open'");
        }

        public string AddCommission(Commission objAddCommission)
        {

            objAddCommission.commitionstatus = "open";
                       
            string status = DbAccess.DbAInsert("insert into comision VALUES ('NULL', '" + objAddCommission.paymentmode
                + "', '" + objAddCommission.balance
                + "', '" + objAddCommission.advance
                + "', '" + objAddCommission.commitionpercent
                + "', '" + objAddCommission.commition
                + "', '" + objAddCommission.commitionpaid
                + "', '" + objAddCommission.commitionbalance
                + "', '" + objAddCommission.dcommitionpercent
                + "', '" + objAddCommission.dcommition
                + "', '" + objAddCommission.tmamul
                + "', '" + objAddCommission.assignid
                + "', '" + objAddCommission.driverid
                + "', '" + objAddCommission.lorryno
                + "', '" + objAddCommission.loadid
                + "', '" + objAddCommission.transportid
                + "', '" + objAddCommission.commitionstatus
                + "', '" + objAddCommission.commisiondate
                + "', '" + objAddCommission.loadingdate
                + "', '" + objAddCommission.ackmode
                + "', '" + objAddCommission.ackdate
                + "', '" + objAddCommission.extrakm
                + "', '" + objAddCommission.claim
                + "', '" + objAddCommission.totalkuli
                + "', '" + objAddCommission.halting
                + "', '" + objAddCommission.kulideduction
                + "', '" + objAddCommission.grandtotal
                + "', '" + objAddCommission.amountsentdate
                + "', '" + objAddCommission.amountreceived
                + "', '" + objAddCommission.balanceerrorchecking
                + "', '" + objAddCommission.balancereceiveddate
                + "', '" + objAddCommission.paymentcalculation
                + "', '" + objAddCommission.paidin
                + "')");

            if (status == "success")
            {
                DbAccess.DbAInsert("UPDATE lorry SET status='commission' WHERE lorryno='" + objAddCommission.lorryno + "'");
                DbAccess.DbAInsert("UPDATE lorryload SET loadstatus='commission' WHERE loadid='" + objAddCommission.loadid + "'");
                DbAccess.DbAInsert("UPDATE driver SET status='commission' WHERE driverid='" + objAddCommission.driverid + "'");
                return "success";
            }
            else
            {
                return "no added";
            }
        }

        public string EditTooPayCommission(Commission objEditCommission)
        {
           
            return DbAccess.DbAInsert("UPDATE comision SET "
                + "paymentmode='" + objEditCommission.paymentmode + "',"
                + "balance='" + objEditCommission.balance + "',"
                + "advance='" + objEditCommission.advance + "',"
                + "commitionpercent='" + objEditCommission.commitionpercent + "',"
                + "commition='" + objEditCommission.commition + "',"
                + "commitionpaid='" + objEditCommission.commitionpaid + "',"
                + "commitionbalance='" + objEditCommission.commitionbalance + "',"
                + "dcommitionpercent='" + objEditCommission.dcommitionpercent + "',"
                + "dcommition='" + objEditCommission.dcommition + "',"
                + "tmamul='" + objEditCommission.tmamul + "',"
                + "assignid='" + objEditCommission.assignid + "',"
                + "driverid='" + objEditCommission.driverid + "',"
                + "lorryno='" + objEditCommission.lorryno + "',"
                + "loadid='" + objEditCommission.loadid + "',"
                + "transportid='" + objEditCommission.transportid + "',"
                + "commitionstatus='" + objEditCommission.commitionstatus + "',"
                + "commisiondate='" + objEditCommission.commisiondate + "',"
                + "loadingdate='" + objEditCommission.loadingdate + "',"
                + "ackmode='" + objEditCommission.ackmode + "',"
                + "ackdate='" + objEditCommission.ackdate + "',"
                + "extrakm='" + objEditCommission.extrakm + "',"
                + "claim='" + objEditCommission.claim + "',"
                + "totalkuli='" + objEditCommission.totalkuli + "',"
                + "halting='" + objEditCommission.halting + "',"
                + "kulideduction='" + objEditCommission.kulideduction + "',"
                + "grandtotal='" + objEditCommission.grandtotal + "',"
                + "amountsentdate='" + objEditCommission.amountsentdate + "',"
                + "amountreceived='" + objEditCommission.amountreceived + "',"
                + "balanceerrorchecking='" + objEditCommission.balanceerrorchecking + "',"
                + "balancereceiveddate='" + objEditCommission.balancereceiveddate + "',"
                + "paymentcalculation='" + objEditCommission.paymentcalculation + "',"
                + "paidin='" + objEditCommission.paidin + "' WHERE commissionid='" + objEditCommission.commissionid + "'");
        }


        public string EditAdvancePayCommission(Commission objEditCommission)
        {

            return DbAccess.DbAInsert("UPDATE comision SET "
                + "paymentmode='" + objEditCommission.paymentmode + "',"
                + "balance='" + objEditCommission.balance + "',"
                + "advance='" + objEditCommission.advance + "',"
                + "commitionpercent='" + objEditCommission.commitionpercent + "',"
                + "commition='" + objEditCommission.commition + "',"
                + "commitionpaid='" + objEditCommission.commitionpaid + "',"
                + "commitionbalance='" + objEditCommission.commitionbalance + "',"
                + "dcommitionpercent='" + objEditCommission.dcommitionpercent + "',"
                + "dcommition='" + objEditCommission.dcommition + "',"
                + "tmamul='" + objEditCommission.tmamul + "',"
                + "assignid='" + objEditCommission.assignid + "',"
                + "driverid='" + objEditCommission.driverid + "',"
                + "lorryno='" + objEditCommission.lorryno + "',"
                + "loadid='" + objEditCommission.loadid + "',"
                + "transportid='" + objEditCommission.transportid + "',"
                + "commitionstatus='" + objEditCommission.commitionstatus + "',"
                + "commisiondate='" + objEditCommission.commisiondate + "',"
                + "loadingdate='" + objEditCommission.loadingdate + "',"
                + "ackmode='" + objEditCommission.ackmode + "',"
                + "ackdate='" + objEditCommission.ackdate + "',"
                + "extrakm='" + objEditCommission.extrakm + "',"
                + "claim='" + objEditCommission.claim + "',"
                + "totalkuli='" + objEditCommission.totalkuli + "',"
                + "halting='" + objEditCommission.halting + "',"
                + "kulideduction='" + objEditCommission.kulideduction + "',"
                + "grandtotal='" + objEditCommission.grandtotal + "',"
                + "amountsentdate='" + objEditCommission.amountsentdate + "',"
                + "amountreceived='" + objEditCommission.amountreceived + "',"
                + "balanceerrorchecking='" + objEditCommission.balanceerrorchecking + "',"
                + "balancereceiveddate='" + objEditCommission.balancereceiveddate + "',"
                + "paymentcalculation='" + objEditCommission.paymentcalculation + "',"
                + "paidin='" + objEditCommission.paidin + "' WHERE commissionid='" + objEditCommission.commissionid + "'");
        }



        ////#region "get"
        ////public List<Dictionary<string, object>> GetAllCommission()
        ////{
        ////    return DbAccess.DbASelect("SELECT * FROM commissionbill");
        ////}

        ////public List<Dictionary<string, object>> GetCommissionBySearch(Commission objCommission)
        ////{
        ////    if (objCommission != null)
        ////    {
        ////        if (objCommission.commissionid != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM commissionbill where commissionid='" + objCommission.commissionid + "'");
        ////        }
        ////        else if (objCommission.assignid != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM commissionbill where assignid='" + objCommission.assignid + "'");
        ////        }
        ////        else if (objCommission.userid != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM commissionbill where userid='" + objCommission.userid + "'");
        ////        }
        ////        else if (objCommission.loadadvance != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM commissionbill where loadadvance='" + objCommission.loadadvance + "'");
        ////        }
        ////        else if (objCommission.loadbalance != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM commissionbill where loadbalance='" + +objCommission.loadbalance + "'");
        ////        }
        ////        else if (objCommission.commissionstatus != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM commissionbill where commissionstatus= '" + objCommission.commissionstatus + "'");
        ////        }
        ////        else if (objCommission.mamulstatus != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM commissionbill where mamulstatus= '" + objCommission.mamulstatus + "'");
        ////        }
        ////        else if (objCommission.islive != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM commissionbill where islive= '" + objCommission.islive + "'");
        ////        }
        ////        else if (objCommission.status != 0)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM commissionbill where status= '" + objCommission.status + "'");
        ////        }
        ////        else if (objCommission.addeddate != null)
        ////        {
        ////            return DbAccess.DbASelect("SELECT * FROM commissionbill where addeddate LIKE '%" + objCommission.addeddate + "%'");
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
        ////public string AddCommission(Commission objAddCommission)
        ////{
        ////    return DbAccess.DbAInsert("insert into commissionbill VALUES ('NULL', '" + objAddCommission.assignid
        ////    + "', '" + objAddCommission.userid
        ////    + "', '" + objAddCommission.loadadvance
        ////    + "', '" + objAddCommission.loadbalance
        ////    + "', '" + objAddCommission.commissionstatus
        ////    + "', '" + objAddCommission.commissionamount
        ////    + "', '" + objAddCommission.commissionpayed
        ////    + "', '" + objAddCommission.commissionbalance
        ////    + "', '" + objAddCommission.mamulstatus
        ////    + "', '" + objAddCommission.mamulamount
        ////    + "', '" + objAddCommission.mamulpayed
        ////    + "', '" + objAddCommission.mamulbalance
        ////    + "', '" + objAddCommission.addeddate
        ////    + "', '" + objAddCommission.status
        ////    + "', '1')");
        ////}

        ////public string EditCommission(Commission objEditCommission)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE commissionbill SET "
        ////    + "assignid='" + objEditCommission.assignid + "',"
        ////    + "userid='" + objEditCommission.userid + "',"
        ////    + "loadbalance='" + objEditCommission.loadbalance + "',"
        ////    + "commissionstatus='" + objEditCommission.commissionstatus + "',"
        ////    + "commissionamount='" + objEditCommission.commissionamount + "',"
        ////    + "commissionpayed='" + objEditCommission.commissionpayed + "',"
        ////    + "commissionbalance='" + objEditCommission.commissionbalance + "',"
        ////    + "commissionstatus='" + objEditCommission.mamulstatus + "',"
        ////    + "commissionamount='" + objEditCommission.mamulamount + "',"
        ////    + "commissionpayed='" + objEditCommission.mamulpayed + "',"
        ////    + "commissionbalance='" + objEditCommission.mamulbalance + "',"
        ////    + "addeddate='" + objEditCommission.addeddate + "',"
        ////    + "status='" + objEditCommission.status + "',"
        ////    + "islive='1' WHERE commissionid=" + objEditCommission.commissionid + "");
        ////}

        ////public string DeleteUser(int CommissionNumber)
        ////{
        ////    return DbAccess.DbAInsert("UPDATE commissionbill SET islive='2' WHERE commissionid='" + CommissionNumber + "'");
        ////}
        ////#endregion
    }
}