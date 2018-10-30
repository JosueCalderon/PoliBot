using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreApi;
using Entities_POJO;
using Exceptions;
using WebApi.Models;

namespace WebApi.Controllers
{

    public class TranslationController : ApiController
    {

        ApiResponse _apiResp = new ApiResponse();

        // GET: api/Translation
        public IHttpActionResult Get()
        {

            _apiResp = new ApiResponse();
            var mng = new TranslationManager();
            _apiResp.Data = mng.RetrieveAll();

            return Ok(_apiResp);
        }

        // GET: api/Translation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Translation
        public IHttpActionResult Post(Translation translation)
        {

            try
            {
                var mng = new TranslationManager();
                mng.Create(translation);

                _apiResp = new ApiResponse { Message = "Action was executed." };

                return Ok(_apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionID + "-" + bex.AppMessage.Message));
            }
        }

        // PUT: api/Translation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Translation/5
        public void Delete(int id)
        {
        }
    }
}
