using SdProject.Businesses.Constant;

namespace SdProject.Businesses.Exception
{
    public class EntityNotFoundException : System.Exception
    {
        public string NOT_FOUND_STATUS_CODE { get; } = ErrorCodeConstants.NOT_FOUND_STATUS_CODE.ToString("D");
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
