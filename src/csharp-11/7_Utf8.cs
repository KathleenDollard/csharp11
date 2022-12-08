namespace csharp_11
{
    public class Utf8
    {
        [Fact]
        public void Utf8_as_byte_array()
        {
            ReadOnlySpan<byte> AuthWithTrailingSpace = new byte[] { 0x41, 0x55, 0x54, 0x48, 0x20 };
            ReadOnlySpan<byte> AuthStringLiteral = "AUTH "u8;
            Assert.Equal(AuthWithTrailingSpace.ToArray(), AuthStringLiteral.ToArray());
        }


    }
}
