namespace Library.TaskManagement.Models;

public class Class1
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int AssignedUser { get; set; }
    public bool Completed { get; set; }

    public Class1() //constructor
    {

    }

    public override string ToString()
    {
        return $"{Deadline:d} - {Name} - {Description}";
    }


   



}

