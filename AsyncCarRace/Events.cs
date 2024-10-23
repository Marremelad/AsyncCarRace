using System.Runtime.CompilerServices;

namespace AsyncCarRace;

public static class Events
{
    
    private static readonly object LockObject = new object();
    private static readonly Random Random = new Random();
    
    public static void GetEvent(Car car)
    {

        while (true)
        {
            Thread.Sleep(1000);
            if (car.Speed == 300)
            {
                int randomEvent = Random.Next(1, 101);
                
                switch (randomEvent)
                {   
                    case > 0 and < 51:
                        break;
                    
                    case > 61 and < 96:
                        Display.ListOfEvents?.Enqueue($"\n{car.Name} got some dirt on the windshield!".PadRight(70));
                        car.Speed = (int)(car.Speed / 1.2);
                        Thread.Sleep(5000);
                        car.Speed = 300;
                        break;
                    
                    case > 50 and < 61:
                        Display.ListOfEvents?.Enqueue($"\n{car.Name} got a flat tire!".PadRight(70));
                        car.Speed = car.Speed / 2;
                        break;
                    
                    case > 95 and < 101:
                        Display.ListOfEvents?.Enqueue($"\n{car.Name} crashes and is out of the race!".PadRight(70));
                        car.Speed = 0;
                        car.FinishedRace = true;
                        break;
                }
            }
            if (car.FinishedRace) break;
        }
    }
}