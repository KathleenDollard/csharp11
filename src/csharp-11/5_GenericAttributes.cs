namespace csharp_11
{
    public class GenericAttributes
    {
        public class OldStyleTypeAttribute : Attribute
        {
            public OldStyleTypeAttribute(Type t) => ParamType = t;

            public Type ParamType { get; }
        }
        public class GenericAttribute<T> : Attribute { }

        [OldStyleType(typeof(string))]
        public static string? Method() => default;

        [GenericAttribute<string>()]
        public static string? Method2() => default;

    }
}
