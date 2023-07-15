using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace StudentManagement_S
{
    public partial class AdminWindowVM : ObservableObject
    {

        private readonly DataBase dbContext;



        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Student> Students { get; set; }


        [ObservableProperty]
        public User selectedUser;

        [ObservableProperty]
        public Student selectedStudent;

        public ICommand DeleteUserCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand SaveChangesCommand { get; set; }

        public ICommand AddStudentCommand { get; set; }

       
        public AdminWindowVM(DataBase dbContext)
        {
            this.dbContext = dbContext;

            LoadData();

            DeleteUserCommand = new RelayCommand(DeleteUser);
            DeleteStudentCommand = new RelayCommand(DeleteStudent);
            SaveChangesCommand = new RelayCommand(SaveChanges);
            AddStudentCommand = new RelayCommand(AddStudent);
            
        }

        public AdminWindowVM() { }



        private void LoadData()
        {
            // Load users from the database
            Users = new ObservableCollection<User>(dbContext.Users);

            // Load students from the database
            Students = new ObservableCollection<Student>(dbContext.Students.Include(s => s.Modules));
        }

        private void DeleteUser()
        {
            if (selectedUser != null)
            {
                // Remove the selected user from the collection

                // Remove the selected user from the database
                dbContext.Users.Remove(selectedUser);
                Users.Remove(selectedUser);
                dbContext.SaveChanges();
            }
        }

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
            }
        }

        private void SaveChanges()
        {
            try
            {
                // Save changes to the database
                dbContext.SaveChanges();
                MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                var adminwindow = new MainWindow();
                adminwindow.Show();

               

            }
            catch
            {
                MessageBox.Show("An error occurred while saving changes.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            App.Current.MainWindow.Close();
        }



        private void AddStudent()
        {




            

            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.ShowDialog();


            var currentWindow = Application.Current.MainWindow;
            currentWindow.Close();


            // Reload data after the AddStudentWindow is closed









        }

        [RelayCommand]
        private void AddUser()
        {

            Window window;

         
            window = new AddUserWindow();
            window.Show();

          

            



        }
    }
}
