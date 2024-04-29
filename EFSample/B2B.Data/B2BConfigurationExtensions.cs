using B2B.Objects;
using Microsoft.Extensions.DependencyInjection;

namespace B2B;

public static class B2BConfigurationExtensions
{
    public static void AuthorizeUsing(
        this B2BConfiguration config,
        IServiceCollection services,
        Func<IServiceProvider, string> getSSOUserId) =>
            services.AddTransient<IB2BAuthInfo, B2BAuthInfo>(
                ctx => new B2BAuthInfo
                {
                    SSOUserId = getSSOUserId(ctx)
                });
}