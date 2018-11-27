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
    [Route("api/task")]
    [Produces("application/json")]
    [ApiController]
    public class taskController : ControllerBase
    {
        santoshContext db = new santoshContext();

        // GET: api/task
        [HttpGet]
        public List<task> Get()
        {
            return (from t in db.Tasks
                    select new task()
                    {
                        tid = t.Tid,
                        eid = Convert.ToInt32(t.Eid),
                        tname = t.Tname,
                        createdts = Convert.ToDateTime(t.Createdts),
                        lastupdatedby = t.Lastupdatedby,
                    }).ToList();
        }

        // GET: api/task/5
        [HttpGet("{id}")]
        public task Get(int id)
        {

            Tasks objtsk= db.Tasks.SingleOrDefault(t => t.Tid == id);

            task objtask = new task();
            if (objtsk!=null)
            {
                objtask.tid = id;
                objtask.eid = Convert.ToInt32(objtsk.Eid);
                objtask.tname = objtsk.Tname;
                objtask.createdts = Convert.ToDateTime(objtsk.Createdts);
                objtask.lastupdatedby = objtsk.Lastupdatedby;
                
            }
            return objtask;
        }

        // POST: api/task
        [HttpPost]
        public void Post(task task)
        {
            Tasks objtsk = new Tasks();
            objtsk.Eid = task.eid;
            objtsk.Tname = task.tname;
            objtsk.Createdts = task.createdts;
            objtsk.Lastupdatedby = task.lastupdatedby;
            db.Tasks.Add(objtsk);
            db.SaveChanges();
        }

        // PUT: api/task/5
        [HttpPut("{id}")]
        public void Put(int id, task task)
        {
            Tasks objtsk = db.Tasks.SingleOrDefault(t => t.Tid == id);
            objtsk.Eid = task.eid;
            objtsk.Tname = task.tname;
            objtsk.Createdts = task.createdts;
            objtsk.Lastupdatedby = task.lastupdatedby;
            db.Tasks.Add(objtsk);
            db.SaveChanges();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var x = (from t in db.Tasks
                     where t.Tid == id
                     select t).FirstOrDefault();
            db.Tasks.Remove(x);
            db.SaveChanges();
        }




    }
}
