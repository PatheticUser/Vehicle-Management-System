public class Customer
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public Vehicle? RentedVehicle { get; set; }

    public Customer(string? name, string? phone)
    {
        Name = name;
        Phone = phone;
        RentedVehicle = null;
    }

    public void RentVehicle(Vehicle vehicle, int days)
    {
        if (RentedVehicle == null)
        {
            RentedVehicle = vehicle;
            Console.WriteLine($"{Name} rented {vehicle.Brand} {vehicle.Model} for {days} days. Cost: ${vehicle.CalculateRentalCost(days)}");
        }
        else
        {
            Console.WriteLine("You already have a rented vehicle. Return it before renting another.");
        }
    }

    public void ReturnVehicle()
    {
        if (RentedVehicle != null)
        {
            Console.WriteLine($"{Name} returned {RentedVehicle.Brand} {RentedVehicle.Model}.");
            RentedVehicle = null;
        }
        else
        {
            Console.WriteLine("No rented vehicle to return.");
        }
    }
}
