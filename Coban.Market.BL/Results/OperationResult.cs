using System;

namespace Coban.Market.BL.Results
{
    public class OperationResult
    {
        public OperationResult()
        {
            Result = false;
        }

        public bool Result { get; set; }
        public string Message { get; set; }
        public int ErrorId { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public Byte ErrorType { get; set; }
        public object Response { get; set; }
    }
    public class OperationResult<T> : OperationResult
    {
        public new T Response
        {
            get
            {
                if (base.Response == null)
                    return default(T);

                return (T)base.Response;
            }
            set { base.Response = value; }
        }
    }
}
