using Accounting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Abstract
{
    public interface IPositionRepository : IBaseRepository<Position>
    {
        Task<string> InsertAsync(Position position);
        Task<Position> GetByIdAsync(string positionId);
    }
}
