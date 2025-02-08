using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClassLib;
using DomainClassLib.Model;

namespace InfrasClassLib.Data
{
    public static class InMemoryDataService
    {
        // UserID, List of ToDo 
        private static ConcurrentDictionary<string, List<ToDo>> _toDoList = new ConcurrentDictionary<string, List<ToDo>>() {
            // Adding initial key-value pairs
            ["1"] = new List<ToDo>
            {
                new ToDo { Id = 1, Title = "Complete project documentation", Description = "", IsCompleted = false, CreatedDate = DateTime.Now, CreatedBy = "1" },
                new ToDo { Id = 2, Title = "Review pull requests", Description = "",IsCompleted = true, CreatedDate = DateTime.Now, CreatedBy = "1"  }
            },
        };

        public static List<ToDo> GetAllByUserID(string id)
        {
            try
            {
                return _toDoList[id];
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static ToDo GetByUserIDByToDoID(string userId, int todoId)
        {
            return _toDoList[userId].FirstOrDefault(i => i.Id == todoId);
        }

        public static bool CreateByUserId(string userId, ToDo updateDto)
        {
            try
            {
                _toDoList[userId].Add(updateDto);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool UpdateByUserId(string userId, ToDo updateDto)
        {
            try
            {
                var record = _toDoList[userId].FirstOrDefault(i => i.Id == updateDto.Id);

                if (record != null && updateDto != null)
                {
                    record.Id = updateDto.Id;
                    record.Title = updateDto.Title;
                    record.Description = updateDto.Description;
                    record.UpdatedBy = updateDto.UpdatedBy;
                    record.UpdatedDate = DateTime.Now;
                }

                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
        }

        #region Validation Method from InMemory 
        public static bool CheckIfUserExists(string id)
        {
            if (_toDoList != null && _toDoList.Any() && _toDoList.ContainsKey(id))
            {
                return true;
            }

            return false;
        }

        public static bool CheckIfRecordExistsByToDoID(string id, int toDoId)
        {
            if (_toDoList != null && _toDoList.Any() && _toDoList.ContainsKey(id) && _toDoList.Any(i => i.Key == id && i.Value.Any(x => x.Id == toDoId)))
                return true;

            return false;
        }

        #endregion
    }
}
