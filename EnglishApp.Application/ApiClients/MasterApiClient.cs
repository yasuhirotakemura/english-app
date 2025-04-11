using EnglishApp.Application.Dtos.Master;
using EnglishApp.Application.Interfaces;

namespace EnglishApp.Application.ApiClients;

public sealed class MasterApiClient(ApiRequestHandler apiRequestHandler) : IMasterApiClient
{
    private readonly ApiRequestHandler _apiRequestHandler = apiRequestHandler;

    public async Task<ApiResult<MasterDataResponse>> GetAsync()
    {
        return await this._apiRequestHandler.GetAsync<MasterDataResponse>("api/master");
    }
}

