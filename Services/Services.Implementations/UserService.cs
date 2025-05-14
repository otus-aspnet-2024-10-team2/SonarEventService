using AutoMapper;
using Domain.Entities;
using MassTransit;
using Services.Abstractions;
using Services.Contracts.User;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Implementations
{
    /// <summary>
    /// Сервис работы с пользователями
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IBusControl _busControl;

        public UserService(
            IMapper mapper,
            IUserRepository userRepository,
            IBusControl busControl)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _busControl = busControl;
        }

        /// <summary>
        /// Получить пользователя.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО пользователя. </returns>
        public async Task<UserDto> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(id, cancellationToken);
            return _mapper.Map<User, UserDto>(user);
        }

        /// <summary>
        /// Создать пользователя.
        /// </summary>
        /// <param name="сreatingUserDto"> ДТО пользователя. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<long> CreateAsync(CreatingUserDto сreatingUserDto)
        {
            var user = _mapper.Map<CreatingUserDto, User>(сreatingUserDto);
            var createdUser = await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return createdUser.Id;
        }

        /// <summary>
        /// Изменить пользователя.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingUserDto"> ДТО пользователя. </param>
        public async Task UpdateAsync(long id, UpdatingUserDto updatingUserDto)
        {
            var user = await _userRepository.GetAsync(id, CancellationToken.None);
            if (user == null)
            {
                throw new Exception($"Пользователь с id = {id} не найден");
            }

            user.Username = updatingUserDto.Username;
            user.ShortName = updatingUserDto.ShortName;
            user.FullName = updatingUserDto.FullName;
            user.UpdatedAt = updatingUserDto.UpdatedAt;

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(long id)
        {
            var user = await _userRepository.GetAsync(id, CancellationToken.None);
            var deleted = _userRepository.Delete(id);
            if (!deleted)
            {
                throw new Exception($"Пользователь с идентфикатором {id} не удален!");
            }
            await _userRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Получить постраничный список пользователей.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница пользователей. </returns>
        public async Task<ICollection<UserDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<User> entities = await _userRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<User>, ICollection<UserDto>>(entities);
        }
    }
}