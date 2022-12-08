using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace csharp_11
{
    public class Patterns
    {
        [Fact]
        public void Pattern_match_in_condition()
        {
            object objInt = 3;
            object objString = "hello";
            if (objInt is string x) { Console.WriteLine(x); }
        }

        public readonly struct Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) => (X, Y) = (x, y);

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        }

        static string Classify(Point point) => point switch
        {
            (0, 0) => "Origin",
            (1, 0) => "positive X basis end",
            (0, 1) => "positive Y basis end",
            _ => "Just a point",
        };


        [Fact]
        public void List_patterns()
        {
            int[] numbers = { 1, 2, 3 };

            Assert.True(numbers is [1, 2, 3]);  
            Assert.False(numbers is [1, 2, 4]);  
            Assert.False(numbers is [1, 2, 3, 4]);  
            Assert.True(numbers is [0 or 1, <= 2, >= 3]);  


        }

        [Fact]
        public void More_list_patterns()
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5 };

            var x = numbers switch
            {
                [var first, _, _] => $"three items, first is {first}",
                [var first, var second] => "two items",
                [_, ..] => "at least one",
                // Also see the Generic math sample at the bottom - AddAll2 and AddAll3

            };
            Assert.Equal("at least one", x);
        }
    }
}
