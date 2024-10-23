namespace AsyncCarRace;

public static class Display
{
    private static readonly object LockObject = new object();
    public static Queue<string>? ListOfEvents = new Queue<string>();
    public static void DisplayRace(List<Car> cars)
    {
        Console.Clear();

        while (true)
        {
            Console.SetCursorPosition(0, 0);
        
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

            lock (LockObject)
            {
                if (Race.Podium?.Count >= Race.Cars.Count) break;
            }
            
            Thread.Sleep(100);
        }
    }

    public static void DisplayEvents()
    {
        while (true)
        {
            Console.WriteLine();
            
            while (ListOfEvents?.Count > 0)
            {
                string e = ListOfEvents.Dequeue();
                Console.WriteLine($"\n{e}");
            }
            
            lock (LockObject)
            {
                if (Race.Podium?.Count >= Race.Cars.Count) break;
            } 
            
            Thread.Sleep(1000);
        }
    }

    public static void DisplayPodium()
    {
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