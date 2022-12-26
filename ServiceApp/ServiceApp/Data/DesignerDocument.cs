﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data;

public class DesignerDocument : Document
{
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public bool? IsApproved { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public bool? IsRequired { get; set; }
}