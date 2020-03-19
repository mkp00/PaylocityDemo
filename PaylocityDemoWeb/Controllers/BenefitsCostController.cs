using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Abstractions;
using Domain.Core.Queries;
using Microsoft.AspNetCore.Mvc;
using PaylocityDemoWeb.ViewModels.BenefitsCosts;

namespace PaylocityDemoWeb.Controllers
{
    public class BenefitsCostController : Controller
    {
        private readonly IQueryHandler<EmployeeBenefitsCostPerPayPeriodQry, decimal> _handler;
        public BenefitsCostController(IQueryHandler<EmployeeBenefitsCostPerPayPeriodQry, decimal> handler)
        {
            _handler = handler;
        }

        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(EmployeeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var dependentNames = vm.Dependents?.Select(d => (d.DependentFirstName, d.DependentLastName)).ToList() ?? new List<(string DependentFirstName, string DependentLastName)>();
            var qry = new EmployeeBenefitsCostPerPayPeriodQry(vm.EmployeeFirstName, vm.EmployeeLastName, new ReadOnlyCollection<(string dependentFirstName, string dependentLastName)>(dependentNames));
            vm.BenefitCostPerPayPeriod = _handler.Handle(qry);
            return View(vm);
        }

        public async Task<IActionResult> GetDependentView()
        {
            var c = new EmployeeViewModel()
            {
                Dependents = new List<DependentViewModel>() {new DependentViewModel()}
            };

            return PartialView("_DependentInputPartial", c);
        }
    }
}