namespace ServerRecom.Application.Config
{
    public class CustomVisionConfiguration : ICustomVisionConfiguration
    {
        public string TrainingKey {get; set;}
        public string PredictionKey {get; set;}
        public string Endpoint {get; set;}
    }
}