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
    public class DivisionRepository : IDivisionRepository
    {
        myContext context = new myContext();

        public int Delete(int id)
        {
            context.Divisions.Remove(context.Divisions.FirstOrDefault(d => d.id == id));
            var delete = context.SaveChanges();
            return delete;
        }

        public Division GetDivisionId(int id)
        {
            return context.Divisions.Find(id);
        }

        public IEnumerable<Division> GetDivisions()
        {
            var get = context.Divisions.ToList();
            return get;
        }

        public int Insert(Division division)
        {
            context.Divisions.Add(division);
            var insert = context.SaveChanges();
            return insert;
        }

        public int Update(int id, Division division)
        {
            var update = context.Divisions.Find(id);
            update.name = division.name;
            update.about = division.about;
            context.Entry(update).State = EntityState.Modified;
            var updated = context.SaveChanges();

            return updated;
        }
    }
}