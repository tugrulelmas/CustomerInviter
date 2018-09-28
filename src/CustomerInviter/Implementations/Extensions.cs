using System;

namespace CustomerInviter.Implementations
{
    public static class Extensions
    {
        public static bool IsHttpUrl(this string path) {
            Uri uriResult;
            return Uri.TryCreate(path, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
