
using System.Numerics;

namespace csharp_11
{
    public class GenericMath
    {

        private int AddAll(params int[] values)
        {
            int result = 0;

            foreach (var value in values)
            {
                result += value;
            }

            return result;
        }


        [Fact]
        public void Sum_with_integers()
        {
            var values = Enumerable.Range(1, 10);
            var sum = AddAll(values.ToArray());

            Assert.Equal(55, sum);
        }


        //[Fact]
        //public void Sum_with_decimal()
        //{
        //    var values =  new[] { 1m, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        //    var sum = AddAll(values.ToArray());

        //    Assert.Equal(55, sum);
        //}
































        private T AddAll2<T>(params T[] values)
            // Generic math version
            where T : INumber<T>
            // Explore INumber for crazy number of interfaces - like IAdditiveIdentity and IParseable
        {
            T result = T.Zero;

            foreach (var value in values)
            {
                result += value;
            }

            return result;
        }

        private T AddAll3<T>(params T[] values)
            // Recursive pattern match version with array
            where T : INumber<T>
            // This version is slow because it allocates an array for every member
            => values switch
            {
                [] => T.Zero,
                [var first] => first,
                [var first, var second] => first + second,
                [var first, .. var rest] => first + AddAll3(rest)
            };


        private T AddAll4<T>(Span<T> values)
            //  Recursive pattern match version with span
            where T : INumber<T>
            // This version is fast because itdoes not allocate
            => values switch
            {
                [] => T.Zero,
                [var first] => first,
                [var first, var second] => first + second,
                [var first, .. var rest] => first + AddAll4(rest)
            };
    }
}
