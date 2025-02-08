using DomainClassLib.Enum;

namespace DomainClassLib.Model
{
    public class ApiResponse
    {
        public StatusCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
