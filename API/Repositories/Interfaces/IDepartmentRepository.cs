using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentId(int id);
        int Insert(Department division);
        int Delete(int id);
        int Update(int id, Department division);
    }
}
