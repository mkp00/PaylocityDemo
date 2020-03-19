using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain.Core.Abstractions;

namespace Domain.Core.Queries
{
    public class EmployeeBenefitsCostPerPayPeriodQry : IQuery<decimal>
    {
        public int PayPeriodsPerYear { get; } = 26;
        public decimal EmployeeCostPerYear { get; } = 1000m;
        public decimal DependentCostPerYear { get; } = 500m;
        public decimal Discount { get; } = 0.10m;
        public string EmployeeFirstName { get; }
        public string EmployeeLastName { get; }
        public ReadOnlyCollection<(string dependentFirstName, string dependentLastName)> DependentNames { get; }

        public EmployeeBenefitsCostPerPayPeriodQry(string employeeFirstName, string employeeLastName, ReadOnlyCollection<(string dependentFirstName, string dependentLastName)> dependentNames = null)
        {
            EmployeeFirstName = employeeFirstName ?? throw new ArgumentNullException(nameof(employeeFirstName));
            EmployeeLastName = employeeLastName ?? throw new ArgumentNullException(nameof(employeeLastName));
            DependentNames = dependentNames ?? new ReadOnlyCollection<(string dependentFirstName, string dependentLastName)>(new List<(string dependentFirstName, string dependentLastName)>());
        }
    }
}