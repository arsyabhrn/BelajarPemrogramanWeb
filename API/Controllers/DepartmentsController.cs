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
                return Ok("Data Berhasil Ditambahkan");
            }
            else
            {
                return BadRequest("Data Gagal Ditambahkan");
            }
        }

        public IHttpActionResult Get()
        {
            var get = departmentRepository.GetDepartments();
            if(get.Count() == 0)
            {
                return BadRequest("Data Kosong");
            }
            return Ok(get);

        }
        public IHttpActionResult Get(int id)
        {
            var get = departmentRepository.GetDepartmentId(id);
            if(get == null)
            {
                return BadRequest("Data Tidak Ditemukan");
            }
            return Ok(get);
        }

        public IHttpActionResult Delete(int id)
        {
            var delete = departmentRepository.GetDepartmentId(id);
            if (delete == null)
            {
                return BadRequest("Data Tidak Ditemukan");
            }
            else
            {
                departmentRepository.Delete(id);
                return Ok("Data Berhasil Dihapus");
            }

        }
        public IHttpActionResult Put(int id, Department department)
        {
            try
            {
                var update = departmentRepository.Update(id, department);
                if(update == 1)
                {
                    return Ok("Data Berhasil Diperbarui");
                }
                else
                {
                    return Ok(update);
                }
            }
            catch(NullReferenceException)
            {
                return BadRequest("Data Tidak Ditemukan");
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return BadRequest("Nama Kolom Salah");
            }
        }
    }
}
