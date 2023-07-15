using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentManagement_S
{
    public partial class AddStudentVM : ObservableObject
    {
        private readonly DataBase dbContextStudent;


        public ObservableCollection<Module> Modules { get; set; }


        bool addedModule = false;


        [ObservableProperty]
        public string indexNo;

        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string studentUserName;






        public Module SelectedModule { get; set; }

        [ObservableProperty]
        public Student selectedStudent;




        public ObservableCollection<Student> Students { get; set; }

        public ObservableCollection<User> Users { get; set; }







        public AddStudentVM(DataBase dbContextStudent)
        {
            this.dbContextStudent = dbContextStudent;


            Students = new ObservableCollection<Student>(dbContextStudent.Students);

            Users = new ObservableCollection<User>(dbContextStudent.Users);




        }

        public AddStudentVM()
        {

        }


        [RelayCommand]
        public void AddStudent()
        {
            if (string.IsNullOrWhiteSpace(studentUserName))
            {
                MessageBox.Show("Please enter the student's username.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;


            }
            var existingStudent = Students.FirstOrDefault(s => s.StudentUserName == studentUserName);

            var existingUser = Users.FirstOrDefault(u => u.UserName == studentUserName);
            if (existingUser == null)
            {
                MessageBox.Show("Student does not registed as a User,Before add Student you have to add as a User", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (existingStudent != null)
            {
                MessageBox.Show("Student allready exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (existingUser.Role != "Student")
            {
                MessageBox.Show("This User Role is Not Student", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            var newStudent = new Student
            {
                StudentUserName = studentUserName,
                FirstName = firstName,
                LastName = lastName,

                IndexNo = indexNo,
                Modules = new ObservableCollection<Module>()

            };


            Students.Add(newStudent);
            dbContextStudent.Students.Add(newStudent);
            dbContextStudent.SaveChanges();


            MessageBox.Show("Student added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }



        [RelayCommand]
        private void AddModule()
        {



            if (string.IsNullOrWhiteSpace(studentUserName))
            {
                MessageBox.Show("Please enter the student's username.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            selectedStudent = Students.FirstOrDefault(s => s.StudentUserName == studentUserName);

            var addmodulewindow = new AddModuleWindow(dbContextStudent, selectedStudent.StudentUserName);

            addmodulewindow.ShowDialog();



            addedModule = true;





            MessageBox.Show("Module added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);








        }

        [RelayCommand]
        private void SaveStudent()
        {
            if (string.IsNullOrWhiteSpace(studentUserName) || string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter the student's username.and Stdent Details", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {

                if (addedModule == true)
                {
                    CalculateGPA();
                }


                dbContextStudent.SaveChanges();
                MessageBox.Show("Student Add Successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);






                // Open the main window

            }




        }



        public void CalculateGPA()
        {

            selectedStudent = Students.FirstOrDefault(s => s.StudentUserName == studentUserName);

            double totalCredits = 0;
            double totalPoints = 0;

            foreach (var module in selectedStudent.Modules)
            {
                totalCredits += module.Credit;
                totalPoints += module.Credit * ConverGradeToPoints(module.Grade);

            }
            double gpa = totalPoints / totalCredits;

           
            double roundedGPA = Math.Round(gpa, 3);
            if (roundedGPA >= 0.001 && roundedGPA <= 4.0)
            {
                selectedStudent.GPA = roundedGPA;
            }


          

            dbContextStudent.SaveChanges();

        }

        private double ConverGradeToPoints(string grade)
        {
            double point;

            switch (grade.ToUpper())
            {
                case "A+":
                    point = 4.0;
                    break;
                case "A":
                    point = 4.0;
                    break;
                case "A-":
                    point = 3.7;
                    break;
                case "B+":
                    point = 3.3;
                    break;
                case "B":
                    point = 3.0;
                    break;
                case "B-":
                    point = 2.7;
                    break;
                case "C+":
                    point = 2.3;
                    break;
                case "C":
                    point = 2.0;
                    break;
                case "C-":
                    point = 1.7;
                    break;

                default:
                    point = 0.0;
                    break;
            }

            return point;
        }



        [RelayCommand]
        public void AddUser()
        {

            Window window;

            window = new AddUserWindow();
            window.ShowDialog();

            dbContextStudent.SaveChanges();
            Users = new ObservableCollection<User>(dbContextStudent.Users);


        }



    }

}