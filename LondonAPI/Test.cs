using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LondonAPI
{
    public class Test
    {

        // declareing a delegate with some signuture
        public delegate string FullName(string namn, string efternamn);
        public event FullName FullNameEvent;

        public class myArgs : EventArgs { public string Namn; public string EfterNamn; };

        public event EventHandler<myArgs> FullnameEventHandler;


        public string Foo()
        {

            // Alt.1
            // assigning a method
            // fullName user1 = fullNameFunc; 

            // alt.2
            // using anonymous method by using delegate keyword 
            // fullName user1 =  delegate (string namn, string efternamn)
            //  {
            //      return string.Format("FullName {0} {1}",namn,efternamn);
            //  };

            // alt.3
            // using lambda creating anonymous method
            // fullName user1 = (string namn, string efternamn) => { return string.Format("FullName {0} {1}", namn, efternamn); };

            // alt 4.
            // using lambda creating anonymous method 2, eleminera måsvingar om den har endast en parantes. 
            // FullName user = (namn, efternamn) => string.Format("FullName {0} {1}", namn, efternamn);


            // alt.5
            // Func with Anonymous Method, specify the keyword delegate and return, also specify datatype for input.
            Func<string, string, string> user3 = delegate (string namn, string efternamn) { return string.Format("Fullname {0} {1}", namn, efternamn); };


            // alternativ 6
            // Func<> with lambda expression, specify lambda operator and no return keyword, no need to specify datatype in the signature for the anonymous method
            // Func<string,string,string> user2 = (namn,efternamn) => string.Format("Fullname {0} {1}", namn, efternamn);

            // This called statement Lambda, har måsvingar och flera statement kan göras.
            // Func<string, string, string> user2 = (namn, efternamn) =>
            // {
            //    return string.Format("Fullname {0} {1}", namn, efternamn);
            // };

            //return null;
            // return user("Adam", "Rashid"); alternativ 4.

            //if(!string.IsNullOrEmpty(user3("Adam", "Rashid"))
            //{
            if (FullNameEvent != null)
            {
                FullNameEvent.Invoke("Adam", "Rashid");
                FullnameEventHandler.Invoke(this, new myArgs() { Namn = "Adam", EfterNamn = "Rashid" });
                return "Ok";
            }
            else
            {
                return "No";
            }

            // test 1.
            //return user3("Adam", "Rashid");
            //}

        }

        public string FullNameFunc(string namn, string efternamn)
        {
            return string.Format("FullName {0} {1}", namn, efternamn);
        }


    }
}
