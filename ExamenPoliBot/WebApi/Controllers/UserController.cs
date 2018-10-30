using System;
using System.Web.Http;
using CoreApi;
using Entities_POJO;
using Exceptions;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {

        ApiResponse _apiResp = new ApiResponse();

        // GET: api/User
        public IHttpActionResult Get()
        {

            _apiResp = new ApiResponse();
            var mng = new UserManager();
            _apiResp.Data = mng.RetrieveAll();

            return Ok(_apiResp);
        }

        // GET: api/User/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new UserManager();
                var user = new User
                {
                    UserId = id
                };

                user = mng.RetrieveById(user);
                _apiResp = new ApiResponse {Data = user};

                return Ok(_apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionID + "-" + bex.AppMessage.Message));
            }
        }

        // POST: api/User
        public IHttpActionResult Post(User user)
        {

            try
            {
                var mng = new UserManager();
                mng.Create(user);

                _apiResp = new ApiResponse {Message = "Action was executed."};

                return Ok(_apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionID + "-" + bex.AppMessage.Message));
            }
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
