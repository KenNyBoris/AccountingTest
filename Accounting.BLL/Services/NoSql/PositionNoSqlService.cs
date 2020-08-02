using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Accounting.BLL.Abstract;
using Accounting.BLL.ViewModels.Position;
using Accounting.Domain.Abstract.NoSql.Entities;
using Accounting.Domain.Abstract.NoSql.Interfaces;
using Accounting.Domain.Abstract.Sql.Interfaces;
using AutoMapper;

namespace Accounting.BLL.Services.NoSql
{
    public class PositionNoSqlService : IPositionService
    {
        private readonly IPositionNoSqlRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionNoSqlService(IPositionNoSqlRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreatePositionViewModel positionModel)
        {
            var position = _mapper.Map<Position>(positionModel);
            await _positionRepository.CreateAsync(position);
        }

        public async Task<IEnumerable<GetAllPositionsViewModel>> GetAllAsync()
        {
            var positions = await _positionRepository.GetAllAsync();
            var resultPositions = _mapper.Map<IEnumerable<GetAllPositionsViewModel>>(positions);
            return resultPositions;
        }
    }
}
