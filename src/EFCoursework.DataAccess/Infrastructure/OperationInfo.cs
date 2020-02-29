using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.DataAccess.Infrastructure
{
    public class OperationInfo
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public bool IsError => Exception != null;
    }
}
