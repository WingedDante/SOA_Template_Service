using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProviderService.data.models;
using ProviderService.data;
using ProviderService.Services;

namespace ProviderService.Controllers
{
    /*
        Your Controllers really only care about handling the HTTP requests, 
        and getting information back from your services to respond with. 
     */

    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        
        private ProvidersService _providerService;
       
        public ProvidersController(ProvidersService providerService )
        {
            _providerService = providerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbuProvider>> Get()
        {
            /*
                get data with _service
                apply _BL
                Return VM
             */
            var providers = _providerService.GetAllProviders();

            if (providers != null)
            {
                return Ok(providers);
            }
            else if (providers.Count() == 0)
            {
                return Ok(providers);
            }
            else
            {
                return Ok(new List<TbuProvider>());
            }


        }

        // POST api/providers
        [HttpPost]
        public ActionResult<IEnumerable<TbuProvider>> Post([FromBody] string name)
        {
            if (name != null && name != "")
            {
                var providers = _providerService.GetProvider(name);

                if (providers != null)
                {
                    return Ok(providers);
                }
                else if (providers.Count() == 0)
                {
                    return Ok(providers);
                }
                else
                {
                    return Ok(new List<TbuProvider>());
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}