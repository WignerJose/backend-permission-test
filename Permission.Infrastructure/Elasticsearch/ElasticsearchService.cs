using Elasticsearch.Net;
using Microsoft.Extensions.Options;
using Nest;
using Permissions.Core.Domain;
using Permissions.Core.Interfaces.Elasticsearch;
using Permissions.Infrastructure.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Infrastructure.Elasticsearch
{
    public class ElasticsearchService : IElasticsearchService<Permission>
    {
        private readonly ElasticClient _elasticClient;
        private readonly string _indexName;

        public ElasticsearchService(IOptions<ElasticsearchConfig> elasticsearchConfig)
        {
            var singleNodeConnection = new SingleNodeConnectionPool(new Uri(elasticsearchConfig.Value.Url));
            var settings = new ConnectionSettings(singleNodeConnection).DefaultIndex(elasticsearchConfig.Value.IndexName);
            _elasticClient = new ElasticClient(settings);
            _indexName = elasticsearchConfig.Value.IndexName;
        }

        public async Task<IndexResponse> CreatePermissionAsync(Permission permission)
        {
            return await _elasticClient.IndexAsync(permission, decriptor => decriptor.Index(_indexName));
        }

        public async Task<List<Permission>> GetPermissionsAsync()
        {
            var search = new SearchDescriptor<Permission>(_indexName);
            var response = await _elasticClient.SearchAsync<Permission>(search);

            if(!response.IsValid)
                return new List<Permission>();

            return response.Hits.Select(hit => hit.Source).ToList();
        }

        public async Task<UpdateResponse<Permission>> UpdatePermissionAsync(Permission permission)
        {
            return await _elasticClient.UpdateAsync(DocumentPath<Permission>.Id(permission.Id).Index(_indexName), p => p.Doc(permission));
        }
    }
}
