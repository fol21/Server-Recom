namespace ServerRecom.Application.Config
{
    public interface ICustomVisionConfiguration
    {
        string TrainingKey {get; set;}
        string PredictionKey {get; set;}
        string Endpoint {get; set;}
    }
}