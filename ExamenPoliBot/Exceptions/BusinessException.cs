using System;

namespace Exceptions
{
    public class BusinessException : Exception
    {

        public int ExceptionID;
        public ApplicationMessage AppMessage { get; set; }


        public BusinessException()
        {

        }

        public BusinessException(int exceptionId)
        {

            ExceptionID = exceptionId;
        }


        public BusinessException(int exceptionId, Exception innerException)
        {

            ExceptionID = exceptionId;

        }
    }
}
