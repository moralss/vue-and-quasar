using RecipeApplication.Data.Artefact;
using RecipeApplication.Utility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace RecipeApplication.Data.Data.Content
{
    internal static partial class RecipeDBAsync
    {
        #region Stored proc names, parameters...

        private struct StoredProc
        {
            public const string Recipe_Create = "content.Recipe_Create";
            //public const string Commentary_Get = "Content.Commentary_Get";
            //public const string Commentary_Search = "Content.Commentary_Search";
            //public const string Commentary_Update = "Content.Commentary_Update";
            //public const string Commentary_Delete = "Content.Commentary_Delete";
        }

        private struct Parameter
        {
            public const string Id = "@Id";
            public const string RecipeName = "@RecipeName";
            public const string Ingredients = "@Ingredients";
          
        }

        #endregion Stored proc names, parameters...

        #region Create async

        internal static async Task<int> CreateAsync(RecipeNew recipe)
        {
            int id;
            System.Diagnostics.Debug.WriteLine("throwed error ////////////////////////////////////////////////////////////////////", recipe.RecipeName + "watch for error : ");

            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Recipe_Create, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue(Parameter.RecipeName, recipe.RecipeName);
                        cmd.Parameters.AddWithValue(Parameter.Ingredients, recipe.Ingredients);             

                        await connection.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        id = Int32.Parse(cmd.Parameters[Parameter.Id].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("throwed error ////////////////////////////////////////////////////////////////////" , recipe.RecipeName + "watch for error : ");
                throw;
            }

            return id;
        }

        #endregion Create async

    }
}
