using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI3.Models;

namespace WebAPI3.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DenemeController : ApiController
    {
        IRepository<DenemeModel> _denemeRepository;

        public DenemeController(IRepository<DenemeModel> DenemeRepository) {
            _denemeRepository = DenemeRepository;
        }

        public IEnumerable<DenemeModel> Get() {
            return _denemeRepository.get_entities();
        }

        public DenemeModel Get(int id) {
            return _denemeRepository.retrieve_entity(id);
        }

        public void Post(DenemeModel model) {
            System.Diagnostics.Debug.WriteLine("helllo");
            _denemeRepository.insert_entity(model);
        }

        public void Put(DenemeModel model, int id) {
            model.ID = id;
            _denemeRepository.update_entity(model);
        }

        public void Delete(int id) {
            _denemeRepository.delete_entity(id);
        }
    }
}
