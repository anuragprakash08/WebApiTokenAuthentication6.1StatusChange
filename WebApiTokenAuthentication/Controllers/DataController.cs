using System.Web.Http;
using WebApiTokenAuthentication.Models;

namespace WebApiTokenAuthentication.Controllers
{
    public class DataController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            return Ok(new ResponseStatus() { status = "SUCCESS", message = "Test Successfully" });
        }

    }
}