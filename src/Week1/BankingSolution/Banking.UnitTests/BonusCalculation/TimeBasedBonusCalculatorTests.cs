using Banking.Domain;

namespace Banking.UnitTests.BonusCalculation;
public class TimeBasedBonusCalculatorTests
{
    [Theory]
    [InlineData(5000, 100, 10)]
    [InlineData(6500, 200, 20)]
    public void MakingDepositsOutsideOfBusinessHoursWithAdequateBalance(decimal balance, decimal deposit, decimal expectedBonus)
    {
        var calculator = new TimeBasedBonusCalculator();

        decimal bonus = calculator.CalculateBonusForAccountDeposit(balance, deposit);

        Assert.Equal(expectedBonus, bonus);
    }
    [Theory]
    [InlineData(4999.99, 100, 0)]
    [InlineData(4999.99, 200, 0)]
    public void MakingDepositsOutsideOfBusinessHoursWithoutAdequateBalance(decimal balance, decimal deposit, decimal expectedBonus)
    {
        var calculator = new TimeBasedBonusCalculator();

        decimal bonus = calculator.CalculateBonusForAccountDeposit(balance, deposit);

        Assert.Equal(expectedBonus, bonus);
    }
    [Theory]
    [InlineData(5000, 100, 13)]
    [InlineData(6999.99, 100, 13)]
    [InlineData(7999.99, 100, 13)]
    [InlineData(8000, 100, 13)]
    public void MakingDepositsDuringBusinessHoursGetBonus(decimal balance, decimal deposit, decimal expectedBonus)
    {
        var calculator = new TimeBasedBonusCalculator();

        decimal bonus = calculator.CalculateBonusForAccountDeposit(balance, deposit);

        Assert.Equal(expectedBonus, bonus);
    }
}
