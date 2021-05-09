namespace Gateway
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Startup
    {
        public const string BooksService = "booksService";
        public const string AuthorsService = "authorsService";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient(AuthorsService, client => client.BaseAddress = new Uri("http://localhost:5000/graphql"));
            services.AddHttpClient(BooksService, client => client.BaseAddress = new Uri("http://localhost:5001/graphql"));

            services.AddGraphQLServer()
                .AddRemoteSchema(AuthorsService, ignoreRootTypes: false)
                .AddRemoteSchema(BooksService, ignoreRootTypes: false)
                .AddTypeExtensionsFromFile("./Stitching.graphql");
        }

        public void Configure(IApplicationBuilder app)
        {
            app
               .UseRouting()
               .UseEndpoints(endpoints => endpoints.MapGraphQL());
        }
    }
}
