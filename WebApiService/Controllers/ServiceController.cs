using Ninject;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

[assembly:log4net.Config.XmlConfigurator(Watch =true)]

namespace WebApiService.Controllers
{
    
    [CustomExceptionFilter]
    
    [RoutePrefix("api/service")]
    public class ServiceController : ApiController
    {
        //public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
        IUserService<UserExtended> svc;
        public ServiceController(IUserService<UserExtended> userService)
        {
            svc = userService;
        }
        public ServiceController()
        {
            svc = new UserService();
        }
        //Delete
        [InterceptLog]
        public virtual IHttpActionResult DELETE(UserExtended ue)
        {
            svc.Delete(ue);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);

            return ResponseMessage(response);
        }
        //Insert
        [InterceptLog]
        public virtual IHttpActionResult POST( UserExtended ue)
        {
            UserExtended u;
         
            u = svc.Insert(ue);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, u);    
                   
            return ResponseMessage(response);
        }
        //GetById
        [InterceptLog]
        public virtual IHttpActionResult GET(Guid id)
        {
            UserExtended ue;
          
            ue = svc.GetById(id);

            return Ok(ue);
            
        }
        //GetAll
        [InterceptLog]
        public virtual IHttpActionResult GET()
        {
            List<UserExtended> l;
 
            l = svc.GetAll();
           
            return Ok(l);
        }
        //UPDATE
        [InterceptLog]
        public virtual IHttpActionResult PUT(UserExtended ue)
        {
            svc.Update(ue);
            
            return Ok();
        }
        
    }
}
