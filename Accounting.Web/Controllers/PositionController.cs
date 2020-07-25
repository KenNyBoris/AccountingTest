using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.BLL.Abstract;
using Accounting.BLL.ViewModels.Position;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        [ActionName("get-all")]
        public async Task<IEnumerable<GetAllPositionsViewModel>> GetAll()
        {
            var result = await _positionService.GetAllAsync();
            return result;
        }

        [HttpPost]
        [ActionName("create")]
        public async Task<IActionResult> CreateAsync(CreatePositionViewModel model)
        {
            await _positionService.CreateAsync(model);
            return Ok();
        }
    }
}
