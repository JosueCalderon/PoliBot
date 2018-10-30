using System;
using System.Web.Http;
using CoreApi;
using WebApi.Models;
using Entities_POJO;
using Exceptions;

namespace WebApi.Controllers
{
    public class LanguageController : ApiController
    {

        ApiResponse _apiResp = new ApiResponse();

        // GET: api/Language
        public IHttpActionResult Get()
        {

            _apiResp = new ApiResponse();
            var mng = new LanguageManager();
            _apiResp.Data = mng.RetrieveAll();

            return Ok(_apiResp);
        }

        // GET: api/Language/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Language
        public IHttpActionResult Post(Language language)
        {

            try
            {
                var mng = new LanguageManager();
                mng.Create(language);

                _apiResp = new ApiResponse { Message = "Action was executed." };

                return Ok(_apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionID + "-" + bex.AppMessage.Message));
            }
        }

        // PUT: api/Language/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Language/5
        public void Delete(int id)
        {
        }
    }
}
