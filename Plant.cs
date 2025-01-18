namespace Extravert
{
  class Plant
  {
    public required string Species { get; set; }
    public int LightNeeds { get; set; }
    public decimal AskingPrice { get; set; }
    public required string City { get; set; }
    public int ZIP { get; set; }
    public bool Sold { get; set; }

    public DateTime AvailableUntil { get; set; }
  }
}
