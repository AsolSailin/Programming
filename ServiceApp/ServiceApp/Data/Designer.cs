using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ServiceApp.Data;

[Serializable]
public class Designer : Worker
{
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? ProjectOrganizationName { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    [StringLength(maximumLength: 13, MinimumLength = 13, ErrorMessage = "Must be 13 symbols long")]
    [Phone(ErrorMessage = "Must be number")]
    public string? OGRN { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    [StringLength(maximumLength: 12, MinimumLength = 12, ErrorMessage = "Must be 12 symbols long")]
    [Phone(ErrorMessage = "Must be number")]
    public string? INN { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "Must be 9 symbols long")]
    [Phone(ErrorMessage = "Must be number")]
    public string? KPP { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Adress { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Director { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? ChiefProjectEngineer { get; set; }
}