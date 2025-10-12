using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Users;
using ZK.Domain.Respositories;
using ZK.Domain.Respositories.Account;

namespace ZK.Persistence.Identity
{
    public class ZKUserStore : IUserStore<User>
    {
        private readonly IRepositoryManager _repositoryManager;
        public ZKUserStore(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            await this._repositoryManager.UserRepository.AddAsync(user, cancellationToken);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await this._repositoryManager.UserRepository.DeleteAsync(user, cancellationToken);
            return IdentityResult.Success;
        }

        public void Dispose()
        {
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if(!int.TryParse(userId, out int id))
                throw new ArgumentException("Invalid user ID", nameof(id));

            return await this._repositoryManager.UserRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.UserId.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await this._repositoryManager.UserRepository.UpdateAsync(user, cancellationToken);
            return IdentityResult.Success;
        }
    }
}
