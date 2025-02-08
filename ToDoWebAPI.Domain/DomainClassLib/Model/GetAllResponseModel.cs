namespace DomainClassLib.Model
{
    public class GetAllResponseModel: ApiResponse
    {
        public List<ToDo> toDos { get; set; }
    }
}
