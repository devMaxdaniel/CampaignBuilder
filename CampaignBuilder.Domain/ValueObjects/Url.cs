using CampaignBuilder.ValueObjects.Exceptions;

namespace CampaignBuilder.ValueObjects
{
    public  class Url : ValueObject
    {
              public Url(string address)
        {
            Address = address;
            InvalidUrlException.ThrowIfInvalidUrl(address);
        }

        public string Address { get; }

      
    }
}
