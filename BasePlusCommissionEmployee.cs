using System;

public class BasePlusCommissionEmployee
{
    public string FirstName { get; }
    public string LastName { get; }
    public string SocialSecurityNumber { get; }

    private decimal grossSales;
    private decimal commissionRate;
    private decimal baseSalary;

    public BasePlusCommissionEmployee(
        string firstName,
        string lastName,
        string socialSecurityNumber,
        decimal grossSales,
        decimal commissionRate,
        decimal baseSalary)
    {
        FirstName = firstName;
        LastName = lastName;
        SocialSecurityNumber = socialSecurityNumber;
        GrossSales = grossSales;         
        CommissionRate = commissionRate;  
        BaseSalary = baseSalary;          
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

    public decimal BaseSalary
    {
        get => baseSalary;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    value,
                    $"{nameof(BaseSalary)} must be >= 0");
            }

            baseSalary = value;
        }
    }

    public decimal Earnings() =>
        BaseSalary + (CommissionRate * GrossSales);

    public override string ToString() =>
        $"base-salaried commission employee: {FirstName} {LastName}\n" +
        $"social security number: {SocialSecurityNumber}\n" +
        $"gross sales: {grossSales:C}\n" +
        $"commission rate: {commissionRate:F2}\n" +
        $"base salary: {baseSalary:C}";
}
