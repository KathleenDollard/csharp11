using System.Diagnostics.CodeAnalysis;

namespace csharp_11;

public class Immutability
{
    public class Example1
    {

        public string Field1 { get; set; }
        public string Field2 { get; private set; }
        public string Field3 { get; init; }
    }

    [Fact]
    public void Basic_initialization_9()
    {
        var x = new Example1
        {
            Field1 = "Alpha",
            //Field2 = "Beta", // Error 
            Field3 = "Gamma"
        };

        Assert.True(true);
    }


    public class RequireViaConstructor
    {
        public RequireViaConstructor( string field4)
        {
            Field4 = field4;
        }

        public string? Field3 { get; init; }
        public string Field4 { get; init; }
    }

    [Fact]
    public void Required_via_constructor_9()
    {
        var x = new RequireViaConstructor("Delta")
        {
            Field3 = "Gamma",
        };
        Assert.True(true);
    }


    public class RequirededInitialization
    {
        public string? Field3 { get; init; }
        required public string Field4 { get; init; }
    }
    [Fact]
    public void Immutable_with_required_initialization_11()
    {
        var x = new RequirededInitialization
        {
            Field3 = "Gamma",
            Field4 = "Delta"
        };
        Assert.True(true);
    }


    public class RequiredConstructorInitialization
    {
        // No analysis is done. If you claim this, only nullability analysis is done
        [SetsRequiredMembers]
        public RequiredConstructorInitialization(string field4)
        {
            Field4 = field4;
        }
        public string? Field3 { get; init; }
        required public string Field4 { get; init; }

        // Nullable is reasonable with required because calling code can assign to null
        required public string? Field5 { get; init; }
    }
    [Fact]
    public void Immutable_Constructor_Initialization_11()
    {
        var x = new RequiredConstructorInitialization("Delta")
        {
            Field3 = "Gamma",
        };
        Assert.True(true);
    }

}
