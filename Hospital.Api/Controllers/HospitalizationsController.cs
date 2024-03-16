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
    public class HospitalizationsController : ControllerBase
    {
        private readonly HospitalizationRepository repo;
        private readonly HospitalContext _context;

        public HospitalizationsController(HospitalizationRepository repo,HospitalContext context)
        {
            this.repo = repo;
            _context = context;
        }

        // GET: api/Hospitalizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospitalization>>> GetHospitalizations()
        {
            return await _context.Hospitalizations.ToListAsync();
        }

        // GET: api/Hospitalizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hospitalization>> GetHospitalization(int id)
        {
            var hospitalization = await _context.Hospitalizations.FindAsync(id);

            if (hospitalization == null)
            {
                return NotFound();
            }

            return hospitalization;
        }

        // POST: api/Hospitalizations
       
        [HttpPost]
        public async Task<ActionResult<Hospitalization>> PostHospitalization(Hospitalization hospitalization)
        {
            this.repo.CreateHospitalization(hospitalization);

            return CreatedAtAction("GetHospitalization", new { id = hospitalization.Id }, hospitalization);
        }

    }
}
