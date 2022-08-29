namespace SdProject.Businesses.Providers
{
    public interface IJsonSerializer
    {
        #region Properties

        string Name { get; }

        #endregion

        #region Methods

        T Deserialize<T>(string json);

        string Serialize<T>(T obj);

        #endregion
    }
}