using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using RecipeApplication.Utility.Settings.Artefacts;
//using RecipeApplication.Utility.Setting.Artefacts;

namespace RecipeApplication.Utility.Settings.Data
{
    internal static partial class SettingDBAsync
    {
        #region Stored proc names, parameters...

        private struct StoredProc
        {
            public const string Setting_Create = "System.Setting_Create";
            public const string Setting_Get = "System.Setting_Get";
            public const string Setting_Search = "System.Setting_Search";
            public const string Setting_Update = "System.Setting_Update";
            public const string Setting_Delete = "System.Setting_Delete";

        }

        private struct Parameter
        {
            public const string Id = "@Id";
            public const string Key = "@Key";
            public const string Value = "@Value";
            public const string Comment = "@Comment";
            public const string ModifiedDate = "@ModifiedDate";
            public const string ModifiedUserId = "@ModifiedUserId";
            public const string IsActive = "@IsActive";
        }

        #endregion Stored proc names, parameters...

        #region Create async

        internal static async Task<int?> CreateAsync(Setting setting)
        {
            int? id;

            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Setting_Create, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue(Parameter.Key, setting.Key);
                        cmd.Parameters.AddWithValue(Parameter.Value, setting.Value);
                        cmd.Parameters.AddWithValue(Parameter.Comment, setting.Comment);
                        cmd.Parameters.AddWithValue(Parameter.ModifiedUserId, setting.ModifiedUserId);
                        cmd.Parameters.AddWithValue(Parameter.IsActive, setting.IsActive);

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

        #region Update async

        internal static async Task UpdateAsync(Setting setting)
        {
            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Setting_Update, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(Parameter.Id, setting.Id);
                        cmd.Parameters.AddWithValue(Parameter.Key, setting.Key);
                        cmd.Parameters.AddWithValue(Parameter.Value, setting.Value);
                        cmd.Parameters.AddWithValue(Parameter.Comment, setting.Comment);
                        cmd.Parameters.AddWithValue(Parameter.ModifiedUserId, setting.ModifiedUserId);
                        cmd.Parameters.AddWithValue(Parameter.IsActive, setting.IsActive);

                        await connection.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Update async

        #region Get async

        internal static async Task<Setting> GetAsync(int id)
        {
            Setting retVal = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Setting_Get, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Value = id;
                        await connection.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader != null && await reader.ReadAsync())
                            {
                                retVal = new Setting(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        #endregion Get async

        #region Search async

        internal static async Task<Artefacts.Settings> SearchAsync(string key = null,
                                string value = null,
                                string comment = null,
                                DateTime? modifiedDate = null,
                                int? modifiedUserId = null,
                                bool? isActive = null)
        {
            var retVal = new Artefacts.Settings();

            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Setting_Search, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(Parameter.Key, key);
                        cmd.Parameters.AddWithValue(Parameter.Value, value);
                        cmd.Parameters.AddWithValue(Parameter.Comment, comment);
                        cmd.Parameters.AddWithValue(Parameter.ModifiedDate, modifiedDate);
                        cmd.Parameters.AddWithValue(Parameter.ModifiedUserId, modifiedUserId);
                        cmd.Parameters.AddWithValue(Parameter.IsActive, isActive);

                        await connection.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                retVal.Add(new Setting(reader));
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        #endregion Search async

        #region Search 

        internal static Artefacts.Settings Search(string key = null,
                                                    string value = null,
                                                    string comment = null,
                                                    DateTime? modifiedDate = null,
                                                    int? modifiedUserId = null,
                                                    bool? isActive = null)
        {
            var retVal = new Artefacts.Settings();

            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Setting_Search, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(Parameter.Key, key);
                        cmd.Parameters.AddWithValue(Parameter.Value, value);
                        cmd.Parameters.AddWithValue(Parameter.Comment, comment);
                        cmd.Parameters.AddWithValue(Parameter.ModifiedDate, modifiedDate);
                        cmd.Parameters.AddWithValue(Parameter.ModifiedUserId, modifiedUserId);
                        cmd.Parameters.AddWithValue(Parameter.IsActive, isActive);

                        connection.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                retVal.Add(new Setting(reader));
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        #endregion Search async

        #region Delete async

        internal static async Task DeleteAsync(int id, int modifiedUserId)
        {

            try
            {
                using (var connection = new SqlConnection(GlobalSettings.DbConnectionString))
                {
                    using (var cmd = new SqlCommand(StoredProc.Setting_Delete, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(Parameter.Id, SqlDbType.Int).Value = id;
                        cmd.Parameters.Add(Parameter.ModifiedUserId, SqlDbType.Int).Value = modifiedUserId;

                        await connection.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Delete async

    }

    /// <summary>
    /// Custom SQL
    /// </summary>
    internal static partial class SettingDBAsync
    {
        #region Custom stored proc names, parameters...

        private struct StoredProcCustom
        {
        }

        private struct ParameterCustom
        {
        }

        #endregion Custom stored proc names, parameters...
    }
}