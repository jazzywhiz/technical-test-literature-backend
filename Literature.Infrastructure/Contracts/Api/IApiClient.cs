namespace Literature.Infrastructure.Contracts.Api
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string endpoint);

        Task<T> PostAsync<T>(string endpoint, object data);

        Task PutAsync(string endpoint, object data);

        Task DeleteAsync(string endpoint);
    }
}
