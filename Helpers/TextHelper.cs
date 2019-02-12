#region References

using System.Text;

#endregion

namespace Timeliner.Helpers
{
    public static class TextHelper
    {
        public static Encoding Windows1251()
        {
            return Encoding.GetEncoding("Windows-1251");
        }
    }
}