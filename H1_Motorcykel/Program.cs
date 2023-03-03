namespace H1_Motorcykel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MotorcycleClass Motorcycle = new MotorcycleClass();

            Motorcycle.StartEngine();
            Motorcycle.ShiftGearUp();
            Motorcycle.ShiftGearUp();
            Motorcycle.SetRpm(5000);

            Console.WriteLine(Motorcycle.toString());


            Console.ReadKey();
        }
    }
}