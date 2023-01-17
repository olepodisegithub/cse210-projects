public class Resume
{
    public String _name = "";
    public List<Jobs> _jobs = new List<Jobs>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Jobs job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}