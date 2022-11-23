using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Student
    {
        [BsonElement("_id")]
        [JsonPropertyName("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        public string Major { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? Courses { get; set; }
        [BsonIgnore]
        public List<Course>? CourseList { get; set; }
    }
}
