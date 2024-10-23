namespace AsyncCarRace;

public class Car
{
    private string? Name { get; set; }
    public int Speed = 120;
    public readonly double DistanceTraveled = 0;
    

    public Car(string name)
    {
        Name = name;
    }
}