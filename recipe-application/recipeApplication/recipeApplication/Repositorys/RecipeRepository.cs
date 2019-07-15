using RecipeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApplication.Repositorys
{
    public class RecipeRepository : RepositoryInterface
    {
        private List<Recipe> recipes = new List<Recipe>();
        public List<Recipe> ShowRecipes()
        {
            return this.recipes;
        }

        private long generateId()
        {
            if(recipes.Count > 0)
            {

                Recipe lastRecipe = recipes[recipes.Count -1];
                long lastValue = lastRecipe.Id + 1;
                return lastValue;
            }

            return 0;
        }

        public Recipe addRecipe(Recipe recipe)
        {
            long generatedId = generateId();
            recipe.Id = generatedId;
            recipes.Add(recipe);
            return recipe;
        }
            
        public void updateRecipe(Recipe recipe)
        {
            foreach (Recipe currentRecipe in recipes)
            {
                if(currentRecipe.Id == recipe.Id)
                {
                    currentRecipe.Ingredients = recipe.Ingredients;
                    currentRecipe.RecipeName = recipe.RecipeName;
                }
            }
        }
        
    }
}
