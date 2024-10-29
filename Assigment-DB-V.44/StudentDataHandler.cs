using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_DB_V._44
{
    internal class StudentDataHandler
    {
        public StudentDbContext dbContext = new StudentDbContext();

        public void RegisterStudent(string firstName, string lastName, string city)
        {
            if (firstName == null || lastName == null || city == null)
                return;

            firstName = FormatData(firstName);
            lastName = FormatData(lastName);
            city = FormatData(city);

            dbContext.Add(new Student { FirstName = firstName, LastName = lastName, City = city });
            dbContext.SaveChanges();
        }

        public void ModifyStudent(int id, int menuSelected, string changedData)
        {
            var student = dbContext.Students.Where(s => s.StudentId == id).FirstOrDefault<Student>();

            if (student == null)
                return;
            changedData = FormatData(changedData);

            switch (menuSelected)
            {
                case 1:
                    student.FirstName = changedData;
                    dbContext.SaveChanges();
                    return;
                case 2:
                    student.LastName = changedData;
                    dbContext.SaveChanges();
                    return;
                case 3:
                    student.City = changedData;
                    dbContext.SaveChanges();
                    return;
                default:
                    return;

            }


        }

        public string FormatData(string data)
        {
            data = data[0].ToString().ToUpper() + data.Substring(1);
            return data;
        }

    }
}
