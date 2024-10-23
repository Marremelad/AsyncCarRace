namespace AsyncCarRace;

public class Car
{
    private string? Name { get; set; }
    public readonly int Speed = 120;
    public double DistanceTraveled = 0;
    

    public Car(string name)
    {
        Name = name;
    }
}