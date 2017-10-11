using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Lottery.WebApi.Models;
using Lottery.Data;

namespace Lottery.WebApi.Controllers
{
    [EnableCorsAttribute("http://localhost:52436", "*", "*")]
    public class LotteryController : ApiController
    {
        // GET: api/Lottery
        public IEnumerable<Data.Interface.ILottery> Get()
        {
            try
            {
                LotteryRepository repo = new LotteryRepository();
                return repo.GetAllLottery();
            }
            catch (Exception exception)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                { StatusCode = HttpStatusCode.InternalServerError, ReasonPhrase = exception.Message });
            }
        }

        // POST: api/Lottery
        public IHttpActionResult Post([FromBody]Data.Lottery value)
        {
            try
            {
                LotteryRepository repo = new LotteryRepository();
                var messages = repo.Save(value);

                if (messages.Count == 0)
                    return Ok(messages);
                else
                    return BadRequest(string.Join(" ", messages));
            }
            catch (Exception exception)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                { StatusCode = HttpStatusCode.InternalServerError, ReasonPhrase = exception.Message });
            }

        }

        // PUT: api/Lottery/5
        public IHttpActionResult Put(string id, [FromBody]Data.Lottery value)
        {
            try
            {
                var repo = new LotteryRepository();
                var messages = repo.SaveWinningNumbers(id, value.WinningPrimaryNumbers.ToList(), value.WinningSecondaryNumbers.ToList());

                if (messages.Count == 0)
                    return Ok();
                else
                    return BadRequest(string.Join(" ", messages));
            }
            catch (Exception exception)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                { StatusCode = HttpStatusCode.InternalServerError, ReasonPhrase = exception.Message });
            }
        }

    }
}
