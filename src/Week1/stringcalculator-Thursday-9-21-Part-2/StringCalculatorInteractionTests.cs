﻿using NSubstitute;

namespace StringCalculator;
public class StringCalculatorInteractionTests
{

    [Theory]
    [InlineData("9", "9")]
    [InlineData("10", "10")]
    public void ResultsAreWrittenToALogger(string numbers, string logged)
    {
        var fakeLogger = Substitute.For<ILogger>();
        IWebService fakeWebService = Substitute.For<IWebService>();
        var calculator = new StringCalculator(fakeLogger, fakeWebService);

        calculator.Add(numbers);
        // _calculator.Add("9");
        fakeLogger.Received(1).Write(logged);
        fakeWebService.DidNotReceive().NotifyOfLoggerFailure(Arg.Any<string>());
    }

    [Fact]
    public void WebServiceCalledIfLoggerThrows()
    {
        //Given the logger throws an exception when you call write
        var fakeLogger = Substitute.For<ILogger>();
        var fakeWebService = Substitute.For<IWebService>();
        fakeLogger.When(c => c.Write(Arg.Any<string>())).Throw<LoggerException>();
        var calculator = new StringCalculator(fakeLogger, fakeWebService);

        //When
        calculator.Add("123");

        fakeWebService.Received(1).NotifyOfLoggerFailure("Logger Went Boom");
    }
}
