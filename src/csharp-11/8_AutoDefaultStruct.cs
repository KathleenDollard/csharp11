// This sample is based on https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct#struct-initialization-and-default-values
namespace csharp_11
{
    public class AutoDefaultStruct
    {
        public readonly struct Measurement
        {
            public Measurement(double value)
            {
                Value = value;  // Previously had to assign Description
            }

            public Measurement(double value, string description)
            {
                Value = value;
                Description = description;
            }

            public double Value { get; init; }
            public string Description { get; init; } = "Ordinary measurement";

            public override string ToString() => $"{Value} ({Description})";
        }

        [Fact]
        public void Instantiate_struct_defaults_10()
        {

            // Note that initializers do not run on default instantiation
        }

        [Fact]
        public void Instantiate_struct_11()
        {
            var m1 = new Measurement(5); 
            var m2 = new Measurement();
            var m3 = default(Measurement);
            var expected5 = new Measurement
            {
                Value = 5,
                Description = "Ordinary measurement"
            };
            var expectedDefault = new Measurement
            {
                Value = 0,
                Description = null
            };
            Assert.Equal(expected5, m1);  // output: 5 (Ordinary measurement)
            Assert.Equal(expectedDefault, m2);  // output: 0 ()
            Assert.Equal(expectedDefault, m3);  // output: 0 ()
        }
    }
}
