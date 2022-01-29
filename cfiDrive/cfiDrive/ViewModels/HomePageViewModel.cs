using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using cfiDrive.Models;
using cfiDrive.Services;
using cfiDrive.Shared;

namespace cfiDrive.ViewModels
{
    public class HomePageViewModel: BaseViewModel
    {

        private List<TodoItems> _todoItemsList;

        public List<TodoItems> TodoItemsList
        {
            get
            {
                return _todoItemsList;
            }
            set
            {
                SetObservableProperty(ref (_todoItemsList), value);
            }
        }


        public HomePageViewModel()
        {
            TodoItemsList = new List<TodoItems>();
            CallTodoList();
        }

        private async Task CallTodoList()
        {
            try
            {
                IsBusy = true;

                ToDoService todoService = new ToDoService();

                var result = await todoService.GetListOfTodo();

                if(result!=null)
                {
                    TodoItemsList = result.Where(x => x.completed == true).ToList();
                    var items = TodoItemsList.Count();
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
