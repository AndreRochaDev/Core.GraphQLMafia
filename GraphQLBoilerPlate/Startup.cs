using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQLBoilerplate.Models.Mafia;
using GraphQLBoilerplate.Models.Mafia.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GraphQLBoilerplate
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<MafiaData>();
            services.AddSingleton<MafiaQuery>();
            services.AddSingleton<MafiaMutation>();
            services.AddSingleton<BossType>();
            services.AddSingleton<UnderBossType>();
            services.AddSingleton<CapoType>();
            services.AddSingleton<SoldierType>();
            services.AddSingleton<SoldierInputType>();
            services.AddSingleton<MafiaMemberInterface>();
            services.AddSingleton<UnderBossInterface>();
            services.AddSingleton<CapoInterface>();
            services.AddSingleton<ZoneOfOperationsEnum>();
            services.AddSingleton<ISchema, MafiaSchema>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddGraphQL(_ =>
                {
                    _.EnableMetrics = true;
                    _.ExposeExceptions = true;
                })
                .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();

            // add http for Schema at default url /graphql
            app.UseGraphQL<ISchema>("/graphql");

            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });
        }
    }
}
