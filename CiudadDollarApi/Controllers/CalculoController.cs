using Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class CalculoController : ControllerBase
    {
        private readonly IImpuestos _service;
        private readonly IDbConnection _dbConnection;
       
        public CalculoController(IImpuestos client, IDbConnection dbConnection)
        {
            this._service = client;
            this._dbConnection = dbConnection;
        }
        [HttpGet]
        public List<Client_Pay> GetOperational()
        {
            try
            {
                SentrySdk.CaptureMessage("Exito en consulta, GetOperational",SentryLevel.Info);
                return _service.GetClientsOperation(_dbConnection);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                SentrySdk.CaptureMessage("Error en la consulta",SentryLevel.Error);
                throw;
            }
            
        }
        // POST api/<CalculoController>
        [HttpPost("ISR")]
        public List<Client_Pay> PostISR(int idClient)
        {
            try
            {
                SentrySdk.CaptureMessage("Exito en Insertar ISR", SentryLevel.Info);
                return _service.ISR(_dbConnection, idClient);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                SentrySdk.CaptureMessage("Error en Insertar ISR", SentryLevel.Error);
                throw;
            }
           
        }

        [HttpPost("IVA")]
        public List<Client_Pay> PostIVA(int idClient)
        {
            try
            {
                SentrySdk.CaptureMessage("Exito en insertar IVA", SentryLevel.Info);
                return _service.IVA(_dbConnection, idClient);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                SentrySdk.CaptureMessage("Error en insertar IVA", SentryLevel.Error);
                throw;
            }
            
        }
        [HttpPost("AHORRO")]
        public List<Client_Pay> PostAHORRO(int idClient)
        {
            try
            {
                SentrySdk.CaptureMessage("Exito en insertar Ahorro", SentryLevel.Info);
                return _service.AHORRO(_dbConnection, idClient);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                SentrySdk.CaptureMessage("Error en insertar Ahorro", SentryLevel.Error);
                throw;
            }
          
        }


    }
}
