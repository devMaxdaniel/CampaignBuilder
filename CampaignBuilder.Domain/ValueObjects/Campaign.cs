using CampaignBuilder.ValueObjects.Exceptions;

namespace CampaignBuilder.ValueObjects
{
    public class Campaign : ValueObject
    {
        public Campaign(string source,
            string medium,
            string name,
            string? id = null,
            string? term = null,
            string? content = null)
        {
            Source = source;
            Medium = medium;
            Name = name;
            Id = id;
            Term = term;
            Content = content;

            InvalidCampaignException.ThrowIfNull(source, "Campaign Source is invalid");
            InvalidCampaignException.ThrowIfNull(medium, "Campaign Medium is invalid");
            InvalidCampaignException.ThrowIfNull(name, "Campaign Name is invalid");
        }
        public string Source { get; }
        public string Medium { get; }
        public string Name { get; }
        public string? Id { get; }
        public string? Term { get; }
        public string? Content { get; }
    }
}
