using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        //Husk at ændre i string så den peger på den rigtige database server, husk a indsætte user+password
        private const string ConnectionString =
          "Server=tcp:easj2016100.database.windows.net,1433;Initial Catalog=HotelDB;Persist Security Info=False;User ID='';Password='';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int InsertData(string request, double volume, double length, double width, double height)
        {
            const string sqlstring = "insert into volumen1 (request, volume, length, width, height) " +
                "values (@request, @volume, @length, @width, @height) ";

            //Husk at have connectionstring rigtig
            using (var DBconnection = new SqlConnection(ConnectionString))
            {
                DBconnection.Open();
                using (var sqlcommand = new SqlCommand(sqlstring, DBconnection))
                {
                    sqlcommand.Parameters.AddWithValue("@request", request);
                    sqlcommand.Parameters.AddWithValue("@volume", volume);
                    sqlcommand.Parameters.AddWithValue("@length", length);
                    sqlcommand.Parameters.AddWithValue("@width", width);
                    sqlcommand.Parameters.AddWithValue("@height", height);
                    var rowsaffected = sqlcommand.ExecuteNonQuery();
                    return rowsaffected;
                }
            }
        }

    }
}
