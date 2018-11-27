using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplicaition.Entities;
using MyApplicaition.Models;

namespace MyApplicaition.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Route("api/emp")]
    [Produces("application/json")]
    [ApiController]
    public class empController : ControllerBase
    {
        santoshContext db = new santoshContext();

        // GET: api/emp
        [HttpGet]
        public List<emp> Get()
        {
            return (from e in db.Emp
                    select new emp()
                    {
                        eid = e.EId,
                        ename = e.EName,
                        eage = Convert.ToInt32(e.EAge),
                        esalary = Convert.ToDouble(e.ESalary),
                        edateofjoining = Convert.ToDateTime(e.EDateofjoining),
                        ecreatedby = e.ECreatedby,
                        ecreatedts = Convert.ToDateTime(e.ECreatedts),
                        elastupdatedby = e.ELastupdatedby,
                        elastupdatets = Convert.ToDateTime(e.ELastupdatedts),
                        epassword = e.EPassword
                    }).ToList();
        }

        // GET: api/emp/5
        [HttpGet("{id}")]
        public emp Get(int id)
        {
            return (from e in db.Emp
                    select new emp()
                    {
                        eid = e.EId,
                        ename = e.EName,
                        eage = Convert.ToInt32(e.EAge),
                        esalary = Convert.ToDouble(e.ESalary),
                        edateofjoining = Convert.ToDateTime(e.EDateofjoining),
                        ecreatedby = e.ECreatedby,
                        ecreatedts = Convert.ToDateTime(e.ECreatedts),
                        elastupdatedby = e.ELastupdatedby,
                        elastupdatets = Convert.ToDateTime(e.ELastupdatedts),
                        epassword = e.EPassword
                    }).SingleOrDefault(e=>e.eid==id);
        }

        // POST: api/emp
        [HttpPost]
        public void Postdata(emp emp)
        {
            Emp objemp = new Emp();
            objemp.EName = emp.ename;
            objemp.EPassword = emp.epassword;
            objemp.EAge = emp.eage;
            objemp.ESalary = emp.esalary;
            objemp.EDateofjoining = emp.edateofjoining;
            objemp.ECreatedby = emp.ecreatedby;
            objemp.ECreatedts = emp.ecreatedts;
            //objemp.EDateofjoining = emp.edateofjoining;
            objemp.ELastupdatedby = emp.elastupdatedby;
            objemp.ELastupdatedts = emp.elastupdatets;
            objemp.EEmailid = emp.eemailid;
            db.Emp.Add(objemp);
            db.SaveChanges();
        }

        // PUT: api/emp/5
        [HttpPut("{id}")]
        public void Put(int id,emp emp)
        {
            Emp objemp = db.Emp.SingleOrDefault(m => m.EId ==emp.eid);

            objemp.EName = emp.ename;
            objemp.EPassword = emp.epassword;
            objemp.EAge = emp.eage;
            objemp.ESalary = emp.esalary;
            objemp.EDateofjoining = emp.edateofjoining;
            objemp.ECreatedby = emp.ecreatedby;
            objemp.ECreatedts = emp.ecreatedts;
            objemp.EDateofjoining = emp.edateofjoining;
            objemp.ELastupdatedby = emp.elastupdatedby;
            objemp.ELastupdatedts = emp.elastupdatets;
            objemp.EEmailid = emp.eemailid;
            db.Emp.Add(objemp);
            db.SaveChanges();


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            var x = (from e in db.Emp
                     where e.EId == id
                     select e).FirstOrDefault();
            db.Emp.Remove(x);
            db.SaveChanges();

        }
    }
}
