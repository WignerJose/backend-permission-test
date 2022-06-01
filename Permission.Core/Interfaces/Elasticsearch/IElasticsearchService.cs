using Nest;
using Permissions.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Core.Interfaces.Elasticsearch
{
    public interface IElasticsearchService<T> where T : class
    {
        Task<List<T>> GetPermissionsAsync();
        Task<IndexResponse> CreatePermissionAsync(T model);
        Task<UpdateResponse<T>> UpdatePermissionAsync(T model);
    }
}
