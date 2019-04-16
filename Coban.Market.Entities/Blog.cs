namespace Coban.Market.Entities
{
    public class Blog : MyEntityBase
    {
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Hashtag { get; set; }
        public int MarketUserId { get; set; }
        public virtual MarketUser Owner { get; set; }
    }
}
