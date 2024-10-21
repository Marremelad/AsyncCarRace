namespace AsyncCarRace;

public class Event
{
    static Random random = new();
    readonly Car car;
    readonly int eventChoice;
    readonly string feedback;



    public Event(Car chosenCar)
    {
        car = chosenCar;
        eventChoice = random.Next(2);

        switch (eventChoice)
        {
            case 0:
                {
                    feedback = $"{car.Name} has a flat tire!";
                    car.Speed -= 200;
                    break;
                }
            case 1:
                {
                    feedback = $"{car.Name} drove off track!";
                    car.Speed -= 50;
                    break;
                }
        }

    }
    public override string ToString()
    {
        return feedback;
    }
    public void UndoEvent()
    {
        switch (eventChoice)
        {
            case 0:
                {
                    car.Speed += 200;
                    break;
                }
            case 1:
                {
                    car.Speed += 50;
                    break;
                }
        }
    }
}