using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Rules
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
