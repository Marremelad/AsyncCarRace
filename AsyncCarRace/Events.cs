using System.Runtime.CompilerServices;

namespace AsyncCarRace;

public static class Events
{
    
    private static readonly object LockObject = new object();
    private static readonly Random Random = new Random();
    
    public static void GetEvent(Car car)
    {

        int timer = 0;
        while (!car.FinishedRace)
        {
            Thread.Sleep(1000);
            timer += 1;
            
            if (car.Speed == 300 && timer == 5)
            {
                timer = 0;

                int randomEvent = Random.Next(1, 101);
                
                if (randomEvent is > 61 and < 96)
                {
                    Display.ListOfEvents?.Add($"\n{car.Name} got some dirt on the windshield!");
                    car.Speed = (int)(car.Speed / 1.2);
                    UndoEvent(car, 5);
                }
                else if (randomEvent is > 51 and < 61)
                {
                    Display.ListOfEvents?.Add($"\n{car.Name} got a flat tire and has to make a pit stop!");
                    car.Speed = 0;
                    UndoEvent(car, 10);
                }
                else if (randomEvent is > 95 and < 101)
                {
                    Display.ListOfEvents?.Add($"\n{car.Name} crashes and is out of the race!");
                    car.Speed = 0;
                    car.HasCrashed = true;
                }
            }
        }
    }

    private static void UndoEvent(Car car, int seconds)
    {
        int timer = 0;
        while (timer != seconds)
        {
            if (car.FinishedRace) break;
            Thread.Sleep(1000);
            timer += 1;
            
        }
        car.Speed = 300;
    }
}