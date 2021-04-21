using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DivisionsController : ApiController
    {
        DivisionRepository divisionRepository = new DivisionRepository();
        public IHttpActionResult Post(Division division)
        {
            var post = divisionRepository.Insert(division);
            return Ok(post);
        }

        public IHttpActionResult Get()
        {
            var get = divisionRepository.GetDivisions();
            return Ok(get);

        }public IHttpActionResult GetById(int id)
        {
            var get = divisionRepository.GetDivisionId(id);
            return Ok(get);
        }

        public IHttpActionResult Delete(int id)
        {
            var delete = divisionRepository.Delete(id);
            return Ok(delete);
            
        }public IHttpActionResult Put(int id, Division division)
        {
            var update = divisionRepository.Update(id, division);
            return Ok(update);
        }
    }
}
