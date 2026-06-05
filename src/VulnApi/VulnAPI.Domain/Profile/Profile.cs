using System;
using System.Collections.Generic;
using System.Text;

namespace VulnAPI.Domain.Profile
{
    public class Profile
    {
        public Guid Owner { get; set; }
        public string Description { get; set; }
        public Visibility Visibility { get; set; }

    }
}
