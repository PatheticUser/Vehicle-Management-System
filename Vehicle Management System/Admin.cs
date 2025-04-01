public class Admin
{
    private List<Vehicle> vehicles;
    private List<Customer> customers;
    private Dictionary<Customer, Vehicle> pendingReservations;

    public Admin(List<Vehicle> vehicles, List<Customer> customers)
    {
        this.vehicles = vehicles;
        this.customers = customers;
        this.pendingReservations = new Dictionary<Customer, Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
        Console.WriteLine($"{vehicle.Brand} {vehicle.Model} added to the fleet.");
    }



    public void ViewReservations()
    {
        Console.WriteLine("Pending Reservations:");
        foreach (var reservation in pendingReservations)
        {
            Console.WriteLine($"Customer: {reservation.Key.Name}, Vehicle: {reservation.Value.Brand} {reservation.Value.Model}");
        }
    }

    public void ApproveReservation(Customer customer)
    {
        if (pendingReservations.ContainsKey(customer))
        {
            var vehicle = pendingReservations[customer];
            customer.RentVehicle(vehicle, 1); // Assuming a 1-day rental for approval
            pendingReservations.Remove(customer);
            Console.WriteLine($"Reservation approved for {customer.Name}.");
        }
        else
        {
            Console.WriteLine("No reservation found for this customer.");
        }
    }

    public void RejectReservation(Customer customer)
    {
        if (pendingReservations.ContainsKey(customer))
        {
            pendingReservations.Remove(customer);
            Console.WriteLine($"Reservation rejected for {customer.Name}.");
        }
        else
        {
            Console.WriteLine("No reservation found for this customer.");
        }
    }

    public void TrackCustomerHistory()
    {
        Console.WriteLine("Customer Rental History:");
        foreach (var customer in customers)
        {
            string vehicleInfo = customer.RentedVehicle != null ? $"{customer.RentedVehicle.Brand} {customer.RentedVehicle.Model}" : "No active rentals";
            Console.WriteLine($"Customer: {customer.Name}, Phone: {customer.Phone}, Rented Vehicle: {vehicleInfo}");
        }
    }
}
