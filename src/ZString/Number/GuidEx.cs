using System.Runtime.InteropServices;

namespace System
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct GuidEx
    {
        private int _a;   // Do not rename (binary serialization)
        private short _b; // Do not rename (binary serialization)
        private short _c; // Do not rename (binary serialization)
        private byte _d;  // Do not rename (binary serialization)
        private byte _e;  // Do not rename (binary serialization)
        private byte _f;  // Do not rename (binary serialization)
        private byte _g;  // Do not rename (binary serialization)
        private byte _h;  // Do not rename (binary serialization)
        private byte _i;  // Do not rename (binary serialization)
        private byte _j;  // Do not rename (binary serialization)
        private byte _k;  // Do not rename (binary serialization)

        private static unsafe int HexsToChars(char* guidChars, int a, int b)
        {
            guidChars[0] = HexConverter.ToCharLower(a >> 4);
            guidChars[1] = HexConverter.ToCharLower(a);

            guidChars[2] = HexConverter.ToCharLower(b >> 4);
            guidChars[3] = HexConverter.ToCharLower(b);

            return 4;
        }

        private static unsafe int HexsToCharsHexOutput(char* guidChars, int a, int b)
        {
            guidChars[0] = '0';
            guidChars[1] = 'x';

            guidChars[2] = HexConverter.ToCharLower(a >> 4);
            guidChars[3] = HexConverter.ToCharLower(a);

            guidChars[4] = ',';
            guidChars[5] = '0';
            guidChars[6] = 'x';

            guidChars[7] = HexConverter.ToCharLower(b >> 4);
            guidChars[8] = HexConverter.ToCharLower(b);

            return 9;
        }

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            if (format.Length == 0)
            {
                format = "D".AsSpan();
            }
            // all acceptable format strings are of length 1
            if (format.Length != 1)
            {
                throw new FormatException("InvalidGuidFormatSpecification");
            }

            bool dash = true;
            bool hex = false;
            int braces = 0;

            int guidSize;

            switch (format[0])
            {
                case 'D':
                case 'd':
                    guidSize = 36;
                    break;
                case 'N':
                case 'n':
                    dash = false;
                    guidSize = 32;
                    break;
                case 'B':
                case 'b':
                    braces = '{' + ('}' << 16);
                    guidSize = 38;
                    break;
                case 'P':
                case 'p':
                    braces = '(' + (')' << 16);
                    guidSize = 38;
                    break;
                case 'X':
                case 'x':
                    braces = '{' + ('}' << 16);
                    dash = false;
                    hex = true;
                    guidSize = 68;
                    break;
                default:
                    throw new FormatException("InvalidGuidFormatSpecification");
            }

            if (destination.Length < guidSize)
            {
                charsWritten = 0;
                return false;
            }

            unsafe
            {
                fixed (char* guidChars = &MemoryMarshal.GetReference(destination))
                {
                    char* p = guidChars;

                    if (braces != 0)
                        *p++ = (char)braces;

                    if (hex)
                    {
                        // {0xdddddddd,0xdddd,0xdddd,{0xdd,0xdd,0xdd,0xdd,0xdd,0xdd,0xdd,0xdd}}
                        *p++ = '0';
                        *p++ = 'x';
                        p += HexsToChars(p, _a >> 24, _a >> 16);
                        p += HexsToChars(p, _a >> 8, _a);
                        *p++ = ',';
                        *p++ = '0';
                        *p++ = 'x';
                        p += HexsToChars(p, _b >> 8, _b);
                        *p++ = ',';
                        *p++ = '0';
                        *p++ = 'x';
                        p += HexsToChars(p, _c >> 8, _c);
                        *p++ = ',';
                        *p++ = '{';
                        p += HexsToCharsHexOutput(p, _d, _e);
                        *p++ = ',';
                        p += HexsToCharsHexOutput(p, _f, _g);
                        *p++ = ',';
                        p += HexsToCharsHexOutput(p, _h, _i);
                        *p++ = ',';
                        p += HexsToCharsHexOutput(p, _j, _k);
                        *p++ = '}';
                    }
                    else
                    {
                        // [{|(]dddddddd[-]dddd[-]dddd[-]dddd[-]dddddddddddd[}|)]
                        p += HexsToChars(p, _a >> 24, _a >> 16);
                        p += HexsToChars(p, _a >> 8, _a);
                        if (dash)
                            *p++ = '-';
                        p += HexsToChars(p, _b >> 8, _b);
                        if (dash)
                            *p++ = '-';
                        p += HexsToChars(p, _c >> 8, _c);
                        if (dash)
                            *p++ = '-';
                        p += HexsToChars(p, _d, _e);
                        if (dash)
                            *p++ = '-';
                        p += HexsToChars(p, _f, _g);
                        p += HexsToChars(p, _h, _i);
                        p += HexsToChars(p, _j, _k);
                    }

                    if (braces != 0)
                        *p++ = (char)(braces >> 16);
                }
            }

            charsWritten = guidSize;
            return true;
        }
    }
}
