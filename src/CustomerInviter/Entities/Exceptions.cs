namespace CustomerInviter.Entities
{
    public static class Exceptions
    {
        public static CustomException OfficeLocationIncorrectFormat(string value) => new CustomException($"{value} is not correct office's location. Please write as latitude,longtitude");

        public static CustomException KeyIsEmpty(string key) => new CustomException($"The key with name {key} is empty.");

        public static CustomException KeyIsInIncorrectFormat(string key) => new CustomException($"The key with name {key} is in incorrect format.");

        public static CustomException MaxDistanceShouldBePositive() => new CustomException("Max distance should be greater than 0.");

        public static CustomException HttpGet(string uri, string content) => new CustomException($"Could not get via {uri}. Here is the detail: {content}");

        public static CustomException FileNotFound(string path) => new CustomException($"{path} is not found.");

        public static CustomException InvalidJsonData(string message) => new CustomException($"The json data is invalid. Here is the detail: {message}");

        public static CustomException LatitudeCannotBeLessThan90 => new CustomException("Latitude cannot be less than -90°.");

        public static CustomException LatitudeCannotBeGreaterThan90 => new CustomException("Latitude cannot be less than 90°.");

        public static CustomException LongitudeCannotBeLessThan180 => new CustomException("Longitude cannot be less than -180°.");

        public static CustomException LongitudeCannotBeGreaterThan180 => new CustomException("Longitude cannot be less than 180°.");
        
        public static CustomException CustomerNameCannotBeEmpty => new CustomException("Customer name cannot be empty.");

        public static CustomException CustomerIdCannotBeNegative => new CustomException("Customer id cannot be negative.");
    }
}