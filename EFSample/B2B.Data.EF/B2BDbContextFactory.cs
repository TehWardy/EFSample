using B2B.Data.EF.Interfaces;
using B2B.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace B2B.Data.EF;

public class B2BDbContextFactory(
    //IEventAuthorizationBroker eventAuthBroker,
    IB2BModelBuildProvider modelBuildProvider,
    ILogger<B2BDbContext> log,
    IDbContextFactory<B2BDbContext> factory) : IB2BDbContextFactory
{
    public B2BDbContext CreateDbContext()
    {
        //var eventAuth = eventAuthBroker.GetEventAuthInfo();
        var context = factory.CreateDbContext();

        context.AuthInfo = new B2BAuthInfo { SSOUserId = "SomeUserId" };
        context.ModelBuildProvider = modelBuildProvider;
        context.Logger = log;

        return context;
    }

    public class B2BAuthInfo : IB2BAuthInfo
    {
        public string SSOUserId { get; set; }
    }
}
