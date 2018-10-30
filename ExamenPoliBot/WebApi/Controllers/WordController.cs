using System;
using System.Web.Http;
using CoreApi;
using Entities_POJO;
using Exceptions;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class WordController : ApiController
    {
        ApiResponse _apiResp = new ApiResponse();

        // GET: api/Word
        public IHttpActionResult Get()
        {

            _apiResp = new ApiResponse();
            var mng = new WordManager();
            _apiResp.Data = mng.RetrieveAll();

            return Ok(_apiResp);
        }

        // GET: api/Word/5
        public IHttpActionResult Get(string name)
        {
            try
            {
                var mng = new WordManager();
                var word = new Word
                {
                    Words = name
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

        // POST: api/Word
        public IHttpActionResult Post(Word word)
        {

            try
            {
                var mng = new WordManager();
                mng.Create(word);

                _apiResp = new ApiResponse { Message = "Action was executed." };

                return Ok(_apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionID + "-" + bex.AppMessage.Message));
            }
        }

        // PUT: api/Word/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Word/5
        public void Delete(int id)
        {
        }
    }
}
