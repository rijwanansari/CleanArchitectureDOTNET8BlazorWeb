using Application.Common.Model;
using Domain.Master;

namespace Application.Master
{
    public interface IMasterServices
    {
        Task<List<AppSetting>> GetAppSettingsAsync();
        Task<AppSetting> GetAppSettingByIdAsync(int Id);
        Task<ResponseModel<AppSetting>> UpsertAsync(AppSetting appSetting);
        Task<bool> DeleteAsync(int Id);

    }
}
