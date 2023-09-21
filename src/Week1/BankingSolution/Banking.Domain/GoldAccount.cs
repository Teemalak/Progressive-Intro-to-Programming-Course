namespace Banking.Domain;

public class GoldAccount : Account
{
    public GoldAccount(ICalculateBonusesForDeposits bonusCalculator) : base(bonusCalculator)
    {
    }

    public override void Deposit(TransactionValueTypes.Deposit amountToDeposit)
    {
    }
}