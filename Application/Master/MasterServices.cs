using Application.Common.Error;
using Application.Common.Interface;
using Application.Common.Model;
using AutoMapper;
using Domain.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Master
{
    internal class MasterServices (IUnitOfWork unitOfWork, ILogger<MasterServices> logger, IMapper mapper, IErrorMessageLog errorMessageLog) : IMasterServices
    {
        #region Properties
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<MasterServices> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IErrorMessageLog _errorMessageLog = errorMessageLog;
        #endregion
        
        #region AppSetting

        #region Command
        public async Task<ResponseModel<AppSetting>> UpsertAsync(AppSetting appSetting)
        {
            try
            {
                if (appSetting.Id > 0)
                    _unitOfWork.Repository<AppSetting>().Update(appSetting);
                else
                    _unitOfWork.Repository<AppSetting>().AddAsync(appSetting);

                await _unitOfWork.SaveAsync();
                return ResponseModel<AppSetting>.SuccessResponse("AppSetting Inserted", appSetting);
            }
            catch (Exception ex)
            {
                Log("UpsertAsync", ex.Message);
                _logger.LogError(ex, ex.Message);
                return ResponseModel<AppSetting>.FailureResponse("Operation Failed");
            }

        }
        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var IsDeteted = await _unitOfWork.Repository<UserAccess>().Delete(Id);
                await _unitOfWork.SaveAsync();
                return IsDeteted;
            }
            catch (Exception)
            {
                //handle exception
                return false;
            }
        }
        #endregion
        #region Queries
        public async Task<List<AppSetting>> GetAppSettingsAsync()
        {
            var appsettigs = await _unitOfWork.Repository<AppSetting>()
                .TableNoTracking
                .OrderBy(t => t.ReferenceKey)
                .ToListAsync();
            return appsettigs;
        }
        public async Task<AppSetting> GetAppSettingByIdAsync(int Id)
        {
            try
            {
                var appSetting = await _unitOfWork.Repository<AppSetting>().Get(Id);
                return appSetting;
            }
            catch (Exception)
            {
                //handle exception
                throw;
            }
        }

        #endregion

        #endregion

        #region Error
        private void Log(string method, string msg)
        {
            errorMessageLog.LogError("Application", "MasterServices", method, msg);
        }
        #endregion
    }
}
