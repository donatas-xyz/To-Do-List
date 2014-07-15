using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercise1.Models;

namespace Exercise1.Controllers
{
    public class ListController : Controller
    {
        /// <summary>
        /// Controls applications main screen.
        /// </summary>
        /// <returns>Current Task List</returns>
        public ActionResult Index()
        {
            /// Populates Model with collection of objects from the current Session.
            List<TaskInformation> tasks = Session["NewTasks"] as List<TaskInformation>;
 
            if (Session["NewTasks"] == null)
            {
                /// Creates an empty Session object.
                Session["NewTasks"] = new List<TaskInformation>();
            }

            return View(tasks);
        }

        /// <summary>
        /// Adds new Task to task list after "AddTask" button is clicked in a View
        /// </summary>
        /// <param name="TaskDescription">User's input</param>
        /// <returns>Redirects to/refreshes the main screen</returns>
        [HttpPost]
        public ActionResult AddTask(string TaskDescription)
        {
            /// Populates Model with collection of objects from the current Session
            List<TaskInformation> newTask = Session["NewTasks"] as List<TaskInformation>;

            if (TaskDescription == "") 
            {
                /// Loads the main screen
                return RedirectToAction("Index");
            }
            else 
            {
                /// Add new task to collection of Model's objects. (Generate a unique task ID, pass user input, set initial value of task as unaccomplished)
                newTask.Add(new TaskInformation(Guid.NewGuid(), TaskDescription, false));
                /// Saves updated Model into Session.
                Session["NewTasks"] = newTask;

                /// Loads the main screen
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Marks selected Task as accomplished/unaccomplished
        /// </summary>
        /// <param name="id">Selected Task's ID</param>
        /// <returns>Redirects to/refreshes the main screen</returns>
        [HttpPost]
        public ActionResult CompleteTask(Guid id)
        {
            /// Populates Model with collection of objects from the current Session
            List<TaskInformation> tasks = Session["NewTasks"] as List<TaskInformation>;

            /// Checks is selected Task is already marked as accomplished
            if (tasks.Single(x => x.taskID == id).taskCompleted == true)
            {
                /// Marks Task as Accomplished
                tasks.Single(x => x.taskID == id).taskCompleted = false;
            }
            else
            {
                /// Marks Task as Unaccomplished
                tasks.Single(x => x.taskID == id).taskCompleted = true;
            }
            /// Saves updated Model into Session.
            Session["NewTasks"] = tasks;

            /// Loads the main screen
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Removes selected Task from a List
        /// </summary>
        /// <param name="id">Selected Task's ID</param>
        /// <returns>Redirects to/refreshes the main screen</returns>
        [HttpPost]
        public ActionResult RemoveTask(Guid id)
        {
            /// Populates Model with collection of objects from the current Session
            List<TaskInformation> tasks = Session["NewTasks"] as List<TaskInformation>;

            /// Saves selected task as separate object and removes it from collection of objects in Model
            var task = tasks.Single(x => x.taskID == id);
            tasks.Remove(task);
            /// Saves updated Model into Session.
            Session["NewTasks"] = tasks;

            /// Loads the main screen
            return RedirectToAction("Index");
        }
	}
}