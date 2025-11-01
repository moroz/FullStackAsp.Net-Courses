using Decimal = Courses.Grpc.Decimal;

namespace Courses.Models;

public static class DecimalExtensions
{
    public static Decimal ToGrpcDecimal(this decimal value)
    {
        var bits = decimal.GetBits(value);

        var lo = (uint)bits[0] | ((ulong)bits[1] << 32);
        var hi = (uint)bits[2];
        var scale = (bits[3] >> 16) & 0x7F;
        var isNegative = (bits[3] & 0x80000000) != 0;
        var signScale = isNegative ? -scale : scale;

        return new Decimal
        {
            Hi = hi,
            Lo = lo,
            SignScale = signScale,
        };
    }
}