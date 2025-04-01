public class Car : Vehicle
{
    public bool HasAirConditioning {get; set;} 
    public Car (string licensePlate, string brand ,string model, double rentalRatePerDay, bool hasAC) 
     : base( licensePlate, brand, model, rentalRatePerDay)
     
    {
        HasAirConditioning = hasAC;
    }

    public override double CalculateRentalCost(int days)
    {
        return RentalRatePerDay * days + (HasAirConditioning ? 5*days : 0); 
    }
    
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Has Air Conditioning: {(HasAirConditioning ? "Yes" : "No")}");
    }
}