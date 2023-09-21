namespace Banking.Domain;

public class Account
{
    private decimal _balance = 5000M;
    private ICalculateBonusesForDeposits _bonusCalculator;
    public Account(ICalculateBonusesForDeposits bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }
    public virtual void Deposit(TransactionValueTypes.Deposit deposit)
    {
        decimal bonus = _bonusCalculator.CalculateBonusFor(this, deposit);
        _balance += deposit.Value + bonus;// + bonus;

    }

    public decimal GetBalance()
    {

        return _balance;
    }
    // "Primitive Obsession" -
    public void Withdraw(TransactionValueTypes.Withdrawal amountToWithdraw)
    {
        GuardHasSufficientFunds(amountToWithdraw.Value);

        _balance -= amountToWithdraw.Value; // The important business!
    }

    private void GuardHasSufficientFunds(decimal withdrawal)
    {
        if (withdrawal > _balance)
        {
            throw new OverdraftException();
        }
    }
}
