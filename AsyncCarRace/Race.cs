﻿namespace AsyncCarRace;

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
        List<Thread> threads = new List<Thread>();
        
        for (int i = 0; i < 3; i++)
        {
            Car car = Cars[i];
            Thread thread = new Thread(() => Go(car));
            threads.Add(thread);
            thread.Start();
        }

        Thread displayRace = new Thread(() => Display.DisplayRace(Cars));
        threads.Add(displayRace);
        displayRace.Start();
        
        foreach (var thread in threads)
        {
            thread.Join();
        }
        
        Console.WriteLine("Hello");
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