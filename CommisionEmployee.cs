using System;

public class CommissionEmployee
{
    public string FirstName { get; }
    public string LastName { get; }
    public string SocialSecurityNumber { get; }

    private decimal grossSales;
    private decimal commissionRate;

    public CommissionEmployee(
        string firstName,
        string lastName,
        string socialSecurityNumber,
        decimal grossSales,
        decimal commissionRate)
    {
        FirstName = firstName;
        LastName = lastName;
        SocialSecurityNumber = socialSecurityNumber;
        GrossSales = grossSales;         
        CommissionRate = commissionRate;  
    }

    public decimal GrossSales
    {
        get => grossSales;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    value,
                    $"{nameof(GrossSales)} must be >= 0");
            }

            grossSales = value;
        }
    }

    public decimal CommissionRate
    {
        get => commissionRate;
        set
        {
            if (value <= 0 || value >= 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    value,
                    $"{nameof(CommissionRate)} must be > 0 and < 1");
            }

            commissionRate = value;
        }
    }


    public decimal Earnings() => CommissionRate * GrossSales;

    public override string ToString() =>
        $"commission employee: {FirstName} {LastName}\n" +
        $"social security number: {SocialSecurityNumber}\n" +
        $"gross sales: {grossSales:C}\n" +
        $"commission rate: {commissionRate:F2}";
}
