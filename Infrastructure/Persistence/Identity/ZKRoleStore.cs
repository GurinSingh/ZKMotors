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
    public class ZKRoleStore : IRoleStore<Role>
    {
        private readonly IRepositoryManager _repositoryManager;
        public ZKRoleStore(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            await this._repositoryManager.RoleRepository.AddAsync(role, cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            await this._repositoryManager.RoleRepository.DeleteAsync(role, cancellationToken);
            return IdentityResult.Success;
        }

        public void Dispose()
        {
        }

        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            if (!int.TryParse(roleId, out int id))
                throw new ArgumentException("Invalid role ID", nameof(id));

            return await this._repositoryManager.RoleRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            if(role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.RoleId.ToString());
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            if(role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            if(role == null)
                throw new ArgumentNullException(nameof(role));

            await this._repositoryManager.RoleRepository.UpdateAsync(role, cancellationToken);
            return IdentityResult.Success;
        }
    }
}
