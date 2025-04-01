public abstract class Vehicle
{
    public string LicensePlate {get; set;}
    public string Brand {get; set;}
    public string Model {get; set;}
    public double RentalRatePerDay {get; set;}

    public Vehicle (string licensePlate, string brand, string model, double rentalRatePerDay)
    {
        LicensePlate = licensePlate;
        Brand = brand;
        Model = model;
        RentalRatePerDay = rentalRatePerDay;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"LicensePlate: {LicensePlate}, Brand: {Brand}, Model: {Model}, Rate: {RentalRatePerDay}/day");
    }

    public abstract double CalculateRentalCost(int days);
}