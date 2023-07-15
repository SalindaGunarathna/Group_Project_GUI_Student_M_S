using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement_S
{
    public class Student
    {

        [Key]
        public int StdentNo { get; set; }

        [Required]
        public string? StudentUserName { get; set; }

        [Required]
        public string? IndexNo { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public double GPA { get; set; }


        public ObservableCollection<Module> Modules { get; set; }


        public Student()
        {
            Modules = new ObservableCollection<Module>();
            IndexNo = null;
            FirstName = null;
            LastName = null;
            GPA = 0.0;

        }

        public void RegisterModule(Module module)
        {
            Modules.Add(module);
        }




    }

    public class Module
    {
        [Key]
        public int NoOfModule { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public double Credit { get; set; }

        public string Grade { get; set; }
    }
}