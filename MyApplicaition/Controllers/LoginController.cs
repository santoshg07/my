using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplicaition.Models;
using MyApplicaition.Entities;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace MyApplicaition.Controllers
{
    //[EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        santoshContext db = new santoshContext();

        // POST: api/Login
        [HttpPost]
        public LoginResponse Post(LoginModel objreq)
        {
            try
            {
                Emp objemp = db.Emp.SingleOrDefault(m => m.EEmailid == objreq.emailid && m.EPassword == objreq.password);

                if (objemp != null)
                {
                    emp emp = new emp();
                    emp.ename = objemp.EName;
                    emp.epassword = objemp.EPassword;
                    emp.eage = Convert.ToInt32(objemp.EAge);
                    emp.esalary = Convert.ToDouble(objemp.ESalary);
                    emp.edateofjoining = Convert.ToDateTime(objemp.EDateofjoining);
                    emp.ecreatedby = objemp.ECreatedby;
                    emp.ecreatedts = Convert.ToDateTime(objemp.ECreatedts);
                    emp.edateofjoining = Convert.ToDateTime(objemp.EDateofjoining);
                    emp.elastupdatedby = objemp.ELastupdatedby;
                    emp.elastupdatets = Convert.ToDateTime(objemp.ELastupdatedts);

                    LoginResponse objresp = new LoginResponse();
                    objresp.Status = "200";
                    objresp.Description = JsonConvert.SerializeObject(emp);
                    return objresp;

                }

                else
                {
                    LoginResponse objresp = new LoginResponse();
                    objresp.Status = "200";
                    objresp.Description = "Invalid EmailId/PasssWord";
                    return objresp;
                }
            }
            catch (Exception ex)
            {
                LoginResponse objresp = new LoginResponse();
                objresp.Status = "200";
                objresp.Description = "Something Went Wrong Please try Again Later";
                return objresp;
            }
        }
    }
}
