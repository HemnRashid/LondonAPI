using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LondonAPI
{
    public class Test
    {

            public delegate string fullName(string namn, string efternamn);

            public string t()
            {
                fullName user1 = fullNameFunc;


                return user1("Adam", "Rashid");
            }

            public string fullNameFunc(string name,string efternamn)
            {
                return name + efternamn;
            }


    }
}
