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
using System.Windows.Input;
using System.Windows.Navigation;



namespace StudentManagement_S
{
    public partial class StudentWindowVM : ObservableObject
    {
        [ObservableProperty]
        public Student selectedStudent;



        [ObservableProperty]
        public Module selectedModule;

        [ObservableProperty]
        public Student temselectedStudent;


        [ObservableProperty]
        public ObservableCollection<Student> tem_students;



        string user;


        private readonly DataBase dbContext;

        public string UserRole { get; set; }







        public StudentWindowVM(string username, DataBase dbContext, string role)
        {
            this.dbContext = dbContext;


            UserRole = role;



            user = username;

            LoadData();

            // temselectedStudent = tem_students.FirstOrDefault(s => s.StudentUserName == username);







        }


        public StudentWindowVM() { }

        public void LoadData()
        {
            selectedStudent = dbContext.Students
                 .Include(s => s.Modules)
                 .FirstOrDefault(s => s.StudentUserName == user);
        }


        [RelayCommand]
        private void Save()
        {
            try
            {
                dbContext.SaveChanges();
                MessageBox.Show("Student details saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("An error occurred while saving student details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        [RelayCommand]
        public void AddModule()
        {

            if (UserRole == "Admin")
            {
                var addmodulewindow = new AddModuleWindow(dbContext, selectedStudent.StudentUserName);

                addmodulewindow.ShowDialog();

                LoadData();

                //LoadData();

            }
            else
            {
                MessageBox.Show("Only Admin Can Add Modules.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }


        }


        [RelayCommand]
        private void RemoveModule()
        {
            if (UserRole != "Admin")
            {
                MessageBox.Show("Only Admin Can Remove Modules.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (selectedModule == null)
            {
                MessageBox.Show("Please select a module to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            if (selectedModule != null)
            {
                selectedStudent.Modules.Remove(selectedModule);





                CalculateGPA();

                dbContext.SaveChanges();

                //LoadData();
                // StudentWindowVM(selectedStudent.StudentUserName, dbContext, "Admin");

                MessageBox.Show("Module removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                LoadData();

            }
        }




        private void CalculateGPA()
        {



            double totalCredits = 0;
            double totalPoints = 0;

            foreach (var module in selectedStudent.Modules)
            {
                totalCredits += module.Credit;
                totalPoints += module.Credit * ConverGradeToPoints(module.Grade);

            }
            double gpa = totalPoints / totalCredits;

            if (gpa != 0)
            {

                selectedStudent.GPA = Math.Round(gpa, 3);
            }
            else
            {
                selectedStudent.GPA = 0;
            }


            dbContext.SaveChanges();


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
    }
}