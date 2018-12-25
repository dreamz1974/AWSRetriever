using Amazon;
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticsearchDescribeReservedElasticsearchInstancesOperation : Operation
    {
        public override string Name => "DescribeReservedElasticsearchInstances";

        public override string Description => "Returns information about reserved Elasticsearch instances for this account.";
 
        public override string RequestURI => "/2015-01-01/es/reservedInstances";

        public override string Method => "GET";

        public override string ServiceName => "Elasticsearch";

        public override string ServiceID => "Elasticsearch Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticsearchClient client = new AmazonElasticsearchClient(creds, region);
            DescribeReservedElasticsearchInstancesResponse resp = new DescribeReservedElasticsearchInstancesResponse();
            do
            {
                DescribeReservedElasticsearchInstancesRequest req = new DescribeReservedElasticsearchInstancesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeReservedElasticsearchInstances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReservedElasticsearchInstances)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}