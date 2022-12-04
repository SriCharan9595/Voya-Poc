using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using poc_voya_entity.Models;
using poc_voya_entity.Services;

namespace poc_voya_entity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController: Controller
    {
        private ICrypto _cryptoServ;

        public CryptoController(ICrypto cryptoServices)
        {
            _cryptoServ = cryptoServices;
        }

        // GET: api/crypto
        [HttpGet]
        public async Task<IActionResult> getAllCrypto()
        {
            var result = await _cryptoServ.getAllCrypto();
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        // GET: api/crypto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> getCryptoByID(int id)
        {
            var result = await _cryptoServ.getCryptoByID(id);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        // PUT: api/crypto/5
        [HttpPut("{id}")]
        public Task updateCrypto(int id, crypto crypto)
        {
            return _cryptoServ.updateCrypto(id, crypto);
        }

        // POST: api/crypto
        [HttpPost]
        public Task createCrypto(crypto crypto)
        {
            return _cryptoServ.createCrypto(crypto);
        }

        // DELETE: api/crypto/5
        [HttpDelete("{id}")]
        public Task deleteCrypto(int id)
        {
            return _cryptoServ.deleteCrypto(id);
        }
    }
}
