using PokemonReviewApp.Models;

namespace Poke.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetAll();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        bool PokemonExists(int pokeId);
        decimal GetPokemonRating(int pokeId);
    }
}
