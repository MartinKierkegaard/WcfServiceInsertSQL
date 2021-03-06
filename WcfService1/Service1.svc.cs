﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    public class Service1 : IService1
    {
        //Husk at ændre i string så den peger på den rigtige database server, husk a indsætte user+password
        private const string ConnectionString =
          "Server=tcp:easj2016100.database.windows.net,1433;Initial Catalog=HotelDB;Persist Security Info=False;User ID='';Password='';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        /// <summary>
        /// metode til at indsætte data i database på Azure 
        /// </summary>
        /// <param name="request">hvilken request er der tale om</param>
        /// <param name="volume">den udregnede volumen</param>
        /// <param name="length">længden </param>
        /// <param name="width">bredden</param>
        /// <param name="height">højden</param>
        /// <returns>antal rækker der bliver berørt af sql'en (rowsaffected)</returns>
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
