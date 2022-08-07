using EntityGraphQL.AspNet;
using EntityGraphQL.Schema;
using EntityGraphQLExample.Common;
using EntityGraphQLExample.Database;
using EntityGraphQLExample.Schema.Mutations;

namespace EntityGraphQLExample.Schema;

public static class Schema
{
    public static Action<AddGraphQLOptions<CibContext>> AddGraphQlOptions => options =>
    {
        options.ConfigureSchema = ConfigureSchema;
    };

    private static void ConfigureSchema(SchemaProvider<CibContext> schemaProvider)
    {
        schemaProvider.Query().AddField("activeCompanies",
            context => context.Companies.Where(x => x.Status == Constants.StatusActive).ToList(),
            "Fetch active companies");
        
        schemaProvider.AddMutationsFrom<CompanyMutations>();
        
        
        // write to file
        File.WriteAllText("schema.graphql", schemaProvider.ToGraphQLSchemaString());
    }
}