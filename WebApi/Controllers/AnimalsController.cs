using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.Animal;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models.Animal;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/animals")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _service;
        private readonly ILogger<AnimalsController> _logger;
        private readonly IMapper _mapper;

        public AnimalsController(IAnimalService service, ILogger<AnimalsController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        //[HttpGet("{animalId}")]
        //public async Task<IActionResult> GetAsync(long animalId, CancellationToken cancellationToken)
        //{
        //    var animalDto = await _service.GetByIdAsync(animalId, cancellationToken);
        //    return Ok(_mapper.Map<AnimalDto, AnimalModel>(animalDto));
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddAsync(CreatingAnimalModel creatingSonarTaskDto)
        //{
        //    return Ok(await _service.CreateAsync(_mapper.Map<CreatingAnimalModel, CreatingAnimalDto>(creatingSonarTaskDto)));
        //}

        //[HttpPut("{animalId}")]
        //public async Task<IActionResult> EditAsync(int animalId, UpdatingAnimalModel creatingLessonDto)
        //{
        //    await _service.UpdateAsync(animalId, _mapper.Map<UpdatingAnimalModel, UpdatingAnimalDto>(creatingLessonDto));
        //    return Ok();
        //}

        //[HttpDelete("{animalId}")]
        //public async Task<IActionResult> DeleteAsync(int animalId)
        //{
        //    await _service.DeleteAsync(animalId);
        //    return Ok();
        //}

        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<AnimalModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}