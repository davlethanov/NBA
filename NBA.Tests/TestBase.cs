using FluentAssertions;
using NBA.ApplicationCore.Exceptions;
using NBA.ApplicationCore.Rules;
using System;
using System.Collections.Generic;
using System.Text;
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
