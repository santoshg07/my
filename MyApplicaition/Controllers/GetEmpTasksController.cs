using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplicaition.Entities;
using MyApplicaition.Models;

namespace MyApplicaition.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Route("api/GetEmpTasks")]
    [Produces("application/json")]
    [ApiController]
    public class GetEmpTasksController : ControllerBase
    {
        santoshContext db = new santoshContext();
     

        // POST: api/GetEmpTasks/1
        [HttpGet("{id}")]
        public List<task> Get(int id)
        {
            return (from t in db.Tasks where t.Eid == id
                    select new task()
                    {
                        tid = t.Tid,
                        eid = Convert.ToInt32(t.Eid),
                        tname = t.Tname,
                        createdts = Convert.ToDateTime(t.Createdts),
                        lastupdatedby = t.Lastupdatedby,
                    }).ToList();
        }

       
    }
}
