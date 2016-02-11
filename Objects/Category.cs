using System.Collections.Generic;
using Tasks.Objects;

namespace Categories.Objects
{
  public class Category
  {
    private string _name;
    private int _id;
    private static List<Task> _tasks = new List<Task> {};
    private static List<Category> _instances = new List<Category> {};

    public Category(string categoryName)
    {
      _name = categoryName;
      _instances.Add(this);
      _id = _instances.Count;
      _tasks = new List<Task>();
    }

    public string GetName()
    {
      return _name;
    }
    public void AddTask(Task task)
    {
      _tasks.Add(task);
    }
    public List<Task> GetTasks()
    {
      return _tasks;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Category> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
