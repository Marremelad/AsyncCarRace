namespace AsyncCarRace;

public static class Race
{
    private const double Distance = 1000.0;
    private static readonly Queue<Car> FinishingOrder = new Queue<Car>();
    private static readonly object LockQue = new object();
    
    private static readonly List<Car> Cars =
    [
        new Car("Lightning McQueen", 350),
        new Car("Chick Hicks", 300),
        new Car("Strip Weathers", 250)
    ];
    
    public static void Run()
    {
        Thread car1 = new Thread(() => Go(Cars[0]));
        Thread car2 = new Thread(() => Go(Cars[1]));
        Thread car3= new Thread(() => Go(Cars[2]));

        Thread raceStatus = new Thread(() => RaceStatus(Cars));
        
        car1.Start();
        car2.Start();
        car3.Start();
        
        raceStatus.Start();

        car1.Join();
        car2.Join();
        car3.Join();

        raceStatus.Join();
        
        Console.WriteLine();
        lock (LockQue)
        {
            List<Car> podium = FinishingOrder.ToList();
        }
    }

    private static void Go(Car car)
    {
        while (car.DistanceTraveled < Distance)
        {
            Thread.Sleep(100);
            car.DistanceTraveled += car.Speed / 36.0;
        }

        lock (LockQue)
        {
            FinishingOrder.Enqueue(car);
        }
    }

    private static void RaceStatus(List<Car> cars)
    {
        Console.Clear();

        while (true)
        {
            Console.SetCursorPosition(0, 0);
        
            foreach (var car in cars)
            {
                Console.WriteLine(car.DistanceTraveled < Distance 
                    ? $"{car.Name} : {car.DistanceTraveled:F2}" 
                    : $"{car.Name} has crossed the finish line");
            }

            lock (LockQue)
            {
                if (FinishingOrder.Count >= Cars.Count) break;
            }
            
            System.Threading.Thread.Sleep(100);
        }
    }
}