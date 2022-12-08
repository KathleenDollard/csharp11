using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_11
{
    public class Immutability
    {
        public class Example1
        {

            public string Field1 { get; set; }
            public string Field2 { get; private set; }
            public string Field3 { get; init; }
        }

        public class ImmutableConstructor
        {
            public ImmutableConstructor( string field4)
            {
                Field4 = field4;
            }

            public string? Field3 { get; init; }
            public string Field4 { get; init; }
        }

        public class ImmutableInitialization
        {
            public string? Field3 { get; init; }
            required public string Field4 { get; init; }
        }

        public class ImmutableConstructorInitialization
        {
            // No analysis is done. If you claim this, only nullability analysis is done
            [SetsRequiredMembers]
            public ImmutableConstructorInitialization(string field4)
            {
                Field4 = field4;
            }
            public string? Field3 { get; init; }
            required public string Field4 { get; init; }

            // Nullable is reasonable with required because calling code can assign to null
            required public string? Field5 { get; init; }
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


        [Fact]
        public void Immutable_Constructor_9()
        {
            var x = new ImmutableConstructor("Delta")
            {
                Field3 = "Gamma",
            };
            Assert.True(true);
        }

        [Fact]
        public void Immutable_Initialization_11()
        {
            var x = new ImmutableInitialization
            {
                Field3 = "Gamma",
                Field4 = "Delta"
            };
            Assert.True(true);
        }


        [Fact]
        public void Immutable_Constructor_Initialization_11()
        {
            var x = new ImmutableConstructorInitialization("Delta")
            {
                Field3 = "Gamma",
            };
            Assert.True(true);
        }

    }
}
