using Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Sentry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CiudadDollarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationCllientController : ControllerBase
    {
        private readonly IImpuestos _service;
        private readonly IDbConnection _dbConnection;

        public InformationCllientController(IImpuestos client, IDbConnection dbConnection)
        {
            this._service = client;
            this._dbConnection = dbConnection;
        }
        // GET: api/<CalculoController>
        [HttpGet]
        public List<Calculos> Get()
        {
            try
            {

                SentrySdk.CaptureMessage("Exito en consulta", SentryLevel.Info);
                return _service.GetClient(_dbConnection);


            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                SentrySdk.CaptureMessage("Error en la consulta", SentryLevel.Error);
                //return error;
                throw;
            }

        }

    }
}
