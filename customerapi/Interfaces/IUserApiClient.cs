namespace customerapi
{
    using System.Collections.Generic;
    using WebApiClient;
    using WebApiClient.Attributes;

    public interface IUserApiClient : IHttpApiClient
    {
        [HttpGet("/users")]
        ITask<List<User>> GetUsersAsync();
    }
}