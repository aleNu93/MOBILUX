namespace MOBILUX.Models;

public class Client
{
    public string FullName { get; set; } = "";
    public string IdNumber { get; set; } = "";
    public string Phone { get; set; } = "";
    public string EmailPrimary { get; set; } = "";
    public string EmailSecondary { get; set; } = "";
    public bool EmailNotificationsEnabled { get; set; } = true;
}
