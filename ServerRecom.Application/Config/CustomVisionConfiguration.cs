namespace ServerRecom.Application.Config
{
    public class CustomVisionConfiguration : ICustomVisionConfiguration
    {
        public string ProjectId {get; set;}
        public string TrainingKey {get; set;}
        public string PredictionKey {get; set;}
        public string Endpoint {get; set;}
        public string PublishedAs {get; set;}
    }
}