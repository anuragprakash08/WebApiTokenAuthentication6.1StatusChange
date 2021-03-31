using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTokenAuthentication.Data;
using WebApiTokenAuthentication.Models;
using System.Linq;
using System;
using System.Configuration;
using System.Collections.Generic;

namespace WebApiTokenAuthentication.Controllers
{
    public class APIVoucherUpdateControlController : ApiController
    {
        private DALBase db = new DALBase();

        [Authorize]
        [HttpPost]
        [Route("api/VoucherUpdateControl")]
        [ResponseType(typeof(APIVoucherUpdateControls))]
        public IHttpActionResult PostAPIVoucherUpdateControl([FromBody] List<APIVoucherUpdateControls> listDto)
        {
            string successsMsg = "";
            string failedMsg = "";
            bool failed = false;

            try
            {
                EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "PostAPIVoucherUpdateControl", EventLogger.Event.START, "PostAPIVoucherUpdateControl method called :");
                if (!ModelState.IsValid)
                {
                    return Ok(new ResponseListStatus() { status = "400", message = "documentnumber or invoicenumber missing in request body",SuccessRecords="",FailedRecords="" });
                }

                if(listDto.Count() > Convert.ToInt32(ConfigurationManager.AppSettings["MaxRecords"]))
                    return Ok(new ResponseListStatus() { status = "1004", message = "record count exceeds configured limit", SuccessRecords = "", FailedRecords = "All" });

                BO_PAYABLES dbDtoPayaBles;
                BO_RECEIVABLES dbDtoReceivables;
                foreach (var item in listDto)
                {
                    GetData(item, out dbDtoPayaBles, out dbDtoReceivables);
                    if (dbDtoPayaBles == null && dbDtoReceivables == null)
                    {
                        failed = true;
                        failedMsg += item.invoicenumber + ",";
                    }
                    else
                        successsMsg += item.invoicenumber + ",";
                }

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "Exception", EventLogger.Event.END, "PostAPIVoucherUpdateControl method called :" + ex.Message);
                string allfailedMsg = listDto[0].invoicenumber;
                foreach (var item in listDto)
                {
                    allfailedMsg += "," + item.invoicenumber;
                }

                return Ok(new ResponseListStatus()
                {
                    status = "1002",
                    message = "None of the records Posted. Possible Error: Database Connection Failure",
                    SuccessRecords = "",
                    FailedRecords = allfailedMsg
                });
            }

            EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "PostAPIVoucherUpdateControl", EventLogger.Event.END, "PostAPIVoucherUpdateControl method called :");
            if (failed)
                return Ok(new ResponseListStatus()
                {
                    status = "1003",
                    message = "Partial Records Posted, Possible error: Records does not exist",
                    SuccessRecords = successsMsg,
                    FailedRecords = failedMsg
                });
            else
                return Ok(new ResponseListStatus()
                {
                    status = "200",
                    message = "All Records Posted",
                    SuccessRecords = successsMsg,
                    FailedRecords = ""
                });

        }

        [Authorize]
        [HttpPost]
        [Route("api/APIVoucherUpdateControl")]
        [ResponseType(typeof(APIVoucherUpdateControls))]
        public IHttpActionResult PostAPIVoucherUpdateControl([FromBody] APIVoucherUpdateControls dto)
        {
            try
            {
                EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "PostAPIVoucherUpdateControl", EventLogger.Event.START, "PostAPIVoucherUpdateControl method called :");
                if (!ModelState.IsValid)
                {
                    //return BadRequest(ModelState);
                    return Ok(new ResponseStatus() { status = "400", message = "documentnumber or invoicenumber missing in request body" });
                }

                BO_PAYABLES dbDtoPayaBles;
                BO_RECEIVABLES dbDtoReceivables;

                GetData(dto, out dbDtoPayaBles, out dbDtoReceivables);

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw ex;
                }
                if (dbDtoPayaBles == null && dbDtoReceivables == null)
                    return Ok(new ResponseStatus() { status = "501", message = "Key data is not present in BO_PAYABLES & BO_RECEIVABLES" });
            }
            catch (Exception ex)
            {
                EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "Exception", EventLogger.Event.END, "PostAPIVoucherUpdateControl method called :" + ex.Message);
                return Ok(new ResponseStatus() { status = "500", message = "DB connection failed" });
            }

            EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "PostAPIVoucherUpdateControl", EventLogger.Event.END, "PostAPIVoucherUpdateControl method called :");
            return Ok(new ResponseStatus() { status = "200", message = "Voucher Updated Successfully" });

        }

        private void GetData(APIVoucherUpdateControls dto, out BO_PAYABLES dbDtoPayaBles, out BO_RECEIVABLES dbDtoReceivables)
        {
            EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "PostAPIVoucherUpdateControl", EventLogger.Event.START, "PostAPIVoucherUpdateControl method called :" + dto.documentnumber + "," + dto.invoicenumber);
            APIVoucherUpdateControls dtoToBeSaved = db.APIVoucherUpdateControls.Find(dto.documentnumber, dto.invoicenumber);
            EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "PostAPIVoucherUpdateControl", EventLogger.Event.END, "PostAPIVoucherUpdateControl method called :" + dto.documentnumber + "," + dto.invoicenumber);

            string separator = ConfigurationManager.AppSettings["Separator"].ToString();
            string tran_id = dto.documentnumber;
            string payables_id = dto.invoicenumber.Split(separator[0])[0];
            string part_srl_id = dto.invoicenumber.Split(separator[0])[1];

            dbDtoPayaBles = (from records in db.BO_PAYABLES select records).Where(y => y.TRAN_ID == tran_id && y.PAYABLES_ID == payables_id && y.PART_SRL_ID == part_srl_id).FirstOrDefault();
            dbDtoReceivables = (from records in db.BO_RECEIVABLES select records).Where(y => y.TRAN_ID == tran_id && y.RECEIVABLES_ID == payables_id && y.PART_SRL_ID == part_srl_id).FirstOrDefault();
            if (dbDtoPayaBles != null || dbDtoReceivables != null)
                dto.IsDataValid = "Y";


            if (dbDtoPayaBles != null)
            {
                dto.PAYorREC = "PAY";
                dto.PayablesID_ReceivablesID = dbDtoPayaBles.PAYABLES_ID;
                dto.PartSrlNo = dbDtoPayaBles.PART_SRL_ID;
                dto.TranID = dbDtoPayaBles.TRAN_ID;
                dto.TranType = dbDtoPayaBles.TRAN_TYPE;
            }
            if (dbDtoReceivables != null)
            {
                dto.PAYorREC = "REC";
                dto.PayablesID_ReceivablesID = dbDtoReceivables.RECEIVABLES_ID;
                dto.PartSrlNo = dbDtoReceivables.PART_SRL_ID;
                dto.TranID = dbDtoReceivables.TRAN_ID;
                dto.TranType = dbDtoReceivables.TRAN_TYPE;
            }

            if (dtoToBeSaved != null)
            {
                db.Entry(dtoToBeSaved).CurrentValues.SetValues(dto);
                db.Entry(dtoToBeSaved).State = EntityState.Modified;
            }
            else
            {
                db.APIVoucherUpdateControls.Add(dto);
            }
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