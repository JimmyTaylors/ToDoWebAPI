using DomainClassLib.Model;

namespace DomainClassLib.RespondModel
{
    public class GetAllResponseModel : ApiResponse
    {
        public List<ToDo> toDos { get; set; }
    }
}
