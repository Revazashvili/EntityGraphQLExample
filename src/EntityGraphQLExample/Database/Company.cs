namespace EntityGraphQLExample.Database;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Inn { get; set; }
    public string Status { get; set; }
    public DateOnly EstablishmentDate { get; set; }
    public ICollection<CompanyMember> CompanyMembers { get; set; }
}