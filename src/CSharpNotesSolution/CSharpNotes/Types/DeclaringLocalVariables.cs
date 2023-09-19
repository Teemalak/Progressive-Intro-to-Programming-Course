namespace CSharpNotes.Types;
public class DeclaringLocalVariables
{

    [Fact]
    public void ExplicitlyTypedLocalVariable()
    {
        // Type identifier [= value]
        int a = 0;
        Int32 b = 2;

        string dogName = "Rover";

        Assert.Equal(0, a);
        Assert.Equal(2, b);
        Assert.Equal("Rover", dogName);
    }

    [Fact]
    public void ImplicitylyTypedLocalVariableWithVar()
    {
        // If you are going to initialize the variable, C# already knows the type
        var a = 0; // if there is a literal number with no decimal point, it is an int
        var b = 1.0; // A number with a decimla point is inferred to be a double precision 
        var c = "Cat"; //This is a string.
        var d = 'A'; // this is a char
        var e = true;
        var salary = 80123.23M;

        var rover = new Dog();

    }
    [Fact]
    public void ImplicitlyTypedLocalVariablesWithNew()
    {
        Dog rover = new();
    }

}


public class Dog
{

}
