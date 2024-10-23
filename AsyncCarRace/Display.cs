namespace AsyncCarRace;

public static class Display
{
    private static readonly object LockObject = new object();
    public static List<string?> ListOfEvents = new List<string?>();
    
    public static void DisplayRace(List<Car> cars)
    {
        Console.Clear();

        while (true)
        {
            Console.Clear();
            
            foreach (var car in cars)
            {
                if (car.Speed == 0) Console.WriteLine($"{car.Name} DNF".PadRight(70));
                else
                {
                    Console.WriteLine(car.DistanceTraveled < Race.RaceDistance
                        ? $"{car.Name} : Speed - {car.Speed}: Distance - {car.DistanceTraveled:F2}".PadRight(70) 
                        : $"{car.Name} has crossed the finish line".PadRight(70));
                }
            }
            Display.DisplayEvents();
            
            lock (LockObject)
            {
                if (Race.Podium?.Count >= Race.Cars.Count) break;
            }
            
            // Bug happens because when a car crashes it does not cross the finish line. And this loop keeps going until all cars cross the finish line.
            
            Thread.Sleep(100);
        }
    }

    
    public static void DisplayEvents()
    {
        Console.Write("\nEvent log:");

        int number = ListOfEvents.Count;
        
        for (int i = number; i > (number / 2); i--)
        {
            Console.Write(ListOfEvents[i - 1]);
        }
    }

    public static void DisplayPodium()
    {
        Console.Clear();
        lock (LockObject)
        {
            Console.WriteLine("\n" +
                              $"                          {Race.Podium?[0].Name,-15}\r\n" +
                              $"                         @-----------------------@\r\n" +
                              $"       {Race.Podium?[1].Name,-15}    |           @           |\r\n" +
                              $"@-----------------------@|           |           |\r\n" +
                              $"|           @           ||           |           | {Race.Podium?[2].Name,-15}\r\n" +
                              $"|           |           ||           |           |@-----------------------@\r\n" +
                              $"|           |           ||           |           ||           @           |"
            );
        }
    }
}