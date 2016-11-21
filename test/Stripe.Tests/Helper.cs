using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Stripe.Tests
{
    public static class Helper
    {
        public static Stream GetEmbeddedResourceStream(string resource)
        {
            var assembly = typeof(Helper).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream(resource);
        }
    }
}
