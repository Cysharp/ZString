namespace Cysharp.Text
{
    public static partial class ZString
    {
        public static Utf16ValueStringBuilder CreateStringBuilder()
        {
            var builder = new Utf16ValueStringBuilder();
            builder.Init(false);
            return builder;
        }

        public static Utf8ValueStringBuilder CreateUtf8StringBuilder()
        {
            var builder = new Utf8ValueStringBuilder();
            builder.Init(false);
            return builder;
        }
    }
}
