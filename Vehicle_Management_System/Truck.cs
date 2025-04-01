public class Truck : Vehicle
{
    public int LoadCapacity { get; set; }

    public Truck(string licensePlate, string brand, string model, double rentalRatePerDay, int loadCapacity)
        : base(licensePlate, brand, model, rentalRatePerDay)
    {
        if (loadCapacity == 20 || loadCapacity == 30 || loadCapacity == 35)
        {
            LoadCapacity = loadCapacity;
        }
        else
        {
            Console.WriteLine("Invalid load capacity! Defaulting to 20 tons.");
            LoadCapacity = 20; 
        }
    }

    public override double CalculateRentalCost(int days)
    {
        double cost = RentalRatePerDay * days;

        if (LoadCapacity == 30)
        {
            cost *= 1.1; // 10% increase for 30 tons
        }
        else if (LoadCapacity == 35)
        {
            cost *= 1.2; // 20% increase for 35 tons
        }

        return cost;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Load Capacity: {LoadCapacity} tons");
    }

    public static int ChooseLoadCapacity()
    {
        Console.WriteLine("Select Load Capacity:");
        Console.WriteLine("1. 20 Tons");
        Console.WriteLine("2. 30 Tons (+10% rental cost)");
        Console.WriteLine("3. 35 Tons (+20% rental cost)");
        Console.Write("Enter choice (1/2/3): ");

        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
            return 20;
        else if (choice == 2)
            return 30;
        else if (choice == 3)
            return 35;
        else
        {
            Console.WriteLine("Invalid choice! Defaulting to 20 tons.");
            return 20; // Default value
        }
    }
}