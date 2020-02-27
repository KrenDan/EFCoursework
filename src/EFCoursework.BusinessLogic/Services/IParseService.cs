using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoursework.BusinessLogic.Services
{
    public interface IParseService
    {
        T Parse<T>(string url);
    }
}
