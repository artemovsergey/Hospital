using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Data.Models;
using Hospital.Service.Repositories;

namespace Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentsController : ControllerBase
    {
        private readonly DepartamentRepository repo;
        private readonly HospitalContext _context;

        public DepartamentsController(DepartamentRepository repo,HospitalContext context)
        {
            this.repo = repo;
            _context = context;
        }

 
        // GET: api/Departaments
        [HttpGet]
        public ActionResult<IEnumerable<Departament>> GetDepartaments()
        {
            return Ok(this.repo.GetDepartaments());
        }

        // GET: api/Departaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departament>> GetDepartament(int id)
        {
            var departament = await _context.Departaments.FindAsync(id);

            if (departament == null)
            {
                return NotFound();
            }

            return departament;
        }



        // POST: api/Departaments
       
        [HttpPost]
        public async Task<ActionResult<Departament>> PostDepartament(Departament departament)
        {
            _context.Departaments.Add(departament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartament", new { id = departament.Id }, departament);
        }


    }
}
