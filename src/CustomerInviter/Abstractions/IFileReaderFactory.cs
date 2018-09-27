namespace CustomerInviter.Abstractions
{
    public interface IFileReaderFactory
    {
        IFileReader GetFileReader(string path);
    }
}
