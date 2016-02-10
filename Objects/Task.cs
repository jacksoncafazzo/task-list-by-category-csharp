using System.Collections.Generic;

namespace ToDoList
{
  public class Task
  {
    private string _description;
    private int _id;
    private static List<Task> _instances = List<Task> {};

    public Task(string descrition)
    {
      _description = description;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Task> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Task Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
