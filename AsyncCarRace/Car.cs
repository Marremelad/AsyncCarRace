namespace AsyncCarRace;

public class Car
{
    public string? Name { get;}
    public readonly int Speed = 120;
    public double DistanceTraveled = 0;
    

    public Car(string name)
    {
        Name = name;
    }
}