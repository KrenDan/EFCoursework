using EFCoursework.DataAccess.Models;
using EFCoursework.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCoursework.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Game> Games { get; }

        Task SaveChangesAsync();
    }
}
