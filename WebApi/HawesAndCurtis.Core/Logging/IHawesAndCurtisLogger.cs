
 namespace HawesAndCurtis.Core.Logging
{
    public interface IHawesAndCurtisLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(string message, params object[] args);
    }
}
