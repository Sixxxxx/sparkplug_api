
namespace SparkPlug.Models.Dtos.Response
{
    public class CustomerFormResponseDto
    {
        public string Id { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public string CustomerEmail { get; set; } = default!;
        public string CustomerMessage { get; set; } = default!;
        //If required, the DateTime field can always be added to this response object
    }
}
