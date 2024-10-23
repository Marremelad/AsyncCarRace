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
            Thread.Sleep(100);
            if (car.Speed == 300)
            {
                int randomEvent = Random.Next(1, 101);
                
                switch (randomEvent)
                {   
                    case > 0 and < 51:
                        break;
                    
                    case > 61 and < 96:
                        Display.ListOfEvents?.Add($"\n{car.Name} got some dirt on the windshield!");
                        car.Speed = (int)(car.Speed / 1.2);
                        // Thread.Sleep(5000); Causes the program to wait if event occurs right before finish line.
                        // car.Speed = 300;
                        break;
                    
                    case > 50 and < 61:
                        Display.ListOfEvents?.Add($"\n{car.Name} got a flat tire!");
                        car.Speed = car.Speed / 2;
                        break;
                    
                    case > 95 and < 101:
                        Display.ListOfEvents?.Add($"\n{car.Name} crashes and is out of the race!");
                        car.Speed = 150;
                        // car.Speed = 0; Causes thread freeze because car does not cross finish line.
                        // car.FinishedRace = true; 
                        break;
                }
            }
            if (car.FinishedRace) break;
        }
    }
}