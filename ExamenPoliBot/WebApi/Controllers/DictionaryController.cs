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
    public class DictionaryController : ApiController
    {

        ApiResponse _apiResp = new ApiResponse();

        // GET: api/Dictionary
        public IHttpActionResult Get()
        {

            _apiResp = new ApiResponse();
            var mng = new DictionaryManager();
            _apiResp.Data = mng.RetrieveAll();

            return Ok(_apiResp);
        }

        // GET: api/Dictionary/5
        public IHttpActionResult Get(string name)
        {
            try
            {
                var mng = new DictionaryManager();
                var word = new Dictionary
                {
                    Word = name
                };

                word = mng.RetrieveById(word);
                _apiResp = new ApiResponse { Data = word };

                return Ok(_apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionID + "-" + bex.AppMessage.Message));
            }
        }

        // POST: api/Dictionary
        public IHttpActionResult Post(Dictionary dictionary)
        {

            try
            {
                var mng = new DictionaryManager();
                mng.Create(dictionary);

                _apiResp = new ApiResponse { Message = "Action was executed." };

                return Ok(_apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionID + "-" + bex.AppMessage.Message));
            }
        }

        // PUT: api/Dictionary/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Dictionary/5
        public void Delete(int id)
        {
        }
    }
}
