using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace StudentManagement_S
{
    public partial class LoginWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;

        public readonly DataBase dbContextB;

        public LoginWindowVM(DataBase _dbContext)
        {
            dbContextB = _dbContext;
        }

        public LoginWindowVM()
        {

        }

        [RelayCommand]
        public void Login()
        {
            var user =dbContextB.Users.FirstOrDefault(u =>u.UserName == username && u.Password==password);



            if (user != null)
            {
                Window window;
                if(user.Role=="Admin")
                {

                
                   window = new MainWindow();
                   window.Show();
                   

                }
                else
                {

                    var studentWindow = new StudentWindow(user.UserName, dbContextB,user.Role);
                    studentWindow.Show();
                }

                App.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Invalid  UserName or Password", "Error",MessageBoxButton.OK, MessageBoxImage.Error);   
            }
        }


    }
}
