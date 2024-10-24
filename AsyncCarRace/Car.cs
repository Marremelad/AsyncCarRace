namespace AsyncCarRace;

public class Car
{
    public string? Name { get;}
    public int Speed = 300;
    public double DistanceTraveled = 0;
<<<<<<< HEAD
    public bool ActiveEvent = false;
=======
    public bool PitStop = false;
>>>>>>> refactor
    public bool FinishedRace = false;
    public bool HasCrashed = false;
    
    public Car(string name)
    {
        Name = name;
    }
}