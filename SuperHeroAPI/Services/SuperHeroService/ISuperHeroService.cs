using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    // Create an Interface for SuperHeroService. In this case ISuperHeroService.
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero request);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
