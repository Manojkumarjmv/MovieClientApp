namespace MovieLibrary.Client.Models;
public class AzureAdOptions
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string TenantId { get; set; }
    public string Audience { get; set; }
    public string Issuer1 { get; set; }
    public string Issuer2 { get; set; }
    public string Scope { get; set; }
}