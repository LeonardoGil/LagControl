using LagControlForms.Profiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LagControlForms.Configs
{
    public static class Mapper
    {
        public static HostApplicationBuilder Profiles(this HostApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(MovimentacaoModelProfile));

            return builder;
        }
    }
}
