using System.ComponentModel.DataAnnotations;


namespace Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.CreditCard)]
        public string BankAccountNumber { get; set; }

    }
}
