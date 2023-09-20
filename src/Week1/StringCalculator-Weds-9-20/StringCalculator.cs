
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        char Splitter = '\0';
        if (numbers.Contains("//"))
        {
            Splitter = numbers[2];
            numbers = numbers.Remove(0, 4);
        }
        String[] numberArray = numbers.Split(',', '\n', Splitter);

        int total = 0;

        if (numbers == "") return 0;

        foreach (string number in numberArray)
        {
            total += int.Parse(number);

        }

        return total;

    }
}
