using DomainClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClassLib.Interfaces
{
    public interface IToDoServices
    {
        GetAllResponseModel GetAll(string userId);
        ToDo GetByToDoID(string userId, int toDoId);
        bool Update(string userId, ToDo updateDto);
    }
}
