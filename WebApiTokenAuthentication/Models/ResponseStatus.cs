using Newtonsoft.Json;

namespace WebApiTokenAuthentication.Models
{
    public class ResponseStatus
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    //public static class ContextHelper
    //{
    //    public static string ToJsonString(this object obj)
    //    {
    //        return JsonConvert.SerializeObject(obj);
    //    }
    //}

}