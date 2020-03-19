using Domain.Core.Abstractions;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace Domain.Core.Specifications
{
    public class NameBeginsWithDiscountSpecification : Specification<string>
    {
        private readonly string _nameStartsWith;

        public NameBeginsWithDiscountSpecification(string nameStartsWith)
        {
            _nameStartsWith = nameStartsWith ?? throw new ArgumentNullException(nameof(nameStartsWith));
        }
        public override Expression<Func<string, bool>> ToExpression()
        {
            return name => !string.IsNullOrWhiteSpace(name)
                           && name.StartsWith(_nameStartsWith, true, CultureInfo.CurrentCulture);
        }
    }
}