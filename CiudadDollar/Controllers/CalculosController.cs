using Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CiudadDollar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculosController : ControllerBase
    {
        private readonly IImpuestos _service;
        private readonly IDbConnection _dbConnection;
        public CalculosController(IImpuestos lugar, IDbConnection dbConnection)
        {
            this._service = lugar;
            this._dbConnection = dbConnection;
        }

        // GET: api/<CalculosController>
        [HttpGet]
        public List<Calculos> Get()
        {
            return _service.GetCalculo(_dbConnection);
        }


        // GET api/<CalculosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CalculosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CalculosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CalculosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
