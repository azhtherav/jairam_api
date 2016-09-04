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

    public class BrokerAccess
    {
        public List<Dictionary<string, object>> GetAllBroker()
        {
            return DbAccess.DbASelect("SELECT * FROM broker");
        }
        public List<Dictionary<string, object>> GetBrokerBySearch(Broker objBroker)
        {
            return DbAccess.DbASelect("SELECT * FROM broker where brokerid='" + objBroker.brokerid + "'");
        }

        public string AddBroker(Broker objAddBroker)
        {
            return DbAccess.DbAInsert("insert into broker VALUES ('NULL', '" + objAddBroker.brokername
            + "', '" + objAddBroker.phone
            + "', '" + objAddBroker.address
            + "', '" + objAddBroker.landline + "')");
        }

        public string EditBroker(Broker objEditBroker)
        {
            return DbAccess.DbAInsert("UPDATE broker SET "
            + "brokername='" + objEditBroker.brokername + "',"
            + "phone='" + objEditBroker.phone + "',"
            + "landline='" + objEditBroker.landline + "',"
            + "address='" + objEditBroker.address + "' WHERE brokerid =" + objEditBroker.brokerid + "");
        }

        public string DeleteBroker(Broker objEditBroker)
        {
            return DbAccess.DbAInsert("Delete from broker WHERE brokerid =" + objEditBroker.brokerid + "");
        }
    }
}