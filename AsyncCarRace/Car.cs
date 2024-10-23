namespace AsyncCarRace;

public class Car
{
    private string? Name { get; set; }
    public int Speed { get; set; }
    private readonly double _distanceTraveled = 0;
    

    public Car(string name, int sped)
    {
        Name = name;
        Speed = sped;
    }
}