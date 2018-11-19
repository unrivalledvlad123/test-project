namespace gw2_Investment_Tool.Models
{
    public class WhiteListedItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Active { get; set; }
        public int CurrentPrice { get; set; }
    }
}
