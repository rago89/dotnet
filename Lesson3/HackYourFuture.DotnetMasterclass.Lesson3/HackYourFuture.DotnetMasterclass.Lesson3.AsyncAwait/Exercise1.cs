using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackYourFuture.DotnetMasterclass.Lesson3.AsyncAwait
{
    // Build your own Pokédex based on this API https://pokeapi.co/
    // A program that asks the user for a name of a pokémon
    // Display the properties of that pokémon in the Console
    public class Exercise1
    {
        public static async Task<string> GetPokemon()
        {
            Console.WriteLine("Please enter a pokemon name : ");
            var pokemonName = Console.ReadLine();
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}");
            return await result.Content.ReadAsStringAsync();
        }
    }
}
