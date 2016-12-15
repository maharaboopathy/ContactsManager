using ContactsMVCApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ContactsMVCApp.ViewModels
{
    public class CreateContactPersonViewModel
    {

        [Required(ErrorMessage = "First Name is Required!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required!")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Telephone { get; set; }



        public virtual Company Company { get; set; }

        public List<SelectListItem> Companies { get; set; }

        [Display(Name ="Select Company")]
        public int SelectedCompanyId { get; set; }


    }
}