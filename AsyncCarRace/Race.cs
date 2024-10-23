namespace AsyncCarRace;

public static class Race
{
    private static readonly object LockObject = new object();
    public const double RaceDistance = 1000.0;
    public static List<Car>? Podium { get; set; }
    public static List<Car> Cars = new List<Car>()
    {
        new Car("Lightning McQueen"),
        new Car("Chick Hicks"),
        new Car("Strip Weathers"),
    };
    
    public static void Run()
    {
        

        for (int i = 0; i < 3; i++)
        {
            Car car = Cars[i];
            Thread thread = new Thread(() => Go(car));
            thread.Start();
        }
        
    }

    public static void Go(Car car)
    {
        while (car.DistanceTraveled < RaceDistance)
        {
            while (car.DistanceTraveled < RaceDistance)
            {
                Thread.Sleep(100);
                car.DistanceTraveled += car.Speed / 36.0;
            }

            lock (LockObject)
            {
                Podium?.Add(car);
            }
        }
    }
}