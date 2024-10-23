namespace AsyncCarRace;

public static class Display
{
    private static readonly object LockObject = new object();
    public static void DisplayRace(List<Car> cars)
    {
        Console.Clear();

        while (true)
        {
            Console.SetCursorPosition(0, 0);
        
            foreach (var car in cars)
            {
                Console.WriteLine(car.DistanceTraveled < Race.RaceDistance
                    ? $"{car.Name} : {car.DistanceTraveled:F2}" 
                    : $"{car.Name} has crossed the finish line");
            }

            lock (LockObject)
            {
                if (Race.Podium?.Count >= Race.Cars.Count) break;
            }
            
            Thread.Sleep(100);
        }
    }

    public static void DisplayPodium(List<Car> cars)
    {
        
    }
}