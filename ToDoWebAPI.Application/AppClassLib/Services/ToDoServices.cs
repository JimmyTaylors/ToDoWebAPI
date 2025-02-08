using AppClassLib.Interfaces;
using DomainClassLib.Enum;
using DomainClassLib.Model;
using InfrasClassLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClassLib.Services
{
    public class ToDoServices: IToDoServices
    {
        public ToDoServices() { 
            
        }

        public GetAllResponseModel GetAll(string userId)
        {
            GetAllResponseModel ret = new GetAllResponseModel();

            try
            {
                if (InMemoryDataService.CheckIfUserExists(userId))
                {
                    ret.toDos = InMemoryDataService.GetAllByUserID(userId);

                }

                // Assuming that User is logged in and only check if user has any To Do records.
                // It is consider success also when no Todo List found.
                ret.ResponseCode = StatusCode.Success;
                ret.ResponseMessage = StatusCode.Success.ToString();

                return ret;
            }
            catch (Exception ex)
            {
                ret.ResponseCode = StatusCode.SystemError;
                ret.ResponseMessage = StatusCode.SystemError.ToString();

                return ret;
            }
        }

        public ToDo GetByToDoID(string userId, int toDoId)
        {
            ToDo ret = new ToDo();

            if (InMemoryDataService.CheckIfRecordExistsByToDoID(userId, toDoId))
            {
                ret = InMemoryDataService.GetByUserIDByToDoID(userId, toDoId);
            }

            return ret;
        }

        public bool Update(string userId, ToDo updateDto)
        {
            bool isSuccessUpdate = false; 

            if (InMemoryDataService.CheckIfRecordExistsByToDoID(userId, updateDto.Id))
            {
                isSuccessUpdate = InMemoryDataService.UpdateByUserId(userId, updateDto);
            }

            return isSuccessUpdate;
        }
    }
}
