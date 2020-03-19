using System;
using Domain.Core.Abstractions;
using Domain.Core.Queries;
using Domain.Core.Specifications;

namespace Domain.Services
{
    public class EmployeeBenefitsCostPerPayPeriodQryHndlr : IQueryHandler<EmployeeBenefitsCostPerPayPeriodQry, decimal>
    {
        private readonly NameBeginsWithDiscountSpecification _discountSpec = new NameBeginsWithDiscountSpecification("a");
        public decimal Handle(EmployeeBenefitsCostPerPayPeriodQry query)
        {
            var employeeCost = _discountSpec.IsSatisfiedBy(query.EmployeeFirstName) ||
                               _discountSpec.IsSatisfiedBy(query.EmployeeLastName)
                ? CalculateDiscountCost(query.EmployeeCostPerYear, query.PayPeriodsPerYear, query.Discount)
                : CalculateFullCost(query.EmployeeCostPerYear, query.PayPeriodsPerYear);

            decimal totalDependentCost = 0m;
            foreach (var (dependentFirstName, dependentLastName) in query.DependentNames)
            {
                var dependentCost = _discountSpec.IsSatisfiedBy(dependentFirstName) ||
                                    _discountSpec.IsSatisfiedBy(dependentLastName)
                    ? CalculateDiscountCost(query.DependentCostPerYear, query.PayPeriodsPerYear, query.Discount)
                    : CalculateFullCost(query.DependentCostPerYear, query.PayPeriodsPerYear);

                totalDependentCost += dependentCost;
            }

            return Math.Round(employeeCost + totalDependentCost, 5);
        }

        private decimal CalculateDiscountCost(decimal costPerYear, int payPeriods, decimal discount)
        {
            return (costPerYear - (costPerYear * discount)) / payPeriods;
        }

        private decimal CalculateFullCost(decimal costPerYear, int payPeriods)
        {
            return costPerYear / payPeriods;
        }
    }
}