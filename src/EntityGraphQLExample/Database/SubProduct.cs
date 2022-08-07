namespace EntityGraphQLExample.Database;

public class SubProduct
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public Product Product { get; set; }
}