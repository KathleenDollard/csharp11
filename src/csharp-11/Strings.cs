using System.Diagnostics;

namespace csharp_11
{
    public class Strings
    {
        [Fact]
        public void Hello_world_with_format_1()
        {
            var to = "world";
            var output = string.Format("Hello, {0}", to);
            Assert.Equal("Hello, world", output);
        }

        [Fact]
        public void Hello_world_with_format_runtime_failure_1()
        {
            var to = "world";
            var output = string.Format("Hello, {1}", to);
            Assert.Equal("Hello, world", output);
        }

        [Fact]
        public void Hello_world_with_interpolation_6()
        {
            var to = "world";
            var output = $"Hello, {to}";
            Assert.Equal("Hello, world", output);
        }


        [Fact]
        public void Interpolation_shortcut_10()
        {

            var to = "world";
            // Magic happens that shortcuts and does not call the slow method
            // As a result, side effects will not happen - no side effects
            Debug.Assert(SomeTestAlmostAlwaysTrue(), $"Hello, {ImagineAsASlowMethod(to)}");

            // An example of a slow method is anything touching the callstack
            static string ImagineAsASlowMethod(string value) => value;

            static bool SomeTestAlmostAlwaysTrue() => true;
        }

        [Fact]
        public void Newline_in_interpolation_expressions_11()
        {

            var to = "world";
            // No new lines in interpolation expressions prior to 11
            var output = $"Hello, {AMethod(to,
                                           "alpha",
                                           "beta",
                                           "gamma",
                                           "delta",
                                           "eplison",
                                           "zeta",
                                           "eta",
                                           "theta")}";
            Assert.Equal("Hello, world", output);

            // An example of a slow method is anything touching the callstack
            static string AMethod(string value, params string[] _) => value;
        }

        private const string constTo = "world";
        private const string constInterpolatedString = $"Hello, {constTo}";
        [Fact]
        public void Const_interpolation_11()
        {
            Assert.Equal("Hello, world", constInterpolatedString);
        }

        [Fact]
        public void Raw_string_literals_whitespace_11()
        {
            var outputBaseline = @"Hello, world
Hello, Earth
Hello, Moon";

            var outputSimple = """
Hello, world
Hello, Earth
Hello, Moon
""";
            var outputNiceWhitespace = """
                Hello, world
                Hello, Earth
                Hello, Moon
                """;
            var expected = "Hello, world\r\nHello, Earth\r\nHello, Moon";
            Assert.Equal(expected, outputBaseline);
            Assert.Equal(expected, outputSimple);
            Assert.Equal(expected, outputNiceWhitespace);
        }

        [Fact]
        public void Raw_string_literals_double_quote_11()
        {
            var outputBaseline = @"Hello, ""world""";
            var outputBaseline2 = "Hello, \"world\"";

            var rawWithDoubleQuote = """
                Hello, "world"
                """;
            var rawWithDoubleDoubleQuote = """
                Hello, ""world""
                """;
            var rawWithLotsOfDoubleQuotes = """"""""
                Hello, """""""world"""""""
                """""""";
            var dq = "\"";
            var expected = $"Hello, {dq}world{dq}";
            var expectedDoubled = $"Hello, {dq}{dq}world{dq}{dq}";
            var expectedLotsOf = $"Hello, {dq}{dq}{dq}{dq}{dq}{dq}{dq}world{dq}{dq}{dq}{dq}{dq}{dq}{dq}";
            Assert.Equal(expected, outputBaseline);
            Assert.Equal(expected, outputBaseline2);
            Assert.Equal(expected, rawWithDoubleQuote);
            Assert.Equal(expectedDoubled, rawWithDoubleDoubleQuote);
            Assert.Equal(expectedLotsOf, rawWithLotsOfDoubleQuotes);
        }

        [Fact]
        public void Raw_string_literals_curlies_11()
        {
            var temp = 25;
            var outputBaseline = $@"{{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureCelsius"": {temp},
  ""Summary"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00-07:00"",
    ""2019-08-02T00:00:00-07:00""
  ],
  ""TemperatureRanges"": {{
    ""Cold"": {{
      ""High"": 20,
      ""Low"": -10
    }},
    ""Hot"": {{
      ""High"": 60,
      ""Low"": 20
    }}
            }},
  ""SummaryWords"": [
    ""Cool"",
    ""Windy"",
    ""Humid""
  ]
}}";

            var rawJson = $$"""
                {
                  "Date": "2019-08-01T00:00:00-07:00",
                  "TemperatureCelsius": {{temp}},
                  "Summary": "Hot",
                  "DatesAvailable": [
                    "2019-08-01T00:00:00-07:00",
                    "2019-08-02T00:00:00-07:00"
                  ],
                  "TemperatureRanges": {
                    "Cold": {
                      "High": 20,
                      "Low": -10
                    },
                    "Hot": {
                      "High": 60,
                      "Low": 20
                    }
                            },
                  "SummaryWords": [
                    "Cool",
                    "Windy",
                    "Humid"
                  ]
                }
                """;

            Assert.Equal(outputBaseline, rawJson);
        }
    }
}