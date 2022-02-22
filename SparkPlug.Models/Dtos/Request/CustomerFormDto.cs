using System.ComponentModel.DataAnnotations;


namespace SparkPlug.Models.Dtos
{
    public class CreateCustomerFormDto
    {
        [Required]
        public string CustomerName { get; set; } = default!;
        [Required]
        public string CustomerEmail { get; set; } = default!;
        [Required]
        public string CustomerMessage { get; set; } = default!;
    }

    public class UpdateCustomerFormDto
    {
        [Required]
        public string Id { get; set; } = default!;
        [Required]
        public string customerName { get; set; } = default!;
        [Required]
        public string customerEmail { get; set; } = default!;
        [Required]
        public string customerMessage { get; set; } = default!;
    }
}
