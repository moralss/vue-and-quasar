﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Data.Processes;
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
            List<Recipe> recipes = _recipeRepository.ShowRecipes();
            return recipes;
        }

        [HttpPost]
        [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
        public async Task<ActionResult<Recipe>> AddRecipes([FromBody] Recipe recipe)
        {
            try
            {

                var retVal = await ContentProcesses.CreateRecipeAsync(recipe);
                System.Diagnostics.Debug.WriteLine(retVal);
                Recipe savedRecipe = _recipeRepository.AddRecipe(recipe);
                return savedRecipe;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return null;
        }



        [HttpPut]
        [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
        public void Put([FromBody] Recipe recipe)
        {
            _recipeRepository.UpdateRecipe(recipe);
        }

    
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
