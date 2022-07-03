using Autofac;
using Interface;

using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClient
{
    public class DIModule: Autofac.Module
    {
        string connectionString = "Server=DESKTOP-TM0P2M4\\SQLEXPRESS;Database=CiudadDollar;trusted_Connection=True;";
        protected override void Load(ContainerBuilder builder)
        {
            SqlConnection conn;
         
            builder.RegisterType<ClientService>().As<IImpuestos>().SingleInstance();
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            builder.RegisterInstance<IDbConnection>(conn);
     
          
        }
    }
}
