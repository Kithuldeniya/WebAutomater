using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UserAction;
using WebsiteSupport.Facebook;
using WebsiteSupport.Tutanota;

namespace WebAutomater
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();


            //var fb = new Facebook();
            //fb.Login();
            //fb.PostComment("https://www.facebook.com/rajitha.kithuldeniya/posts/1817788215029613", "comment 1");

            //var a = new List<string>() { "comment 1", "comment 2", "comment 3", "comment 4", "comment 5", "comment 6", "comment 7" };
            //fb.PostComment("https://www.facebook.com/rajitha.kithuldeniya/posts/1817788215029613", a, 2);

            //fb.Logout();


            var tn = new Tutanota();
            tn.SignUp();

            //insertToDB();
        }




        //static void insertToDB(){

        //    List<Foo> records;

        //    using (var reader = new StreamReader(@"C:\Users\Rajitha\Test VS projects\WebAutomater\Database\Users.csv"))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        csv.Configuration.HasHeaderRecord = false;
        //        records = csv.GetRecords<Foo>().ToList();
        //    }

        //    var i = 0;
        //    var a = records.Select(r => {
        //        i++;
        //        return new Foo1
        //        {
        //            uid = i,
        //            provi ="Tutanota",
        //            Email = ( $"{r.fname}{(new DateTime(r.year, r.month + 1, r.day)).ToString("yyyy")}{r.lname.Replace(" ","")}@tutanota.com").ToLower(),
        //            pw = r.password
        //        }; });


        //    using (var writer = new StreamWriter(@"C:\Users\Rajitha\Test VS projects\WebAutomater\Database\Users_up.csv"))
        //    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //    {
        //        csv.WriteRecords(a);

        //    }

        //}
    }


    public class Foo
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }

    public class Foo1
    {
        public int uid { get; set; }
        public string provi { get; set; }
        public string Email { get; set; }
        public string pw { get; set; }

    }
}
