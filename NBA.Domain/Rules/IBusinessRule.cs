using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Domain.Rules
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
