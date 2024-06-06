namespace Traversal.UI.CQRS.Results.DestinationResults
{
    public class GetDestinationsQueryResult
    {
        public int id { get; set; }
        public string city { get; set; }
        public string daynight { get; set; }
        public double price { get; set; }
        public int capacity { get; set; }
    }
}
