using System.ComponentModel.DataAnnotations;

namespace ContactsMVCApp.ViewModels
{
    public class CreateCompanyViewModel
    {
        [Required(ErrorMessage ="Company is required!")]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }
    }
}