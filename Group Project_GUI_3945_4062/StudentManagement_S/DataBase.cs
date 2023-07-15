using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement_S
{
    public class DataBase : DbContext
    {

        public DbSet<User> Users { get; set; }


        public DbSet<Student> Students { get; set; }

        public readonly string _path = @"D:\3rd sem\GUI programing\project my one\aaa\Group Project\Student Management Sys - Copy - Copy\StudentManagement_S\data.db";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {_path}");
        }

        public void AddUser(ObservableCollection<User> users)
        {
            throw new NotImplementedException();
        }
    }
}
