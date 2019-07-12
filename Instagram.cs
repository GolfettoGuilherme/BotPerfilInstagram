using System.Net;
using HtmlAgilityPack;

namespace BotInstagramProfile
{
    public static class Instagram
    {
        public static Profile GetProfileByUser(string username)
        {
            var profile = new Profile(username);

            string url = @"https://www.instagram.com/" + username + "/";
            string htmlRaw = "";

            using(WebClient client = new WebClient())
            {
                htmlRaw = client.DownloadString(url);
            }

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(htmlRaw);

            var list = html.DocumentNode.SelectNodes("//meta");

            foreach (var node in list)
            {
                string property = node.GetAttributeValue("property", "");
                
                string content = node.GetAttributeValue("content", "");

                switch (property)
                {
                    case "al:ios:app_name":
                        profile.IosAppName = content;
                        break;

                    case "al:ios:app_store_id":
                        profile.IosAppId = content;
                        break;

                    case "al:ios:url":
                        profile.IosUrl = content;
                        break;

                    case "al:android:app_name":
                        profile.AndroidAppName = content;
                        break;

                    case "al:android:package":
                        profile.AndroidAppId = content;
                        break;

                    case "al:android:url":
                        profile.AndroidUrl = content;
                        break;

                    case "og:type":
                        profile.Type = content;
                        break;

                    case "og:image":
                        profile.Image = content;
                        break;

                    case "og:title":
                        profile.Title = content;
                        break;

                    case "og:description":
                        profile.Description = content;
                        break;

                    case "og:url":
                        profile.Url = content;
                        break;

                }
            }

            return profile;
        }
    }
}