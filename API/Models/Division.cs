using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("TB_M_Division")]
    public class Division
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string about { get; set; }

        public ICollection<Department> Departments { get; set; }
    }


    [Table("TB_T_Department")]
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }

        [ForeignKey("Division")]
        public int divisionid { get; set; }
        public Division Division { get; set; }
    }
}