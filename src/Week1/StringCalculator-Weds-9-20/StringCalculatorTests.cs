
namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("12", 12)]
    [InlineData("108", 108)]
    [InlineData("2147483647", 2147483647)]
    public void SingleDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("108,2", 110)]
    [InlineData("0,2147483647", 2147483647)]
    [InlineData("0,0", 0)]
    [InlineData("500000,500000", 1000000)]
    public void TwoDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("5, 10, 15", 30)]
    [InlineData("5, 10, 15, 20", 50)]

    public void MultipleDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);

    }

    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("4\n2,2", 8)]
    [InlineData("4\n2,2\n0\n1", 9)]
    public void NewLineDelimiter(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//,\n3,4", 7)]
    [InlineData("//;\n3,4;1", 8)]
    [InlineData("//;\n3,4;1,4;22\n0", 34)]
    public void SpecialDelimiter(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

}
