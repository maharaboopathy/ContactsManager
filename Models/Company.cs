using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsMVCApp.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Display(Name ="Company Name")]
        [Required(ErrorMessage ="Company Name is Required!")]
        public string CompanyName { get; set; }


        public ICollection<ContactPerson> Persons { get; set; }
    }
}