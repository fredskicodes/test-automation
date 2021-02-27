using Testing.Foo.Config;
using Testing.Foo.Core;
using Microsoft.Extensions.Configuration;

namespace Testing.Foo.Tests.Web
{
    public abstract class BaseTest : Reporter
    {
        protected IConfiguration config = Configuration.GetConfiguration();
    }
}