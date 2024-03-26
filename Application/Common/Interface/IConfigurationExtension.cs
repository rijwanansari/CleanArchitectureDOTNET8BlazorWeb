namespace Application.Common.Interface
{
    public interface IConfigurationExtension
    {
        string GetConfiguration(string configKey);
        string GetSectionKeyValue(string key);

    }
}
