using Dapper;
using Interface;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClientOperationService : IImpuestos
    {
        private readonly IDbConnection _dbConnection;
        public ClientOperationService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        #region IMPUESTOS
        public List<Calculos> GetClient(IDbConnection dbConnection)
        {
            return (List<Calculos>)dbConnection.Query<Calculos>("SELECT * FROM VW_impuestos_cliente");
        }
        #endregion
        #region CLIENTE_PAY
        public List<Client_Pay> GetClientsOperation(IDbConnection dbConnection)
        {
            return (List<Client_Pay>)dbConnection.Query<Client_Pay>("SELECT * FROM Client_Pay");
        }
        public Client_Pay GetClientsOperationbyId(IDbConnection dbConnection, int idClient)
        { 
        
            return(Client_Pay)dbConnection.Query < Client_Pay>("SELECT * FROM Client_Pay where idCliente = " + idClient);
           
        }
        #endregion
        #region AHORRO
        public List<Client_Pay> AHORRO(IDbConnection dbConnection, int idClient)
        {
            var client = dbConnection.Query<Calculos>("SELECT * FROM VW_impuestos_cliente WHERE idCliente = " + idClient);
            double AH;
            foreach (var c in client)
            {
                var cantidad = c.Cantidad;
                AH = cantidad * 0.05;
                dbConnection.Query<Client_Pay>("INSERT INTO Client_Pay (idCliente, idRubro, impuesto, descripcion, total)" +
                    " VALUES (" + c.idCliente + "," + c.idRubro + "," + "'AHORRO'" + "," + "'Calculo sobre AHORRO'" + "," + AH + ")");
            }
            return (List<Client_Pay>)dbConnection.Query<Client_Pay>("SELECT * FROM  Client_Pay WHERE idCliente = " + idClient);
        }
        #endregion
        #region ISR
        public List<Client_Pay> ISR(IDbConnection dbConnection, int idClient)
        {
            var client = dbConnection.Query<Calculos>("SELECT * FROM VW_impuestos_cliente WHERE idCliente = " + idClient);
            double ISR;
            foreach (var c in client)
            {
                var cantidad = c.Cantidad;
                if (cantidad <= 30000){ ISR = cantidad * 0.05;}
                else{ISR = cantidad * 0.07;}
                dbConnection.Query<Client_Pay>("INSERT INTO Client_Pay (IdCliente, IdRubro, impuesto, descripcion, total) VALUES ("
                                                    + c.idCliente + "," + c.idRubro + "," + "'ISR'" + "," + "'Calculo impuesto ISR'" + "," + ISR + ")");
            }
            return (List<Client_Pay>)dbConnection.Query<Client_Pay>("SELECT * FROM  Client_Pay WHERE idCliente = " + idClient);
        }
        #endregion
        #region IVA
        public List<Client_Pay> IVA(IDbConnection dbConnection, int idClient)
        {
            var client = dbConnection.Query<Calculos>("SELECT * FROM VW_impuestos_cliente WHERE idCliente = " + idClient);
            double IVA;
            foreach (var c in client)
            {
                var cantidad = c.Cantidad;
                IVA = cantidad * 0.12;
                dbConnection.Query<Client_Pay>("INSERT INTO Client_Pay (IdCliente, IdRubro, impuesto, descripcion, total)" +
                    " VALUES ("  + c.idCliente + "," + c.idRubro + "," + "'IVA'" + "," + "'Calculo impuesto IVA'" + "," + IVA + ")");
            }
            return (List<Client_Pay>)dbConnection.Query<Client_Pay>("SELECT * FROM  Client_Pay WHERE idCliente = " + idClient);
        }
        #endregion
     
    }
}
