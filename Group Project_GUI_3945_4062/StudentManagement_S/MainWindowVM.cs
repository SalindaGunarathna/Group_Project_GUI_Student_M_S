using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Reflection.Metadata.Ecma335;

namespace StudentManagement_S
{
    public partial class MainWindowVM : ObservableObject
    {

        private readonly DataBase dbContext;


        [ObservableProperty]
        public ObservableCollection<User> users;


        [ObservableProperty]
        public ObservableCollection<Student> students;


        [ObservableProperty]
        public User selectedUser;

        [ObservableProperty]
        public Student selectedStudent;



        public MainWindowVM(DataBase dbContext)
        {
            this.dbContext = dbContext;

            LoadData();


        }

        public MainWindowVM() { }





        private void LoadData()
        {
            // Load users from the database
            Users = new ObservableCollection<User>(dbContext.Users);

            // Load students from the database
            Students = new ObservableCollection<Student>(dbContext.Students.Include(s => s.Modules));
        }



        [RelayCommand]
        private void DeleteUser()
        {
            if (selectedUser != null)
            {
                // Remove the selected user from the collection

                // Remove the selected user from the database

                var exitStudent = dbContext.Students.Include(s => s.Modules).FirstOrDefault(s => s.StudentUserName == selectedUser.UserName);

                if (exitStudent != null)
                {

                    MessageBox.Show("This User Has Student accont Therefore Can not Delate ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                    

                }
                else
                {

                    string name = selectedUser.UserName;

                    dbContext.Users.Remove(selectedUser);
                    Users.Remove(selectedUser);
                    dbContext.SaveChanges();

                    MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

                    LoadData();

                }


                

               
            }
        }



        [RelayCommand]
        private void DeleteStudent()
        {
            if (selectedStudent != null)
            {
                // Remove the selected student from the collection
                string name = selectedStudent.FirstName;



                // Remove the selected student from the database
                dbContext.Students.Remove(selectedStudent);
                Students.Remove(selectedStudent);

                dbContext.SaveChanges();
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

                LoadData();
            }
        }


        [RelayCommand]
        private void SaveChanges()
        {
            try
            {
                // Save changes to the database
                dbContext.SaveChanges();

                LoadData(); 
                MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("An error occurred while saving changes.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        [RelayCommand]
        private void AddStudent()
        {

           


            var addstudent = new AddStudentWindow();

            addstudent.ShowDialog();

            LoadData();

            /*AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.ShowDialog();

            var currentWindow = Application.Current.MainWindow;
            currentWindow.Close();*/
           
        }

        [RelayCommand]
        private void AddUser()
        {



            Window window;

            window = new AddUserWindow();
            window.ShowDialog();


            LoadData();
        }

        [RelayCommand]
        private void EditUser()
        {
            if (selectedUser == null)
            {
                MessageBox.Show("pleace select user", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (selectedUser != null)
            {
                var editWindow = new EditUserWindow(dbContext, selectedUser.UserName,"EditUser");
                editWindow.ShowDialog();

                LoadData();

                

            }

            LoadData();
        }

        [RelayCommand]
        private void EditStudent()
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("pleace select user", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var editstudentwindow = new StudentWindow(selectedStudent.StudentUserName,dbContext,"Admin" );
            editstudentwindow.ShowDialog();

            LoadData();
        }


    }
}







