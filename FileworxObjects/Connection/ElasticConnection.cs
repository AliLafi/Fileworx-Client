using Elasticsearch.Net;
using Nest;
using System;

namespace FileworxObjects.Connection
{
    public class ElasticConnection
    {
        public static ElasticClient GetESClient(string index="files")
        {
            ConnectionSettings connectionSettings;
            ElasticClient elasticClient;
            StaticConnectionPool connectionPool;

            var nodes = new Uri[] {
                new Uri("http://localhost:9200/")
            };

            connectionPool = new StaticConnectionPool(nodes);
            connectionSettings = new ConnectionSettings(connectionPool);
            elasticClient = new ElasticClient(connectionSettings);
            connectionSettings.DefaultIndex(index);

            return elasticClient;
        }
    }
}
