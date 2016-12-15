using System.ComponentModel.DataAnnotations;

namespace ContactsMVCApp.Models
{
    public class ContactPerson
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="First Name is Required!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is Required!")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email is Required!")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Telephone { get; set; }

        public int CompanyId { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual Company Company { get; set; }





    }
}