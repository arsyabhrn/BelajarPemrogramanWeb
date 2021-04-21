using API.Context;
using API.Models;
using API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        myContext context = new myContext();

        public int Delete(int id)
        {
            context.Departments.Remove(context.Departments.FirstOrDefault(d => d.id == id));
            var delete = context.SaveChanges();
            return delete;
        }

        public Department GetDepartmentId(int id)
        {
            return context.Departments.Find(id);
        }

        public IEnumerable<Department> GetDepartments()
        {
            var get = context.Departments.ToList();
            return get;
        }

        public int Insert(Department department)
        {
            context.Departments.Add(department);
            var insert = context.SaveChanges();
            return insert;
        }

        public int Update(int id, Department department)
        {
            var update = context.Departments.Find(id);
            update.name = department.name;
            update.divisionid = department.divisionid;
            context.Entry(update).State = EntityState.Modified;
            var updated = context.SaveChanges();

            return updated;
        }
    }
}