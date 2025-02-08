using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClassLib.Enum
{
    public enum StatusCode
    {
        [Description("Success")]
        Success = 100,
        [Description("System Error")]
        SystemError = 400
    }
}
