using System.ComponentModel.DataAnnotations;

namespace tickethub_api.Data
{
    public class TicketOrder
    {
        public int ConcertId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        [CreditCard]
        public string CreditCard { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/([0-9]{2})$", ErrorMessage = "Expiration date must be in MM/YY format")]
        public string Expiration { get; set; }

        [Required]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Security code must be 3 or 4 digits")]
        public string SecurityCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
