using FluentAssertions;
using Microsoft.EntityFrameworkCore;

using StudentManagement_S;
using System.Collections.ObjectModel;
using System.Windows;

namespace TestProject3
{
    public class UnitTest1
    {
        [Fact]
        public void AddStudent_WhenStudentUserNameIsNull_ShouldShowErrorMessage()
        {
            // Arrange
            var dbContextStudent = new DataBase();
            var addStudentVM = new AddStudentVM(dbContextStudent);

            // Act
            addStudentVM.AddStudent();

        
        }

        [Fact]
        public void AddStudent_WhenExistingStudent_ShouldShowErrorMessage()
        {
            // Arrange
            var dbContextStudent = new DataBase();
            var addStudentVM = new AddStudentVM(dbContextStudent);
            addStudentVM.studentUserName = "existingStudent";

            // Add an existing student with the same username
            dbContextStudent.Students.Add(new Student { StudentUserName = "existingStudent" });

            // Act
            addStudentVM.AddStudent();

        }
        public void AddModule_WhenUserRoleIsAdmin_ShouldShowAddModuleWindow()
        {
            // Arrange
            var dbContext = new DataBase();
            var studentWindowVM = new StudentWindowVM("username", dbContext, "Admin");

            // Act
            studentWindowVM.AddModule();

            
        }

        [Fact]
        public void AddModule_WhenUserRoleIsNotAdmin_ShouldShowErrorMessage()
        {
            // Arrange
            var dbContext = new DataBase();
            var studentWindowVM = new StudentWindowVM("username", dbContext, "Student");

            // Act
            studentWindowVM.AddModule();

        }
        
        
        


        [Fact]
        public void SaveModule_WhenModuleDetailsAreInvalid_ShouldShowErrorMessage()
        {
            // Arrange
            var dbContext = new DataBase();
            var addModuleWindowVM = new AddModuleWindowVM(dbContext, "username");
            // Set invalid module details
            addModuleWindowVM.moduleName = string.Empty;
            addModuleWindowVM.moduleCode = "M001";
            addModuleWindowVM.credit = -1;
            addModuleWindowVM.grade = "A+";

            // Act
            addModuleWindowVM.SaveModule();

           
        }
       



    }
}