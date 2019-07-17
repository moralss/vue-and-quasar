using System.Runtime.Serialization;

namespace RecipeApplication.Data.Artefact
{
    [DataContract]
    public class RecipeNew : Common.Artefact
    {
        #region Constructors

        public RecipeNew() { }

        #endregion Constructors

        #region Public properties

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Description
        {
            get;
            set;
        }

        #endregion Public properties
    }
}
