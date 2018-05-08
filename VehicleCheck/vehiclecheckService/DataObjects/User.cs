using Microsoft.Azure.Mobile.Server;

namespace vehiclecheckService.DataObjects
{
    public class User : EntityData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}