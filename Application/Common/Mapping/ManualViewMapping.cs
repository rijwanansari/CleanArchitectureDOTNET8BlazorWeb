using Application.Master.Dto;
using Domain.Master;

namespace Application.Common.Mapping
{
    internal static class ManualViewMapping
    {
        /// <summary>
        /// Convert AppSetting to AppSettingVm
        /// </summary>
        /// <param name="appSettingVm"></param>
        /// <returns></returns>
        public static AppSetting ConvertToModel(this AppSettingVm appSettingVm)
        {
            if (appSettingVm == null)
                return null;

            var appSetting = new AppSetting
            {
                Id = appSettingVm.Id,
                ReferenceKey = appSettingVm.ReferenceKey,
                Value = appSettingVm.Value,
                Description = appSettingVm.Description,
                Type = appSettingVm.Type,
            };
            return appSetting;

        }
        
    }
}
