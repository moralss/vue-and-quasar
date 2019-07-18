using RecipeApplication.Data.Artefact;
using RecipeApplication.Data.Artefact.Common;
using RecipeApplication.Data.Data.Content;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.Data.Processes
{
    public static class ContentProcesses
    {
        #region Create

        public static async Task<CallReturn<int>> CreateRecipeAsync(RecipeNew recipe)
        {
            var retVal = new CallReturn<int>();

            try
            {
                int value = await RecipeDBAsync.CreateAsync(new RecipeNew
                {
                    RecipeName = recipe.RecipeName,
                    Ingredients = recipe.Ingredients
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                retVal.SetError(ErrorType.SystemError, ex);
            }

            return retVal;
        }

        #endregion

    }
}
