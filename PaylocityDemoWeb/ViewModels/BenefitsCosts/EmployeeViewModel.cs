using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaylocityDemoWeb.ViewModels.BenefitsCosts
{
    public class EmployeeViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }
        public decimal? BenefitCostPerPayPeriod { get; set; }
        public List<DependentViewModel> Dependents { get; set; }
    }
}