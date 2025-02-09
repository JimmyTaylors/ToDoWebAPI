using AppClassLib.Services;
using DomainClassLib.Model;
using DomainClassLib.RequestModel;
using DomainClassLib.RespondModel;
using APIStatusCode = DomainClassLib.Enum.StatusCode;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ToDoController : ControllerBase
    {
        public ToDoServices _toDoServices = new ToDoServices();

        /// <summary>
        /// Retrieve all To Do List
        /// </summary>
        /// <param name="GetAllRequestModel"></param>
        /// <returns>GetAllResponseModel</returns>
        /// <response code="100">Success</response>
        /// <response code="400">System Error</response>
        [HttpGet]
        [Route("GetAll")]
        public GetAllResponseModel GetAll([FromQuery] GetAllRequestModel getAllRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return new GetAllResponseModel()
                {
                    ResponseCode = APIStatusCode.SystemError,
                    ResponseMessage = APIStatusCode.SystemError.ToString(),
                };
            }

            return _toDoServices.GetAll(getAllRequestModel.UserID);
        }

        /// <summary>
        /// Retrieve Single ToDo By UserID by ToDo ID
        /// </summary>
        /// <param name="GetRequestModel"></param>
        /// <returns>GetRespondModel</returns>
        /// <response code="100">Success</response>
        /// <response code="400">System Error</response>
        [HttpGet]
        [Route("GetByID")]
        public GetRespondModel GetByID([FromQuery]GetRequestModel getRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return new GetRespondModel() { 
                    ResponseCode = APIStatusCode.SystemError,
                    ResponseMessage = APIStatusCode.SystemError.ToString(),
                };
            }

            return _toDoServices.GetByToDoID(getRequestModel.UserID, getRequestModel.ToDoID);
        }


        /// <summary>
        /// Create new ToDo
        /// </summary>
        /// <param name="createRequestModel"></param>
        /// <returns>GetRespondModel</returns>
        /// <response code="100">Success</response>
        /// <response code="400">System Error</response>
        [HttpPost]
        public GetRespondModel Create(CreateRequestModel createRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return new GetRespondModel()
                {
                    ResponseCode = APIStatusCode.SystemError,
                    ResponseMessage = APIStatusCode.SystemError.ToString(),
                };
            }

            return _toDoServices.Create(createRequestModel);
        }


        /// <summary>
        /// Update ToDo By UserID By ID
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///		{
        ///		    
        ///		}
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>SportCountLiteDto</returns>
        /// <response code="100">Success</response>
        /// <response code="400">System Error</response>
        [HttpPut]
        public GetRespondModel Update(UpdateRequestModel updateRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return new GetRespondModel()
                {
                    ResponseCode = APIStatusCode.SystemError,
                    ResponseMessage = APIStatusCode.SystemError.ToString(),
                };
            }

            return _toDoServices.Update(updateRequestModel);
        }


        /// <summary>
        /// Delete ToDo By UserID By ToDo ID
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///		{
        ///		    
        ///		}
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>SportCountLiteDto</returns>
        /// <response code="100">Success</response>
        /// <response code="400">System Error</response>
        [HttpDelete]
        public ApiResponse Delete(string? userId, int toDoId)
        {
            if (!ModelState.IsValid)
            {
                return new GetRespondModel()
                {
                    ResponseCode = APIStatusCode.SystemError,
                    ResponseMessage = APIStatusCode.SystemError.ToString(),
                };
            }

            return _toDoServices.Delete(userId, toDoId);
        }
    }
}
