namespace AsyncCarRace;

public class Car
{
    public string Name { get; set; }
    public int Speed { get; set; }
    public double DistanceTraveled;
    public int Placement;

    public Car(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }
}