namespace AsyncCarRace;

public class Car
{
    private string? Name { get; set; }
    private int _speed = 120;
    private readonly double _distanceTraveled = 0;
    

    public Car(string name)
    {
        Name = name;
    }
}