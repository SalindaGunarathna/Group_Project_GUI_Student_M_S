using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement_S
{
    public partial class EditUserVM : ObservableObject
    {
        private readonly DataBase userDatabse;

        [ObservableProperty]
        public User selectedUser;

          User   existingUser { get; set; } 

        public ObservableCollection<User> users;

        [ObservableProperty]
        public Student selectedStudent;

        [ObservableProperty]
        public string temUsername;

        public string taskType;


        [ObservableProperty]
        public string userRole;


        [ObservableProperty]
        public ObservableCollection<string> roles = new ObservableCollection<string>
        {
            "Admin",
            "Student"
        };



        public EditUserVM(DataBase userDatabse, string username,string task)
        {
            this.userDatabse = userDatabse;

            selectedUser = userDatabse.Users.FirstOrDefault(u => u.UserName == username);


            users = new ObservableCollection<User>(userDatabse.Users);
            taskType = task;

            userRole = selectedUser.Role;

        }

        public EditUserVM() { }





        [RelayCommand]
        public void UpdateUser()
        {



             existingUser = userDatabse.Users.FirstOrDefault(u => u.UserName == selectedUser.UserKey);




            var newexistingUser = userDatabse.Users.FirstOrDefault(u => u.UserName == selectedUser.UserName);



            if (newexistingUser != null && selectedUser.UserName != selectedUser.UserKey)
            {
                MessageBox.Show("User allredy exit ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;



            }





            if (existingUser.Role == "Student")
            {

                

                selectedStudent = userDatabse.Students.Include(s => s.Modules).FirstOrDefault(s => s.StudentUserName == selectedUser.UserKey);

                if (selectedUser.Role != userRole && selectedStudent!= null)
                {
                    MessageBox.Show("Cant Change student Role ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (selectedStudent != null)
                {

                    selectedStudent.StudentUserName = selectedUser.UserName;

                    selectedUser.UserKey = selectedUser.UserName;



                    userDatabse.SaveChanges();

                    MessageBox.Show("User details saved successfully and your StudentUserName also Updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


                }
                else
                {
                    userDatabse.SaveChanges();

                    MessageBox.Show("User details saved successfully .", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }


               



            }
            else if (existingUser.Role == "Admin")
            {

                selectedUser.UserKey = selectedUser.UserName;

                selectedUser.Role = userRole;


                userDatabse.SaveChanges();
                MessageBox.Show("User details saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }



        }

    }
}
