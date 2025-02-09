using DomainClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClassLib.RespondModel
{
    public class GetRespondModel: ApiResponse
    {
        public ToDo ToDo { get; set; }
    }
}
