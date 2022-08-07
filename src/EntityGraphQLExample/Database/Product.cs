namespace EntityGraphQLExample.Database;

public class Product
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public ICollection<SubProduct> SubProducts { get; set; }
}