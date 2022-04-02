using NetCore_Docker_Easy.Models;

namespace NetCore_Docker_Easy.Services
{
    public interface IFilmService
    {
        Task Add(Film flm);
        Task Delete(int ID);
        Task<List<Film>> Get();
        Task<Film> Get(int ID);
        Task Update(Film flm);
    }
}