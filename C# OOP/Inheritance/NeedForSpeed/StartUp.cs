namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var racer = new RaceMotorcycle(50, 100);

            racer.Drive(200);
            System.Console.WriteLine(racer.Fuel);
        }
    }
}
