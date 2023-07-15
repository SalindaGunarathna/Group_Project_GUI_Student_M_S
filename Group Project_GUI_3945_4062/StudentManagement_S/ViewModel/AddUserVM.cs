using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace StudentManagement_S
{
    public partial class AddUserVM : ObservableObject
    {

        private readonly DataBase dbContextUser;

        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public string role;

        public ObservableCollection<User> users;

        [ObservableProperty]
        private string selectedRole;
     

        public AddUserVM()
        {

        }

        public AddUserVM(DataBase dbContextUser)
        {
            this.dbContextUser = dbContextUser;

            users = new ObservableCollection<User>(dbContextUser.Users); 
            
        }

        [ObservableProperty]
        public ObservableCollection<string> roles = new ObservableCollection<string>
        {
            "Admin",
            "Student"
        };

        

        [RelayCommand]
        public void AddUser()
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please enter valid user details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingUser = users.FirstOrDefault(u=> u.UserName ==userName);

            if (existingUser != null)
            {
                MessageBox.Show("User already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            var NewUser = new User
            {
                UserName = userName,
                Password = password,
                Role = role,
                UserKey= userName
            };

            users.Add(NewUser);
            dbContextUser.Users.Add(NewUser);
            dbContextUser.SaveChanges();

            MessageBox.Show("User added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


            

          

            
        }

    }

        
    
}
