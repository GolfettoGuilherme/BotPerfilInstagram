using System;

namespace BotInstagramProfile
{
    class Program
    {
        static void Main(string[] args)
        {
            var profile = Instagram.GetProfileByUser("guigolfetto");

            Console.WriteLine($"UserName: {profile.UserName}");
            Console.WriteLine($"Title: {profile.Title}");
            Console.WriteLine($"Image: {profile.Image}");

            Console.ReadKey();
        }
    }
}
