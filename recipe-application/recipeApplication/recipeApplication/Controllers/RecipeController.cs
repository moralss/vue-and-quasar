using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Models;
using RecipeApplication.Repositorys;
namespace RecipeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class RecipeController : ControllerBase
    {
      
        private RepositoryInterface _recipeRepository;

        public RecipeController(RepositoryInterface recipeRepository)
        {
           _recipeRepository = recipeRepository;
        }

        [HttpGet]
        [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
        public ActionResult<List<Recipe>> Get()
        {
            List<Recipe> result = _recipeRepository.ShowRecipes();
            Console.WriteLine(result);
            return result;
        }

  
        // POST api/values
        [HttpPost]
        [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
        public ActionResult<Recipe> addRecipes([FromBody] Recipe recipe)
        {
            Recipe savedRecipe = _recipeRepository.addRecipe(recipe);
            return savedRecipe;
        }

        // PUT api/values/5
        [HttpPut]
        [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
        public void Put([FromBody] Recipe recipe)
        {
            _recipeRepository.updateRecipe(recipe);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
