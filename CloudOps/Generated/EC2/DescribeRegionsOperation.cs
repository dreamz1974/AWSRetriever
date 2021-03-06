using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeRegionsOperation : Operation
    {
        public override string Name => "DescribeRegions";

        public override string Description => "Describes one or more regions that are currently available to you. For a list of the regions supported by Amazon EC2, see Regions and Endpoints.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Config config = new AmazonEC2Config();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonEC2Client client = new AmazonEC2Client(creds, config);
            
            DescribeRegionsResponse resp = new DescribeRegionsResponse();
            DescribeRegionsRequest req = new DescribeRegionsRequest
            {                    
                                    
            };
            resp = client.DescribeRegions(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Regions)
            {
                AddObject(obj);
            }
            
        }
    }
}