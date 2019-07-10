namespace ServerRecom.Application.Config
{
    public interface ICustomVisionConfiguration
    {
        string ProjectId {get; set;}
        string TrainingKey {get; set;}
        string PredictionKey {get; set;}
        string Endpoint {get; set;}
        string PublishedAs {get; set;}
    }
}