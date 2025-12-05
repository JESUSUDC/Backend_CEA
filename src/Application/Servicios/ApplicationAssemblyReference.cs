using System.Reflection;

namespace Application.Servicios
{
    public class ApplicationAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}
