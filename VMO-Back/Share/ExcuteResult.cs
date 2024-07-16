using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    public record ExcuteResult<T>(T Result, string Code = null, string ErrorMessage = "");
    public record SuccessResult<T>(T Result = default(T)) : ExcuteResult<T>(Result, ResultCode.SuccessResult, null);
    public record NotFoundRecordResult<T>(string ErrorMessage = "Không tìm thấy dữ liệu") : ExcuteResult<T>(default(T), ResultCode.NotfoundResult, ErrorMessage);
    public record ExistRecordResult<T>(string ErrorMessage = "Dữ liệu đã tồn tại") : ExcuteResult<T>(default(T), ResultCode.ExistRecordResult, ErrorMessage);
    public record InvalidDataExcuteResult<T>(string ErrorMessage = "Dữ liệu không hợp lệ", dynamic ErrorMessageDetail = null) : ExcuteResult<T>(default(T), ResultCode.InvalidDataResult, ErrorMessage);
    public record InactiveDataResult<T>(string ErrorMessage = "Dữ liệu chưa được kích hoạt", dynamic ErrorMessageDetail = null) : ExcuteResult<T>(default(T), ResultCode.InactiveDataResult, ErrorMessage);
    public record PermissionMissingDataResult<T>(string ErrorMessage = "Không có quyền truy cập dữ liệu") : ExcuteResult<T>(default(T), ResultCode.PermissionMissingDataResult, ErrorMessage);
    public record WarningResult<T>(string ErrorMessage = "Cảnh báo dữ liệu cần kiểm tra") : ExcuteResult<T>(default(T), ResultCode.WarningResult, ErrorMessage);
    public static class ResultCode
    {
        public static string SuccessResult = "00";
        public static string InvalidDataResult = "01";
        public static string NotfoundResult = "02";
        public static string ExistRecordResult = "03";
        public static string InactiveDataResult = "04";
        public static string PermissionMissingDataResult = "05";
        public static string WarningResult = "06";
        public static string ContinueProcessResult = "07";
        public static string ExceptionResult = "99";
    }
}
