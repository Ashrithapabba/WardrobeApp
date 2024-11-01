using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClosetService.Data;
using ClosetService.Models;
using ClosetService.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;

[ApiController]
[Route("api/[controller]")]

public class ClothingController : ControllerBase
{
    private readonly ClosetContext _context;
    private readonly IMapper _mapper;

    public ClothingController(ClosetContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/clothing/category/{category}
    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<ClothingItemDto>>> GetClothingItemsByCategory(OutfitCategory category)
    {
        var items = await _context.ClothingItems
                                  .Where(item => item.Category == category)
                                  .ToListAsync();
        return Ok(_mapper.Map<IEnumerable<ClothingItemDto>>(items));
    }

    // POST: api/clothing
    [HttpPost]
    public async Task<ActionResult> AddClothingItem(ClothingItemDto clothingItemDto)
    {
        var clothingItem = _mapper.Map<ClothingItem>(clothingItemDto);
        _context.ClothingItems.Add(clothingItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClothingItemsByCategory), new { id = clothingItem.Id }, clothingItemDto);
    }

    // GET: api/clothing
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClothingItemDto>>> GetAllClothingItems(string date)
    {
        var query = _context.ClothingItems.OrderBy(x => x.Category).AsQueryable();

        // var items = await _context.ClothingItems.ToListAsync();
        // return Ok(_mapper.Map<IEnumerable<ClothingItemDto>>(items));

        return await query.ProjectTo<ClothingItemDto>(_mapper.ConfigurationProvider).ToListAsync();
    }
    
    [HttpPost("{id}/upload-photo")]
    public async Task<ActionResult> UploadPhoto(int id, IFormFile photo)
    {
        var item = await _context.ClothingItems.FindAsync(id);
        if (item == null) return NotFound();

        if (photo != null && photo.Length > 0)
        {
            // Define the file path
            var fileName = $"{Guid.NewGuid()}_{photo.FileName}";
            var filePath = Path.Combine("wwwroot/images", fileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            // Update the ImageUrl
            item.ImageUrl = $"/images/{fileName}";
            await _context.SaveChangesAsync();
        }

        return Ok(new { ImageUrl = item.ImageUrl });
    }

    [HttpPut("{id}/update-photo")]
    public async Task<ActionResult> UpdatePhoto(int id, IFormFile newPhoto)
    {
        var item = await _context.ClothingItems.FindAsync(id);
        if (item == null) return NotFound();

        if (newPhoto != null && newPhoto.Length > 0)
        {
            // Delete the old photo if it exists
            if (!string.IsNullOrEmpty(item.ImageUrl))
            {
                var oldFilePath = Path.Combine("wwwroot", item.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            // Save the new photo
            var fileName = $"{Guid.NewGuid()}_{newPhoto.FileName}";
            var filePath = Path.Combine("wwwroot/images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await newPhoto.CopyToAsync(stream);
            }

            item.ImageUrl = $"/images/{fileName}";
            await _context.SaveChangesAsync();
        }

        return Ok(new { ImageUrl = item.ImageUrl });
    }
    [HttpDelete("{id}/delete-photo")]
    public async Task<ActionResult> DeletePhoto(int id)
    {
        var item = await _context.ClothingItems.FindAsync(id);
        if (item == null) return NotFound();

        if (!string.IsNullOrEmpty(item.ImageUrl))
        {
            var filePath = Path.Combine("wwwroot", item.ImageUrl.TrimStart('/'));
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            item.ImageUrl = null;
            await _context.SaveChangesAsync();
        }

            return NoContent();
    }


}
