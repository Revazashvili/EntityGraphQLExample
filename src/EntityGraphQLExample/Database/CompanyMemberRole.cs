using System.Text.Json.Serialization;

namespace EntityGraphQLExample.Database;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CompanyMemberRole
{
    Admin,
    Accountant
}