using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
   public interface IClient_Pay
    {
        IClient_Pay GetClient_Pay();
        List<IClient_Pay> GetClients(System.Data.IDbConnection dbConnection);

   }
    public interface IIVA
    {
        double IVA(System.Data.IDbConnection dbConnection, int idClient);
    }

    public interface IISR
    {
        double ISR(System.Data.IDbConnection dbConnection, int idClient);
    }

    public interface IAhorro
    {
        double AHORRO(System.Data.IDbConnection dbConnection, int idClient);
    }
}
