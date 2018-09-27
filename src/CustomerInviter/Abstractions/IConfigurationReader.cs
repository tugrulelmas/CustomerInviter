namespace CustomerInviter.Abstractions
{
    public interface IConfigurationReader
    {
        string Read(string key);

        T Read<T>(string key);
    }
}
