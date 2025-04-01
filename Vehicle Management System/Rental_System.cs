using System;
using System.Collections.Generic;

public class RentalSystem
{
    private List<Vehicle> vehicles = new List<Vehicle>();
    private List<Customer> customers = new List<Customer>();

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void RegisterCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    public void RemoveVehicle(string licensePlate)
    {
        Vehicle? vehicleToRemove = null;
        foreach (var vehicle in vehicles)
        {
            if (vehicle.LicensePlate == licensePlate)
            {
                vehicleToRemove = vehicle;
                break;
            }
        }

        if (vehicleToRemove != null)
        {
            vehicles.Remove(vehicleToRemove);
            Console.WriteLine($"Vehicle {vehicleToRemove.Brand} {vehicleToRemove.Model} removed from the fleet.");
        }
        else
        {
            Console.WriteLine("Vehicle not found!");
        }
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        if (vehicles.Contains(vehicle))
        {
            vehicles.Remove(vehicle);
            Console.WriteLine($"Vehicle {vehicle.Brand} {vehicle.Model} removed from the fleet.");
        }
        else
        {
            Console.WriteLine("Vehicle not found!");
        }
    }

    public void ShowAvailableVehicles()
    {
        Console.WriteLine("Available Vehicles:");
        foreach (var vehicle in vehicles)
        {
            vehicle.DisplayInfo();
        }
    }

    public Customer? FindCustomer(string? name)
    {
        foreach (var customer in customers)
        {
            if (customer.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return customer;
            }
        }
        return null;
    }

    public Vehicle? FindVehicle(string? licensePlate)
    {
        foreach (var vehicle in vehicles)
        {
            if (vehicle.LicensePlate.Equals(licensePlate, StringComparison.OrdinalIgnoreCase))
            {
                return vehicle;
            }
        }
        return null;
    }
}
