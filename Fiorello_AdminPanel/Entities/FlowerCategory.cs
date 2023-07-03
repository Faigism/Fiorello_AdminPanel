namespace Fiorello_AdminPanel.Entities
{
    public class FlowerCategory
    {
        public int FlowerId { get; set; }
        public int CategoryId { get; set; }
        public Flower Flower { get; set; }
        public Category Category { get; set; }
    }
}
