using System.Linq.Expressions;
using EntityGraphQL.Schema;
using EntityGraphQLExample.Common;
using EntityGraphQLExample.Database;

namespace EntityGraphQLExample.Schema.Mutations;

public class CompanyMutations
{
    [MutationArguments]
    public class AddCompanyModel
    {
        public string Name { get; set; }
        public string Inn { get; set; }
        public DateTime EstablishmentDate { get; set; }
    }
    
    [GraphQLMutation("Add a new person to the system")]
    public Expression<Func<CibContext, Company>> AddCompany(CibContext db, AddCompanyModel model)
    {
        var company = new Company
        {
            Name = model.Name,
            Inn = model.Inn,
            EstablishmentDate = model.EstablishmentDate,
            Status = Constants.StatusActive,
        };
        db.Companies.Add(company);
        db.SaveChanges();
        return ctx => ctx.Companies.First(p => p.Id == company.Id);
    }
}