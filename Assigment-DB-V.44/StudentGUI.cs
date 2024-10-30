using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_DB_V._44
{
    internal class StudentGUI
    {
        StudentDataHandler studentData = new StudentDataHandler();


        public void StartMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Student Database");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Please select your inquiry");
                Console.WriteLine("1: Register student ");
                Console.WriteLine("2: Modify current student");
                Console.WriteLine("3: List current students");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("4: Exit application");

                if (int.TryParse(Console.ReadLine(), out int menuSelect))
                {

                    switch (menuSelect)
                    {
                        case 1:
                            MenuRegisterStudent();
                            Console.WriteLine("\nPress Enter to return to menu");
                            Console.ReadLine();
                            break;
                        case 2:
                            MenuModifyStudent();
                            Console.WriteLine("\nPress Enter to return to menu");
                            Console.ReadLine();
                            break;
                        case 3:
                            ListAllStudents();
                            Console.WriteLine("\nPress Enter to return to menu");
                            Console.ReadLine();
                            break;
                        default:
                            break;
                    }

                }

                if (menuSelect == 4)
                    break;
            } while (true);

        }

        public void MenuRegisterStudent()
        {
            var valid = false;

            do
            {
                Console.Clear();
                Console.Write("Please enter student firstname: ");
                string? firstName = Console.ReadLine();
                Console.Write("\nPlease enter student Lastname: ");
                string? lastName = Console.ReadLine();
                Console.Write("\nPlease enter student City: ");
                string? cityName = Console.ReadLine();

                if (firstName != null && lastName != null && cityName != null)
                {
                    if (!firstName.Any(char.IsDigit) && !lastName.Any(char.IsDigit) && !cityName.Any(char.IsDigit))
                    {
                        studentData.RegisterStudent(firstName, lastName, cityName);
                        valid = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Data! \nPress Enter to try again: ");
                        Console.ReadLine();

                        break;

                    }
                }

            } while (valid == false);


        }
        public void MenuModifyStudent()
        {
            var valid = false;

            do
            {
                Console.Clear();
                Console.Write("Current Student In Database \n--------------------------------------------------------------------\n");
                ListAllStudents();
                Console.WriteLine("----------------------------------------------------------------------");


                Console.Write("\nPlease enter student id of student you want to modify: ");

                if (int.TryParse(Console.ReadLine(), out int studentId))
                {
                    foreach (Student student in studentData.dbContext.Students)
                    {
                        if (studentId == student.StudentId)
                        {
                            valid = true;
                        }


                    }
                    if (valid == false)
                    {
                        Console.WriteLine("Invalid Id");
                        return;
                    }
                    Console.WriteLine("\nEnter 1: to change Firstname | Enter 2: to change Lastname | Enter 3: to change City ");
                    if (int.TryParse(Console.ReadLine(), out int menuSelected) && valid == true)
                    {
                        Console.Write("\nEnter what you want it changed to: ");
                        string? changedData = Console.ReadLine();

                        if (!changedData.Any(char.IsDigit))
                        {
                            studentData.ModifyStudent(studentId, menuSelected, changedData);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Data! ");

                        }

                    }

                }
            } while (valid == false);
        }

        public void ListAllStudents()
        {
            foreach (Student student in studentData.dbContext.Students)
            {
                Console.WriteLine($"Student id: {student.StudentId}".PadRight(15) +
                    $"| Name: {student.FirstName}".PadRight(15) +
                    $" {student.LastName}".PadRight(15) +
                    $"| City: {student.City}".PadRight(15));
            }
        }

    }
}
