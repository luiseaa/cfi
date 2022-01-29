using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using cfiDrive.Models;

namespace cfiDrive.Services
{
    public class ToDoService: BaseService
    {
        public ToDoService()
        {
        }

        /// <summary>
        /// Get List of Todo items
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<TodoItems>> GetListOfTodo( )
        {
            ObservableCollection<TodoItems> result = null;
            try
            {
                result = await GetAsync<ObservableCollection<TodoItems>>("Todos");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return result;
        }
    }
}
