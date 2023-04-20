using Poke.Interfaces;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;

namespace Poke.Repository
{
    public class PokemonRepository:IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pokemon> GetAll()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var pol = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);

            return ((decimal)pol.Sum(p => p.Rating)/pol.Count());
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p=>p.Id == pokeId);
        }
    }
}
