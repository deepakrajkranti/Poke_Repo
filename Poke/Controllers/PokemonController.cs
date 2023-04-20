using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poke.Interfaces;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;

namespace Poke.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository,IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        

        [HttpGet]
        public IActionResult  GetPokemons()
        {

            var poki=_mapper.Map<List<PokemonDto>>(_pokemonRepository.GetAll());
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            else
            {
                return Ok(poki);
            }
        }


    }
}
