public class Bike : Vehicle
{
    public Bike (string licensePlate, string brand, string model, double rentalRatePerDay)
    : base(licensePlate, brand, model, rentalRatePerDay){}
   
    public override double CalculateRentalCost(int days)
    {
        return RentalRatePerDay * days; 
    }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
    }
}