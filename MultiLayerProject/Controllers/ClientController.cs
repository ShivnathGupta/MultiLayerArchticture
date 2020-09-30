using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiLayerProject.Core.Models;
using MultiLayerProject.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiLayerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
       private IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            return await _clientService.GetAllAsync();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<Client> Get(int id)
        {
            return await _clientService.GetByIdAsync(id);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task Post([FromBody] Client value)
        {
             await  _clientService.AddAsync(value);
        }

        // PUT api/<ClientController>/5
        [HttpPut]
        public void Put(int id, [FromBody] Client value)
        {
             _clientService.Update(value);
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clientService.Remove(id);
        }
    }
}
