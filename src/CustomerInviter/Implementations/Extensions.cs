using System;

namespace CustomerInviter.Implementations
{
    public static class Extensions
    {
        public static bool IsHttpUrl(this string path) => path.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase)
                                                          || path.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase);
    }
}
