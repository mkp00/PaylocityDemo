using System.ComponentModel.DataAnnotations;

namespace PaylocityDemoWeb.ViewModels.BenefitsCosts
{
    public class DependentViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string DependentFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string DependentLastName { get; set; }
    }
}