using RecipeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApplication.Repositorys
{
  public  interface RepositoryInterface
    {

        List<Recipe> ShowRecipes();
        Recipe addRecipe(Recipe recipe);

        void updateRecipe(Recipe recipe);
    }
}
