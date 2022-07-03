using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IImpuestos : IIVA, IISR, IAhorro, ICalculoClientes
    {

    }

    public interface IIVA
    {
        List<Client_Pay> IVA(System.Data.IDbConnection dbConnection, int idClient);
    }

    public interface IISR
    {
        List<Client_Pay> ISR(System.Data.IDbConnection dbConnection, int idClient);
    }

    public interface IAhorro
    {
        List<Client_Pay> AHORRO(System.Data.IDbConnection dbConnection, int idClient);
    }
    public interface ICalculoClientes
    {
        List<Calculos> GetClient(System.Data.IDbConnection dbConnection);
        List<Client_Pay> GetClientsOperation (System.Data.IDbConnection dbConnection);
        Client_Pay GetClientsOperationbyId(System.Data.IDbConnection dbConnection, int idClient);
    }
}

