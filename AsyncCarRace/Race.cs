namespace AsyncCarRace;

public static class Race
{
    public static List<Car>? Podium { get; set; }
    public static void Run()
    {
        List<Car> cars = new List<Car>()
        {
            new Car("Lightning McQueen"),
            new Car("Chick Hicks"),
            new Car("Strip Weathers"),
        };

        for (int i = 0; i < 3; i++)
        {
            Car car = cars[i];
            Thread thread = new Thread(() => Go(car));
            thread.Start();
        }
        
    }

    public static void Go(Car car)
    {
        while (true)
        {
            
        }
    }
}