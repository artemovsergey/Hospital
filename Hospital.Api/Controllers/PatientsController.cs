using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Service.Repositories;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly PatientRepository repo;
    private readonly HospitalContext _context;

    public PatientsController(PatientRepository repo, HospitalContext context)
    {
        this.repo = repo;
        _context = context;
    }

    // GET: api/Patients
    [HttpGet]
    public ActionResult<IEnumerable<Patient>> GetPatients()
    {
        return this.repo.GetPatients().ToList();
    }

    // GET: api/Patients/FindByPassport&serial=a&number=b
    [HttpGet]
    [Route("FindByPassport")]
    public async Task<ActionResult<Patient>> GetPatientByPassport(string serial, string number)
    {
        
        var patient = repo.FindByPassport(serial, number);

        if (patient == null)
        {
            return NotFound();
        }

        return patient;
    }

    // PUT: api/Patients/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPatient(int id, Patient patient)
    {
        if (id != patient.Id)
        {
            return BadRequest();
        }

        _context.Entry(patient).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PatientExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Patients
    [HttpPost]
    public async Task<ActionResult<Patient>> PostPatient(Patient patient)
    {
        repo.CreatePatient(patient);

        return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
    }

    // DELETE: api/Patients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return NotFound();
        }

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PatientExists(int id)
    {
        return _context.Patients.Any(e => e.Id == id);
    }
}
