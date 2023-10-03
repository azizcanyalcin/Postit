using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostitDataAccessLibrary.Models
{
    public class User
    {
        int Id { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        Email EmailAdress { get; set; } = new Email();
        DateTime Birthday { get; set; }

        
    }
}
