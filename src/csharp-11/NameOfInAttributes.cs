namespace csharp_11
{
    public class NameOfInAttributes
    {
        public class StringAttribute : Attribute
        {
            public StringAttribute(string paramName, string typeParamName)
            {
                ParamName = paramName;
                TypeParamName = typeParamName;
            }

            public string ParamName { get; }
            public string TypeParamName { get; }
        }

        [String(nameof(mineMine), nameof(TMineMineMine))]
        public void MyMethod<TMineMineMine>(TMineMineMine mineMine)
        { }
    }
}
