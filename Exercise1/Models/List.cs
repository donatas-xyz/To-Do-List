using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise1.Models
{
    /// <summary>
    /// Holds Task information
    /// </summary>
    public class TaskInformation
    {
        public Guid taskID { get; set; }
        public string taskDescription { get; set; }
        public bool taskCompleted { get; set; }
        /// <summary>
        /// Creates a Task
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <param name="description">Task Description</param>
        /// <param name="completed">Task Status</param>
        public TaskInformation(Guid id, string description, bool completed) 
        {
            taskID = id;
            taskDescription = description;
            taskCompleted = completed;
        }
    }
}