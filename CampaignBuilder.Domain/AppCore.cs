using CampaignBuilder.Extensions;
using CampaignBuilder.ValueObjects;
using CampaignBuilder.ValueObjects.Exceptions;

namespace CampaignBuilder;

public class CampaignCore
{
    public CampaignCore(Url url,
        Campaign campaign)
    {
        Url = url;
        Campaign = campaign;
    }
    public Url Url { get;}
    public Campaign Campaign { get;}

    public static implicit operator string(CampaignCore campaignCore)
        => campaignCore.ToString();

    public static implicit operator CampaignCore(string link)
    {
        if (string.IsNullOrEmpty(link))
            throw new InvalidUrlException();

        var url = new Url(link);
        var segments = url.Address.Split("?");
        if (segments.Length == 1)
            throw new InvalidUrlException("No segments were provided");

        var pars = segments[1].Split("&");
        var source = pars.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
        var medium = pars.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
        var name = pars.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split("=")[1];
        var id = pars.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
        var term = pars.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
        var content = pars.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

        var campaignCore = new CampaignCore(
            new Url(segments[0]),
            new Campaign(source, medium, name, id, term, content));
        return campaignCore;
    }

    public override string ToString()
    {
        var segments = new List<string>();
        segments.AddIfNotNull("utm_source", Campaign.Source);
        segments.AddIfNotNull("utm_medium", Campaign.Medium);
        segments.AddIfNotNull("utm_campaign", Campaign.Name);
        segments.AddIfNotNull("utm_id", Campaign.Id);
        segments.AddIfNotNull("utm_term", Campaign.Term);
        segments.AddIfNotNull("utm_content", Campaign.Content);
        return $"{Url.Address}?{string.Join("&", segments)}";
    }


}