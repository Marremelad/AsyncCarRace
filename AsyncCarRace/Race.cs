namespace AsyncCarRace;

public static class Race
{
    private const double Distance = 1000.0;
    private static readonly Queue<Car> FinishingOrder = new Queue<Car>();
    private static readonly object LockQue = new object();

    private static readonly Random random = new();
    private static Queue<Event> Events = new Queue<Event>(5);
    
    internal static readonly List<Car> Cars =
    [
        new Car("Lightning McQueen", 350),
        new Car("Chick Hicks", 350),
        new Car("Strip Weathers", 350)
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
            Console.WriteLine($"                          {podium[0].Name,-10}\r\n" +
                              $"                         @-----------------------@\r\n       {podium[1].Name,-10}" +
                              $"        |           @           |\r\n@-----------------------@|           |           |\r\n|" +
                              $"           @           ||           |           | {podium[2].Name,-10}\r\n|" +
                              $"           |           ||           |           |@-----------------------@\r\n|           |           ||" +
                              $"           |           ||           @           |");
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
    
    private static void UpdateEvents(object state)
    {
        Car car = Cars[random.Next(Cars.Count())];
        Events.Enqueue(new Event(car));
        if(Events.Count > 5)
        {
            Event finishedEvent = Events.Dequeue();
            finishedEvent.UndoEvent();
        }
        
    }
    private static void RaceStatus(List<Car> cars)
    {
        Console.Clear();
        Timer timer = new Timer(UpdateEvents, null, 0, 2000);
        Random random = new();

        while (true)
        {
            Console.SetCursorPosition(0, 0);
        
            foreach (var car in cars)
            {
                Console.WriteLine(car.DistanceTraveled < Distance 
                    ? $"{car.Name} : {car.DistanceTraveled:F2}" 
                    : $"{car.Name} has crossed the finish line");
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Event Log:");


            foreach (var e in Events)
            {
                Console.WriteLine(e);
            }

            lock (LockQue)
            {
                if (FinishingOrder.Count >= Cars.Count) break;
            }
            
            System.Threading.Thread.Sleep(100);
        }
    }
}