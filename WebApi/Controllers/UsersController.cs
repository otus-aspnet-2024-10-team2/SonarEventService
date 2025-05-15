using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.User;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models.User;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, ILogger<UsersController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        //[HttpGet("{userId}")]
        //public async Task<IActionResult> GetAsync(long userId, CancellationToken cancellationToken)
        //{
        //    var userDto = await _service.GetByIdAsync(userId, cancellationToken);
        //    return Ok(_mapper.Map<UserDto, UserModel>(userDto));
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddAsync(CreatingUserModel creatingSonarTaskDto)
        //{
        //    return Ok(await _service.CreateAsync(_mapper.Map<CreatingUserModel, CreatingUserDto>(creatingSonarTaskDto)));
        //}

        //[HttpPut("{userId}")]
        //public async Task<IActionResult> EditAsync(int userId, UpdatingUserModel creatingLessonDto)
        //{
        //    await _service.UpdateAsync(userId, _mapper.Map<UpdatingUserModel, UpdatingUserDto>(creatingLessonDto));
        //    return Ok();
        //}

        //[HttpDelete("{userId}")]
        //public async Task<IActionResult> DeleteAsync(int userId)
        //{
        //    await _service.DeleteAsync(userId);
        //    return Ok();
        //}

        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<UserModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}