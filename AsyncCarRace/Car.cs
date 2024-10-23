namespace AsyncCarRace;

public class Car
{
    public string? Name { get;}
    public int Speed = 300;
    public double DistanceTraveled = 0;
    public bool FinishedRace = false;
    
    public Car(string name)
    {
        Name = name;
    }
}