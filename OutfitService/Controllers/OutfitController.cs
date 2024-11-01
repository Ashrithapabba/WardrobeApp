using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutfitService.Data;
using OutfitService.Dto;
using OutfitService.Models;

namespace OutfitService.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class OutfitController : ControllerBase
{
    private readonly OutfitContext _context;
    private readonly IMapper _mapper;

    public OutfitController(OutfitContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Outfit - Retrieve all outfits
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OutfitDTo>>> GetOutfits()
    {
        var outfits = await _context.Outfits.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<OutfitDTo>>(outfits));
    }

    // POST: api/Outfit - Add a new outfit
    [HttpPost]
    public async Task<ActionResult> AddOutfit(OutfitDTo outfitDto)
    {
        var outfit = _mapper.Map<Outfit>(outfitDto);
        _context.Outfits.Add(outfit);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOutfits), new { id = outfit.Id }, outfitDto);
    }

    // PUT: api/Outfit/{id} - Update an existing outfit
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOutfit(int id, OutfitDTo outfitDto)
    {
        if (id != outfitDto.Id) return BadRequest();

        var outfit = await _context.Outfits.FindAsync(id);
        if (outfit == null) return NotFound();

        _mapper.Map(outfitDto, outfit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Outfit/{id} - Remove an outfit
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOutfit(int id)
    {
        var outfit = await _context.Outfits.FindAsync(id);
        if (outfit == null) return NotFound();

        _context.Outfits.Remove(outfit);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

}