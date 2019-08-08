using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    public class DenemeController : ApiController
    {

        IRepository<DenemeModel> _DenemeRepository;

        public DenemeController(IRepository<DenemeModel> DenemeRepository) {
            _DenemeRepository = DenemeRepository;
            

        }
        // GET: api/Deneme
        public string Get()
        {
            return "hello world";
        }

        // GET: api/Deneme/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Deneme
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Deneme/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Deneme/5
        public void Delete(int id)
        {
        }
    }
}
