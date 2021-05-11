using FluentAssertions;
using NBA.Domain.Exceptions;
using NBA.Domain.Rules;
using System;
using Xunit;

namespace NBA.Tests
{
    public abstract class TestBase
    {
        public static void AssertBrokenRule<TRule>(Action action)
            where TRule : class, IBusinessRule
        {
            var businessRuleValidationException = Assert.Throws<BusinessRuleValidationException>(action);
            if (businessRuleValidationException != null)
            {
                businessRuleValidationException.BrokenRule.Should().BeOfType(typeof(TRule));
            }
        }
    }
}
