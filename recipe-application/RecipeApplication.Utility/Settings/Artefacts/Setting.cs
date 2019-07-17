using System;
using System.Data;
using System.Runtime.Serialization;

namespace RecipeApplication.Utility.Settings.Artefacts
{
    [DataContract]
    public class Setting
    {
        #region Index

        public enum Index
        {
        }

        #endregion Index

        #region Fields

        private enum Fields
        {
            Id,
            Key,
            Value,
            Comment,
            ModifiedDate,
            ModifiedUserId,
            IsActive,
        }

        #endregion Fields

        #region Constructors

        public Setting() { }

        public Setting(IDataReader reader)
        {
            if (reader != null)
            {
                this.Id = reader.GetInt32((int)Fields.Id);
                this.Key = reader.GetString((int)Fields.Key);
                this.Value = reader.GetString((int)Fields.Value);
                this.Comment = reader.IsDBNull((int)Fields.Comment) ? null : reader.GetString((int)Fields.Comment);
                this.ModifiedDate = reader.GetDateTime((int)Fields.ModifiedDate);
                this.ModifiedUserId = reader.GetInt32((int)Fields.ModifiedUserId);
                this.IsActive = reader.GetBoolean((int)Fields.IsActive);
            }
        }

        #endregion Constructors

        #region Public properties

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Key
        {
            get;
            set;
        }

        [DataMember]
        public string Value
        {
            get;
            set;
        }

        [DataMember]
        public string Comment
        {
            get;
            set;
        }

        [DataMember]
        public DateTime ModifiedDate
        {
            get;
            set;
        }

        [DataMember]
        public int ModifiedUserId
        {
            get;
            set;
        }

        [DataMember]
        public bool IsActive
        {
            get;
            set;
        }

        #endregion Public properties
    }
}