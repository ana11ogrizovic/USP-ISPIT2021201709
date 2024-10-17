using MongoDB.Bson;
using MongoDB.Entities;

namespace Mentor.Domain.Entities;

public class Subject : Entity
{
    
    public int SubjectId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Type { get; set; }
    
}