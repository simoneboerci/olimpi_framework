using System;

namespace CAlgoInterface.Backend.Services;

public static class GuidHelper
{
    public static Guid IntToGuid(int value)
    {
        byte[] bytes = new byte[16];
        BitConverter.GetBytes(value).CopyTo(bytes, 0);
        return new Guid(bytes);
    }

    public static int GuidToInt(Guid guid)
    {
        byte[] bytes = guid.ToByteArray();
        return BitConverter.ToInt32(bytes, 0);
    }

    public static Guid LongToGuid(long value)
    {
        byte[] bytes = new byte[16];
        BitConverter.GetBytes(value).CopyTo(bytes, 0);
        return new Guid(bytes);
    }

    public static long GuidToLong(Guid guid)
    {
        byte[] bytes = guid.ToByteArray();
        return BitConverter.ToInt64(bytes, 0);
    }
}