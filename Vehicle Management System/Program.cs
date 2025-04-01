class Program
{
    static void Main()
    {
        RentalSystem rentalSystem = new RentalSystem();
        Admin admin = new Admin(new List<Vehicle>(), new List<Customer>());
        
        // Adding some default vehicles
        rentalSystem.AddVehicle(new Car("123ABC", "Toyota", "Camry", 50, true));
        rentalSystem.AddVehicle(new Bike("456DEF", "Yamaha", "R15", 20));
        rentalSystem.AddVehicle(new Truck("789GHI", "Ford", "F-150", 80, Truck.ChooseLoadCapacity()));
        rentalSystem.AddVehicle(new Bus("101JKL", "Mercedes", "Tourismo", 100, 40, Bus.ChooseBusClass()));
        
        Console.WriteLine("Welcome to the Vehicle Rental System!");
        while (true)
        {
            Console.WriteLine("\n1. Register Customer");
            Console.WriteLine("2. Rent a Vehicle");
            Console.WriteLine("3. Return a Vehicle");
            Console.WriteLine("4. Show Available Vehicles");
            Console.WriteLine("5. Admin Panel");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter your name: ");
                    string? name = Console.ReadLine();
                    Console.Write("Enter your phone number: ");
                    string? phone = Console.ReadLine();
                    Customer customer = new Customer(name, phone);
                    rentalSystem.RegisterCustomer(customer);
                    Console.WriteLine("Customer registered successfully!");
                    break;
                
                case 2:
                    Console.Write("Enter your name: ");
                    string? custName = Console.ReadLine()?.Trim();
                    Customer? foundCustomer = rentalSystem.FindCustomer(custName);
                    if (foundCustomer != null)
                    {
                        rentalSystem.ShowAvailableVehicles();
                        Console.Write("Enter vehicle license plate to rent: ");
                        string? plate = Console.ReadLine();
                        Vehicle? vehicle = rentalSystem.FindVehicle(plate);
                        if (vehicle != null)
                        {
                            Console.Write("Enter rental days: ");
                            int days = Convert.ToInt32(Console.ReadLine());
                            foundCustomer.RentVehicle(vehicle, days);
                            rentalSystem.RemoveVehicle(vehicle);
                        }
                        else
                        {
                            Console.WriteLine("Vehicle not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Customer not registered!");
                    }
                    break;
                
                case 3:
                    Console.Write("Enter your name: ");
                    string? returnName = Console.ReadLine();
                    Customer? returningCustomer = rentalSystem.FindCustomer(returnName);
                    if (returningCustomer != null && returningCustomer.RentedVehicle != null)
                    {
                        rentalSystem.AddVehicle(returningCustomer.RentedVehicle);
                        returningCustomer.ReturnVehicle();
                    }
                    else
                    {
                        Console.WriteLine("No rented vehicle found.");
                    }
                    break;
                
                case 4:
                    rentalSystem.ShowAvailableVehicles();
                    break;
                
                case 5:
                    Console.WriteLine("\nAdmin Panel");
                    Console.WriteLine("1. View Reservations");
                    Console.WriteLine("2. Approve Reservation");
                    Console.WriteLine("3. Reject Reservation");
                    Console.WriteLine("4. Track Customer History");
                    Console.Write("Enter your choice: ");
                    int adminChoice = Convert.ToInt32(Console.ReadLine());

                    switch (adminChoice)
                    {
                        case 1:
                            admin.ViewReservations();
                            break;
                        case 2:
                            Console.Write("Enter customer name to approve: ");
                            string? approveName = Console.ReadLine();
                            Customer? approveCustomer = rentalSystem.FindCustomer(approveName);
                            if (approveCustomer != null)
                                admin.ApproveReservation(approveCustomer);
                            else
                                Console.WriteLine("Customer not found!");
                            break;
                        case 3:
                            Console.Write("Enter customer name to reject: ");
                            string? rejectName = Console.ReadLine();
                            Customer? rejectCustomer = rentalSystem.FindCustomer(rejectName);
                            if (rejectCustomer != null)
                                admin.RejectReservation(rejectCustomer);
                            else
                                Console.WriteLine("Customer not found!");
                            break;
                        case 4:
                            admin.TrackCustomerHistory();
                            break;
                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                    break;
                
                case 6:
                    Console.WriteLine("Thank you for using the Vehicle Rental System!");
                    return;
                
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
