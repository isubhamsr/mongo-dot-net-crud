using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudentService
    {
        //private readonly IMongoCollection<Student> _students;

        //public StudentService(ISchoolDatabaseSettings settings, IMongoClient mongoClient)
        //{
        //    var client = new MongoClient(settings.ConnectionString);
        //    var database = client.GetDatabase(settings.DatabaseName);
        //    _students = database.GetCollection<Student>(settings.StudentsCollectionName);

        //    var database = mongoClient.GetDatabase(settings.DatabaseName);
        //    _students = database.GetCollection<Student>(settings.StudentsCollectionName);
        //}

        private readonly IMongoCollection<Student> _students;

        public StudentService(
            IOptions<SchoolDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

            _students = mongoDatabase.GetCollection<Student>(
                settings.Value.StudentsCollectionName);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _students.Find(s => true).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _students.Find<Student>(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await _students.InsertOneAsync(student);
            return student;
        }

        public async Task UpdateAsync(string id, Student student)
        {
            await _students.ReplaceOneAsync(s => s.Id == student.Id, student, new UpdateOptions() { IsUpsert = false });
        }

        public async Task DeleteAsync(string id)
        {
            await _students.DeleteOneAsync(s => s.Id == id);
        }
    }
}
