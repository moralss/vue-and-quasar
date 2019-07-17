using RecipeApplication.Data.Artefact;
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

        public static async Task<int> CreateRecipeAsync(RecipeNew recipe)
        {
           // var retVal = new CallReturn<int>();

            try
            {
                int value = await RecipeDBAsync.CreateAsync(new RecipeNew
                {
                    Description = recipe.Description,
                    ModifiedUserId = recipe.ModifiedUserId,
                    IsActive = recipe.IsActive,
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //retVal.SetError(ErrorType.SystemError, ex);
            }

            return 3;
        }

        #endregion

    }
}
