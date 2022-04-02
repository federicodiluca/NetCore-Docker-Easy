using Microsoft.EntityFrameworkCore;
using NetCore_Docker_Easy.Models;

namespace NetCore_Docker_Easy.Services;

public class FilmService : IFilmService
{
    private FilmDbContext _dbContext;
    public FilmService(FilmDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Film>> Get()
    {
        return await _dbContext.Film
            ?.ToListAsync()
            ?? new();
    }
    public async Task<Film> Get(int ID)
    {
        return await _dbContext.Film.Where(b => b.No == ID)
            .FirstOrDefaultAsync()
            ?? new();
    }
    public async Task Add(Film flm)
    {
        await _dbContext.AddAsync(flm);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Update(Film flm)
    {
        _dbContext.Update(flm);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Delete(int ID)
    {
        var del = _dbContext.Film.Where(b => b.No == ID).FirstOrDefault();
        if (del != null)
            _dbContext.Remove(del);

        await _dbContext.SaveChangesAsync();
    }
}
