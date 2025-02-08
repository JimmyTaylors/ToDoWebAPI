using AppClassLib.Services;
using DomainClassLib.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        public ToDoServices _toDoServices = new ToDoServices();

        /// <summary>
        /// Retrieve all To Do List
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
        [HttpGet]
        [Route("GetAll")]
        public GetAllResponseModel GetAll(string id)
        {
            return _toDoServices.GetAll(id);
        }


        /// <summary>
        /// Retrieve Single ToDo By UserID by ToDo ID
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
        [HttpGet]
        [Route("GetByID")]
        public ToDo GetByID(string id, int toDoId)
        {
            return _toDoServices.GetByToDoID(id, toDoId);
        }


        /// <summary>
        /// Create new ToDo
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
        [HttpPost]
        public bool Create(string inputDto)
        {
            return false;
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
        public bool Update(string inputDto)
        {
            return false;
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
        public bool Delete(string inputDto)
        {
            return false;
        }
    }
}
