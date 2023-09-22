namespace Banking.Domain;

public interface IProvideTheBusinessClock
{
    public bool IsOpen()
    {
        return true;
    }
}