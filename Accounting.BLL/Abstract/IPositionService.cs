using Accounting.BLL.ViewModels.Position;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.BLL.Abstract
{
    public interface IPositionService
    {
        Task CreateAsync(CreatePositionViewModel positionModel);
        Task<IEnumerable<GetAllPositionsViewModel>> GetAllAsync();
    }
}
