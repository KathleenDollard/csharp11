using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_11
{
    public class Utf8
    {
        [Fact]
        public void Hello_world_with_format_1()
        {
            byte[] AuthWithTrailingSpace = new byte[] { 0x41, 0x55, 0x54, 0x48, 0x20 };
            byte[] AuthStringLiteral = "AUTH "u8.ToArray();
            Assert.Equal(AuthWithTrailingSpace, AuthStringLiteral);
        }


    }
}
