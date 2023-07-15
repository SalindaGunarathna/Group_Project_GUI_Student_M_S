using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Actions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace StudentManagement_S
{
    public partial class AddModuleWindowVM : ObservableObject
    {

        public Student selectedStudent;

        private readonly DataBase dbContext;

        [ObservableProperty]
        public string moduleName;

        [ObservableProperty]
        public string moduleCode;

        [ObservableProperty]
        public double credit;

        [ObservableProperty]
        public string grade;



        [ObservableProperty]
        public ObservableCollection<string> modules;





        [ObservableProperty]
        public ObservableCollection<double> creadits = new ObservableCollection<double>
        {
           0, 1, 2, 3,4
        };




        [ObservableProperty]
        public ObservableCollection<string> grades = new ObservableCollection<string>
        {
            "A+",
            "A",
            "A-",
            "B+",
            "B",
            "B-",
            "C+",
            "C",
            "C-",
            "E"

        };

        public AddModuleWindowVM(DataBase dbContext, string username)
        {
            this.dbContext = dbContext;
            selectedStudent = dbContext.Students
               .Include(s => s.Modules)
               .FirstOrDefault(s => s.StudentUserName == username);
           
            if (selectedStudent is null)
            {
                MessageBox.Show("Student not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }


        public AddModuleWindowVM() { }





        [RelayCommand]
        public void SaveModule()
        {
            if (string.IsNullOrWhiteSpace(moduleName) || string.IsNullOrWhiteSpace(moduleCode) || credit < 0)
            {
                MessageBox.Show("Please enter valid module details", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (selectedStudent is null)
            {
                MessageBox.Show("Student not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var NewModule = new Module
            {
                ModuleName = moduleName,
                ModuleCode = moduleCode,
                Credit = credit,
                Grade = grade,


            };

            selectedStudent?.Modules?.Add(NewModule);

            CalculateGPA();


            dbContext.SaveChanges();

          
            MessageBox.Show("Module added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


            moduleName = string.Empty;  
            moduleCode = string.Empty;
            credit = 0;
            grade = string.Empty;








        }

       
      
      


        public void CalculateGPA()
        {

            

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
                case "E":
                    point = 0.0;
                    break;

                default:
                    point = 0.0;
                    break;
            }

            return point;
        }

      

    }
}
