using System;
using System.Collections.Generic;

using Models.Models;

namespace Interface
{
    public interface IClient
    {
        Client  GetClients();
        List<Client> GetClients(System.Data.IDbConnection dbConnection);

    }
}
