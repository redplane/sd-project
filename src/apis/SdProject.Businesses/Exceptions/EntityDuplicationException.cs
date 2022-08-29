
using SdProject.Businesses.Constant;

namespace SdProject.Businesses.Exception
{
    public class EntityDuplicationException : System.Exception
    {
        public string DUPLICATION_STATUS_CODE { get;} = ErrorCodeConstants.DUPLICATION_STATUS_CODE.ToString("D");
        public EntityDuplicationException(string message) : base(message)
        {
        }
    }
}
