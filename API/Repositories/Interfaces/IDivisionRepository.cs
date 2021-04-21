using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface IDivisionRepository
    {
        IEnumerable<Division> GetDivisions();
        Division GetDivisionId(int id);
        int Insert(Division division);
        int Delete(int id);
        int Update(int id,Division division);
    }
}
