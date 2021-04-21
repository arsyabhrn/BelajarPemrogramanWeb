using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DepartmentsController : ApiController
    {
        DepartmentRepository departmentRepository = new DepartmentRepository();
        public IHttpActionResult Post(Department department)
        {
            var post = departmentRepository.Insert(department);
            if(post == 1)
            {
                return Ok("Data Has Been Inserted");
            }
            else
            {
                return BadRequest("Insert Data Failed");
            }
        }

        public IHttpActionResult Get()
        {
            var get = departmentRepository.GetDepartments();
            if(get.Count() == 0)
            {
                return BadRequest("Data Not Found");
            }
            return Ok(get);

        }
        public IHttpActionResult GetById(int id)
        {
            var get = departmentRepository.GetDepartmentId(id);
            if(get == null)
            {
                return BadRequest("Data Not Found");
            }
            return Ok(get);
        }

        public IHttpActionResult Delete(int id)
        {
            var delete = departmentRepository.GetDepartmentId(id);
            if (delete == null)
            {
                return BadRequest("Data Not Found");
            }
            else
            {
                departmentRepository.Delete(id);
                return Ok("Data Has Been Deleted");
            }

        }
        public IHttpActionResult Put(int id, Department department)
        {
            try
            {
                var update = departmentRepository.Update(id, department);
                if(update == 1)
                {
                    return Ok("Data Has Been Updated");
                }
                else
                {
                    return Ok(update);
                }
            }
            catch(NullReferenceException)
            {
                return BadRequest("Data Tidak Ditemukan, Masukkan ID Dengan Benar");
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return BadRequest("Nama Kolom Salah");
            }
        }
    }
}
