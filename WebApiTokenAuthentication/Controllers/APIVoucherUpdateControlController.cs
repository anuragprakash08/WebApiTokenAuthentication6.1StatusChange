using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTokenAuthentication.Data;
using WebApiTokenAuthentication.Models;

namespace WebApiTokenAuthentication.Controllers
{
    public class APIVoucherUpdateControlController : ApiController
    {
        private DALBase db = new DALBase();

        [Authorize]
        [HttpPost]
        [Route("api/APIVoucherUpdateControl")]
        [ResponseType(typeof(APIVoucherUpdateControls))]
        public IHttpActionResult PostAPIVoucherUpdateControl([FromBody] APIVoucherUpdateControls dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            APIVoucherUpdateControls dtoToBeSaved = db.APIVoucherUpdateControls.Find(dto.documentnumber, dto.invoicenumber);

            if (dtoToBeSaved != null)
            {
                db.Entry(dtoToBeSaved).CurrentValues.SetValues(dto);
                db.Entry(dtoToBeSaved).State = EntityState.Modified;
            }
            else
            {
                db.APIVoucherUpdateControls.Add(dto);
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }

            return Ok(new ResponseStatus() { status = "200", message = "Voucher Updated Successfully" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}