namespace Utilities
{
   // [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ApiResponseModel
    {
        public bool Succeeded { get; set; } = true;
        public int HttpStatusCode { get; set; } = 200;
        public string Message { get; set; }
        public object Data { get; set; }
        public long TotalData { get; set; }
    }
}
