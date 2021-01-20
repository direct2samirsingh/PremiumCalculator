namespace PremiumCalculator.Services.Core
{
    public interface IPremiumService
    {
        double CalculateDeathPremium(double sumInsured, short age, int occupationId);
    }
}