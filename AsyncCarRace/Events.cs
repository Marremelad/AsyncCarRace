using System.Runtime.CompilerServices;

namespace AsyncCarRace;

public static class Events
{
    public enum AvailableEvents
    {
        NoEvent,
        FlatTire,
        DirtyWindShield,
        Crash,
    }

    private static readonly object LockObject = new object();
    public static AvailableEvents EvenType { get; set; }
    private static readonly Random Random = new Random();
    
    public static void GetEvent()
    {

        while (true)
        {
            Thread.Sleep(1000);
            Car car = Race.Cars[Random.Next(Race.Cars.Count)];

            if (car.Speed == 300)
            {
                car.ActiveEvent = true;
                AvailableEvents randomEvent = (AvailableEvents)(Enum.GetValues(typeof(AvailableEvents))
                    .GetValue(Random.Next(Enum.GetValues(typeof(AvailableEvents)).Length)) ?? 0);

                switch (randomEvent)
                {
                    case AvailableEvents.NoEvent:
                        break;
                    
                    case AvailableEvents.FlatTire:
                        car.Speed = car.Speed / 2;
                        break;

                    case AvailableEvents.DirtyWindShield:
                        car.Speed = (int)(car.Speed / 1.5);
                        break;

                    case AvailableEvents.Crash:
                        car.Speed = 0;
                        break;
                }
            }
            lock (LockObject)
            {
                if (Race.Podium?.Count >= Race.Cars.Count) break;
            }
        }
    }
}