using System;
namespace cfiDrive.Models
{
    /// <summary>
    /// Todo Items Model
    /// </summary>
    public class TodoItems
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}
