using Coban.Market.Entities.Enums;

namespace Coban.Market.Entities
{
    public class FAQ : MyEntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public Faq ProblemTypes { get; set; }
        public string Problem { get; set; }
    }
}
