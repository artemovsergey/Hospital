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

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicalCardsController : ControllerBase
{
    private readonly MedicalCardRepository repo;
    private readonly HospitalContext _context;

    public MedicalCardsController(MedicalCardRepository repo,HospitalContext context)
    {
        this.repo = repo;
        _context = context;
    }

    // GET: api/MedicalCards
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicalCard>>> GetMedicalCards()
    {
        return await _context.MedicalCards.ToListAsync();
    }

    // GET: api/MedicalCards/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MedicalCard>> GetMedicalCard(int id)
    {
        var medicalCard = await _context.MedicalCards.FindAsync(id);

        if (medicalCard == null)
        {
            return NotFound();
        }

        return medicalCard;
    }


    // POST: api/MedicalCards
  
    [HttpPost]
    public async Task<ActionResult<MedicalCard>> PostMedicalCard(MedicalCard medicalCard)
    {
        repo.CreateMedicalCard(medicalCard);
        return CreatedAtAction("GetMedicalCard", new { id = medicalCard.Id }, medicalCard);
    }


}
