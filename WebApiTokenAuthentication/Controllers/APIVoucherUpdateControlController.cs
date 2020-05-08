using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTokenAuthentication.Data;
using WebApiTokenAuthentication.Models;
using System.Linq;

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

            string tran_id = dto.documentnumber;
            string payables_id = dto.invoicenumber.Split('_')[0];
            string part_srl_id = dto.invoicenumber.Split('_')[1];

            var dbDtoPayaBles = (from records in db.BO_PAYABLES select records).Where(y => y.TRAN_ID == tran_id && y.PAYABLES_ID == payables_id && y.PART_SRL_ID == part_srl_id).FirstOrDefault();
            var dbDtoReceivables = (from records in db.BO_RECEIVABLES select records).Where(y => y.TRAN_ID == tran_id && y.RECEIVABLES_ID == payables_id && y.PART_SRL_ID == part_srl_id).FirstOrDefault();

            if (dbDtoPayaBles != null || dbDtoReceivables != null)
                dto.IsDataValid = "Y";

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