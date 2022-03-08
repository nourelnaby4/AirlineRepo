using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_Airline.Vaildation
{
    class RegularExpression_Pattern
    {

        public  Dictionary<string, string> patterns = new Dictionary<string, string>() {
        {"NamePattern", @"^[a-zA-Z''-'\s]{1,40}$"},
        {"EmailPattern", @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"},
        {"WebsitePattern", @"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?"},
        {"PhonePattern", @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$"}
        };

      
        
        
    }
}
