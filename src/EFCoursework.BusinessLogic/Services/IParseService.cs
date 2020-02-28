using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCoursework.BusinessLogic.Services
{
    public interface IParseService<T>
    {
        Task<T> ParseAsync();
    }
}
