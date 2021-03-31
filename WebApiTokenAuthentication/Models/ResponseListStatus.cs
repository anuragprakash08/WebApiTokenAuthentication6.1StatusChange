using Newtonsoft.Json;

namespace WebApiTokenAuthentication.Models
{
    public class ResponseListStatus
    {
        public string status { get; set; }
        public string message { get; set; }

        public string SuccessRecords { get; set; }
        public string FailedRecords { get; set; }
    }

}