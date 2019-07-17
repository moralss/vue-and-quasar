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
            public const string Commentary_Create = "Content.Commentary_Create";
            public const string Commentary_Get = "Content.Commentary_Get";
            public const string Commentary_Search = "Content.Commentary_Search";
            public const string Commentary_Update = "Content.Commentary_Update";
            public const string Commentary_Delete = "Content.Commentary_Delete";
        }

        private struct Parameter
        {
            public const string Id = "@Id";
            public const string Description = "@Description";
            public const string ModifiedDate = "@ModifiedDate";
            public const string ModifiedUserId = "@ModifiedUserId";
            public const string IsActive = "@IsActive";
        }

        #endregion Stored proc names, parameters...

        #region Create async

        internal static async Task<int> CreateAsync(RecipeNew commentary)
        {
            int id;

            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Commentary_Create, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue(Parameter.Description, commentary.Description);
                        cmd.Parameters.AddWithValue(Parameter.ModifiedUserId, commentary.ModifiedUserId);
                        cmd.Parameters.AddWithValue(Parameter.IsActive, commentary.IsActive);

                        await connection.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();

                        id = Int32.Parse(cmd.Parameters[Parameter.Id].Value.ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }

        #endregion Create async

    }
}
