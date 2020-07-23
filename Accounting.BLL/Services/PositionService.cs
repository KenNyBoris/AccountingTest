using Accounting.BLL.Abstract;
using Accounting.BLL.ViewModels.Position;
using Accounting.Domain.Abstract;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Accounting.Domain.Entities;

namespace Accounting.BLL.Services
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
        public async Task<string> CreateAsync(CreatePositionViewModel positionModel)
        {
            var position = _mapper.Map<Position>(positionModel);
            var result = await _positionRepository.InsertAsync(position);
            return result;
        }

        public async Task<IEnumerable<GetAllPositionsViewModel>> GetAllAsync()
        {
            var positions = await _positionRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetAllPositionsViewModel>>(positions);
            return result;
        }
    }
}
