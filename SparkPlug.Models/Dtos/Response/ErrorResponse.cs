using Newtonsoft.Json;

namespace SparkPlug.Models.Dtos.Response
{
    public class ErrorResponse
    {
        public ResponseStatus Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
