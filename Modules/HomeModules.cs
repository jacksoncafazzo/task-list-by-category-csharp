using Nancy;
using Tasks.Objects;
using Categories.Objects;
using System;
using System.Collections.Generic;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/categories"] = _ => {
        var allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/new"] = _ => {
        return View["category_form.cshtml"];
      };
      Post["/categories"] = _ => {
        var newCategory = new Category(Request.Form["category-name"]);
        var allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedCategory = Category.Find(parameters.id);
        var categoryTasks = selectedCategory.GetTasks();
        model.Add("category", selectedCategory);
        model.Add("tasks", categoryTasks);
        return View["category.cshtml", model];
      };
      Get["/categories/{id}/tasks/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(parameters.id);
        List<Task> allTasks = selectedCategory.GetTasks();
        model.Add("category", selectedCategory);
        model.Add("tasks", allTasks);
        return View["category_tasks_form.cshtml", model];
      };

      Post["/tasks"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(Request.Form["category-id"]);
        List<Task> categoryTasks = selectedCategory.GetTasks();
        string taskDescription = Request.Form["task-description"];
        Task newTask = new Task(taskDescription);
        categoryTasks.Add(newTask);
        model.Add("tasks", categoryTasks);
        model.Add("category", selectedCategory);
        return View["category.cshtml", model];
      };
      // Get["/tasks_delete"] = _ => {
      //   Category.ClearAll();
      //   return View["tasks_deleted.cshtml"];
      // };
      Get["/categories_delete"] = _ => {
        Category.ClearAll();
        return View["categories_deleted.cshtml"];
      };
      Get["/delete/categories/{id}/tasks/{taskId}"] = parameters => {
        Category selectedCategory = Category.Find(parameters.id);
        List<Task> allTasks = Task.GetAll();
        Task task = allTasks[parameters.taskId-1];
        selectedCategory.RemoveTask(task);
        return View["/index.cshtml", task];
      };
      Get["delete/categories/{id}"] = parameters => {
        Category selectedCategory = Category.Find(parameters.id);
        selectedCategory.ClearAllTasks();
        return View["tasks_deleted.cshtml"];
      };
    }
  }
}
