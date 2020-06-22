using Microsoft.Extensions.Configuration;
using NLog;
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

            LogManager.GetCurrentClassLogger().Debug("****** Application Is Starting ******");

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();



            FBSharepost();

            

            LogManager.GetCurrentClassLogger().Debug("****** Action compleated ******");
        }

        static void FBSharepost()
        {

            
            var fb = new Facebook();
            fb.Login();

            var groups = new List<string>() {
                "ථේරවාදී ඇසින් අටුවාව",
                "Path Nirvana Discussion",
                "කල්‍යාණ දහම් මණ්ඩපය",
                "පිංඅනුමෝදනා! පත්තානුමෝදනා!Offering Merits!",
                "බුදුන් වැඩි මග",
                "අමා දහර. amaa dhahara",
                "නිර්මල බුදු දහම..nirmala bududhama",
                "ඇදිරිනීතිය ඵලදායිව ගතගතකරන්නන්ගේ සංසදය",
                "තථාගත ධර්මය ( Thathagatha Dharmaya)",
                "ධර්ම සංඝායනා බෝසත් අඩවිය",
                "ඒහි පස්සිකෝ - Ehi Passiko",
                "෴පන්සිය පනස් ජාතක කථා වස්තුව෴Pansiya Panas Jathaka",
                "යොවුන් දහම් සක්මන | Yowun Daham Sakmana",
                "විශ්ව ආකර්ශන නීතියෙන් වැඩ ගන්නා අය",
                "Sri Dalada Maligawa",
                "දර්ම දානය",
                "සදහම් සුවය",
                "මේ සතර සතිපට්ඨානයට යොමු විය යුතුම කාලයයිTheMin",
                "දහමින් සුවය",
                "මධ්‍යම පළාත් අපි-(We are in Central Province)",
                "සසර",
                "Pansil Maluwa * *පන්සිල් මළුව**",
                "Friends Who Like daham Sithuwili- දහම් සිතුවිලි",
                "Facebook ගැන්සිය"
                };

            fb.SharePost("https://www.facebook.com/pg/SasunKethaAswaddamu/photos/?tab=album&album_id=2642734569315312", groups);

            fb.Logout();
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
