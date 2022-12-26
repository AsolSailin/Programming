using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data;

public class Project
{
    [BsonId]
    [BsonIgnoreIfDefault]
    public ObjectId Id { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Department { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Name { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Customer { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Designer { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Developer { get; set; }

    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public Dictionary<string, bool> WaterDocuments { get; set; }

    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public Dictionary<string, bool> GasDocuments { get; set; }

    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public Dictionary<string, bool> DesignerDocuments { get; set; } 
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public List<string> LoadedFilesDev = new List<string>();
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public List<string> LoadedFilesDes = new List<string>();
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? designerOrganization;
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? developerOrganization;
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public bool? IsApproved { get; set; }
}