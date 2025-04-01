public class Bus : Vehicle
{
    public string BusClass { get; set; }

    public Bus(string licensePlate, string brand, string model, double rentalRatePerDay, int seatNumbers, string busClass)
        : base(licensePlate, brand, model, rentalRatePerDay)
    {
        // Validate and assign the chosen bus class
        if (busClass == "Business" || busClass == "Executive" || busClass == "Economy")
        {
            BusClass = busClass;
        }
        else
        {
            Console.WriteLine("Invalid bus class! Defaulting to Economy.");
            BusClass = "Economy"; // Default value
        }
    }

    // ✅ Rental cost varies based on Bus Class
    public override double CalculateRentalCost(int days)
    {
        double cost = RentalRatePerDay * days;

        if (BusClass == "Executive")
        {
            cost *= 1.2; // 20% increase for Executive class
        }
        else if (BusClass == "Business")
        {
            cost *= 1.5; // 50% increase for Business class
        }

        return cost;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Bus Class: {BusClass}");
    }

    public static string ChooseBusClass()
    {
        Console.WriteLine("Select Bus Class:");
        Console.WriteLine("1. Economy Class (Standard rate)");
        Console.WriteLine("2. Executive Class (+20% rental cost)");
        Console.WriteLine("3. Business Class (+50% rental cost)");
        Console.Write("Enter choice (1/2/3): ");

        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
            return "Economy";
        else if (choice == 2)
            return "Executive";
        else if (choice == 3)
            return "Business";
        else
        {
            Console.WriteLine("Invalid choice! Defaulting to Economy class.");
            return "Economy"; // Default value
        }
    }
}
