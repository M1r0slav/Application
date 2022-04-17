public class Musician // Това не отива в базата
{
    public Musician(string name, string role)
    {
        Name = name;
        Role = role;
    }

    public string Name { get; set; }
    public string Role { get; set; }
}