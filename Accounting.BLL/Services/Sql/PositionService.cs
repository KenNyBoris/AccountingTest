using Accounting.BLL.Abstract;
using Accounting.BLL.ViewModels.Position;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounting.Domain.Abstract.Sql.Entities;
using Accounting.Domain.Abstract.Sql.Interfaces;

namespace Accounting.BLL.Services.Sql
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreatePositionViewModel positionModel)
        {
            var position = _mapper.Map<Position>(positionModel);
            position.Id = Guid.NewGuid();
            await _positionRepository.CreateAsync(position);
        }

        public async Task<IEnumerable<GetAllPositionsViewModel>> GetAllAsync()
        {
            var positions = await _positionRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetAllPositionsViewModel>>(positions);
            return result;
        }
    }
}
