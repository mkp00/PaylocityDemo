using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.Core.Queries;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class EmployeeBenefitsCostPerPayPeriod
    {
        [DataTestMethod]
        [DataRow("Jack", "Black", 38.46154)]
        [DataRow("Jack", "Andersen", 34.61538)]
        [DataRow("Allen", "Richardson", 34.61538)]
        public void That_Employee_Only_Is_Correct(string firstName, string lastName, double expected)
        {
            var qry = new EmployeeBenefitsCostPerPayPeriodQry(firstName, lastName);
            var handler = new EmployeeBenefitsCostPerPayPeriodQryHndlr();
            var actual = handler.Handle(qry);
            Assert.AreEqual(Convert.ToDecimal(expected), actual);
        }

        [DataTestMethod]
        [DataRow("Jack", "Black", new string[]{"Lily,Likeness","abel,Label","Rob,allen"}, 92.30769)]
        [DataRow("Jack", "Andersen", new string[] { "Lily,Likeness", "abel,Label", "Rob,allen" }, 88.46154)]
        public void That_Employee_With_Dependents_Is_Correct(string empFirstName, string empLastName, string[] depNames, double expected)
        {
            var nameList = depNames.Select(depName => depName.Split(',')).Select(split => (split[0], split[1])).ToList();
            var qry = new EmployeeBenefitsCostPerPayPeriodQry(empFirstName, empLastName, new ReadOnlyCollection<(string dependentFirstName, string dependentLastName)>(nameList));
            var handler = new EmployeeBenefitsCostPerPayPeriodQryHndlr();
            var actual = handler.Handle(qry);
            Assert.AreEqual(Convert.ToDecimal(expected), actual);
        }
    }
}
