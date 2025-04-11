using EnglishApp.Application.Dtos.Master;

namespace EnglishApp.Application.Interfaces;

public interface IMasterApiClient
{
    Task<ApiResult<MasterDataResponse>> GetAsync();
}
