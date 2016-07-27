using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResidentPortal.Enumeration
{
    public enum NewUserValidationState
    {
        Approved = 0,
        UsernameFailed = 1,
        EmailFailed = 2
    };
}