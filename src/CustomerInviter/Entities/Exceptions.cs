namespace CustomerInviter.Entities
{
    public static class Exceptions
    {
        public static CustomException OfficeLocationIncorrectFormat(string value) => new CustomException($"{value} is not correct office's location. Please write as latitude,longtitude");

        public static CustomException KeyIsEmpty(string key) => new CustomException($"The key with name {key} is empty.");

        public static CustomException KeyIsInIncorrectFormat(string key) => new CustomException($"The key with name {key} is in incorrect format.");

        public static CustomException HttpGet(string uri, string content) => new CustomException($"Could not get via {uri}. Here is the detail: {content}");

        public static CustomException FileNotFound(string path) => new CustomException($"{path} is not found.");
    }
}
