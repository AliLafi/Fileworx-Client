using FileworxObjects.DTOs;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileworxObjects
{
    public class NewsQuery
    {

        public List<NewsDTO> Run(ElasticClient elasticClient, DateTime lower, DateTime upper, string cat = "", string query = "*")
        {

            var queries = new List<QueryContainer>();

            QueryStringQuery keywordQuery = new QueryStringQuery
            {
                Fields = Infer.Fields<NewsDTO>(p => p.Body).And("description").And("name"),
                Query = "*"+query+"*",
                AnalyzeWildcard = true,
                DefaultOperator = Operator.Or
            };

            queries.Add(keywordQuery);

            MatchQuery categoryQuery = new MatchQuery
            {
                Field = Infer.Field<NewsDTO>(p => p.Category),
                Query = cat,
                Operator= Operator.Or
            };

            queries.Add(categoryQuery);

            QueryStringQuery classidQuery = new QueryStringQuery
            {
                Fields = Infer.Field<NewsDTO>(p => p.ClassID),
                Query = "1"

            };

            queries.Add(classidQuery);

            DateRangeQuery dateQuery = new DateRangeQuery
            {
                Field = Infer.Field<NewsDTO>(p => p.Created),
                GreaterThan = lower,
                LessThan= upper

            };

            queries.Add(dateQuery);

            var searchRequest = new SearchRequest<NewsDTO>
            {
                From = 0,
                Size= 100,
                Query = new BoolQuery
                {
                    Must = queries
                   
                }
            };

            var response = elasticClient.Search<NewsDTO>(searchRequest);

            return response.Documents.ToList();

        }
    }
}
