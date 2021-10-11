using System.Collections.Generic;
using Apbd14.DTO.Response;
using Apbd14.Models;

namespace Apbd14.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<StudentResponse> GetStudents();
        Student GetStudentById(int idStudent);
        bool DeleteStudent(int idStudent);
    }
}
