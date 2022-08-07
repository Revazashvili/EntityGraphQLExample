namespace EntityGraphQLExample.Database;

public class CompanyMember
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Pin { get; set; }
    public string Status { get; set; }
    public CompanyMemberRole Role { get; set; }
    public DateOnly MembershipDate { get; set; }
    public ICollection<CompanyMemberPermission> Permissions { get; set; }
}