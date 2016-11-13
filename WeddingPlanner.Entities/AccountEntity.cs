using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPlanner.Entities
{
    public class AccountEntity
    {
        string Email { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        string BrideName { get; set; }
        string GroomName { get; set; }
        DateTime WeddingDate { get; set; }
        DateTimeOffset WeddingTime { get; set; }

    }
}
