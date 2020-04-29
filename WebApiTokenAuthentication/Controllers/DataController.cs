using System.Web.Http;

namespace WebApiTokenAuthentication.Controllers
{
    public class DataController : ApiController
    {
        [Authorize]
        [HttpPost]
        [Route("api/data/postVoucher")]
        public IHttpActionResult PostVoucherupdate()
        {
            //call dal class to update DB
            return Ok("Update Database");
        }

        [Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            return Ok("Hello Anurag");
        }

        [HttpPost]
        [Route("api/data/APIVoucherUpdateControl")]
        public IHttpActionResult APIVoucherUpdateControl([FromBody] APIVoucherUpdateControls dto)
        {
            return Ok("Hello Anurag");
        }
    }
}