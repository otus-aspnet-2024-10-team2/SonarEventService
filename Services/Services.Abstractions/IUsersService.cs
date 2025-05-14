using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Contracts.User;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с пользователями
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получить пользователя. 
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО пользователя. </returns>
        Task<UserDto> GetByIdAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать пользователя.
        /// </summary>
        /// <param name="creatingUserDto"> ДТО пользователя. </param>
        /// <returns> Идентификатор. </returns>
        Task<long> CreateAsync(CreatingUserDto creatingUserDto);

        /// <summary>
        /// Изменить пользователя.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingUserDto"> ДТО пользователя. </param>
        Task UpdateAsync(long id, UpdatingUserDto updatingUserDto);

        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(long id);

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница пользователей. </returns>
        Task<ICollection<UserDto>> GetPagedAsync(int page, int pageSize);
    }
}