using MongoDB.Bson;
using MongoDB.Entities;

namespace Mentor.Domain.Entities
{
    public class Mentor : IEntity
    {
        public string Id { get; set; } // Jedinstveni identifikator
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Implementacija interfejsa IEntity
        public object GenerateNewID()
        {
            return new ObjectId(); // Ili drugi tip ID-a koji koristite
        }

        public bool HasDefaultID()
        {
            return string.IsNullOrEmpty(Id);
        }
    }
}