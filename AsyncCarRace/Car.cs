namespace AsyncCarRace;

public class Car
{
    public string? Name { get; set; }
    public int Speed { get; set; }
    public double DistanceTraveled { get; set; }
    

    public Car(string name, int sped, double distanceTraveled)
    {
        Name = name;
        Speed = sped;
        DistanceTraveled = distanceTraveled;
    }
}