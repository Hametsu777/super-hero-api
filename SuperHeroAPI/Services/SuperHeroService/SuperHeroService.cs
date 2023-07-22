using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    // SuperHeroService will contain the logic or code for the methods in ISuperHeroService, etc to work.
    // SuperHeroService needs to implement ISuperHeroService.
    public class SuperHeroService : ISuperHeroService
    {
        //private static List<SuperHero> superHeroes = new List<SuperHero>
        //    {
        //        new SuperHero
        //        {   Id = 1,
        //            Name = "Spider Man",
        //            FirstName = "Peter",
        //            LastName = "Parker",
        //            Place = "New York City"
        //        },
        //        new SuperHero
        //        {   Id = 2,
        //            Name = "Iron Man",
        //            FirstName = "Tony",
        //            LastName = "Stark",
        //            Place = "Malibu"
        //        }

        //    };
        private readonly DataContext _context;

        // Need a constructor to inject the data context again.
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
            //return superHeroes;
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        // When using async, need to change to Task<List<Superhero>> instead of List<Superhero>
        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
            //return superHeroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {
            // Don't need to find id this way since we are now finding it by the primary key.
            //var hero = superHeroes.Find(x => x.Id == id);
            // Code gets superhero from the database.
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }

            // Code changes the properties.
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            // Have to tell entity framework that there was a change and this need to be written to the database.
            // Or saved. Saves changes.
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
