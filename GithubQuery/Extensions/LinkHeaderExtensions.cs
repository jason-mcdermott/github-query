using System.Linq;
using System.Text.RegularExpressions;

namespace GithubQuery.Extensions
{
    public class LinkHeader
    {
        public string FirstLink { get; set; }
        public string PrevLink { get; set; }
        public string NextLink { get; set; }
        public string LastLink { get; set; }
    }

    public static class LinkHeaderExtensions
    {
        // credit for this code goes to pimbrouwers: 
        // https://gist.github.com/pimbrouwers/8f78e318ccfefff18f518a483997be29
        public static LinkHeader FromHeader(this string linkHeaderString)
        {
            LinkHeader linkHeader = null;

            if (!string.IsNullOrWhiteSpace(linkHeaderString))
            {
                string[] linkStrings = linkHeaderString.Split(',');

                if (linkStrings != null && linkStrings.Any())
                {
                    linkHeader = new LinkHeader();

                    foreach (string linkString in linkStrings)
                    {
                        var relMatch = Regex.Match(linkString, "(?<=rel=\").+?(?=\")", RegexOptions.IgnoreCase);
                        var linkMatch = Regex.Match(linkString, "(?<=<).+?(?=>)", RegexOptions.IgnoreCase);

                        if (relMatch.Success && linkMatch.Success)
                        {
                            string rel = relMatch.Value.ToUpper();
                            string link = linkMatch.Value;

                            switch (rel)
                            {
                                case "FIRST":
                                    linkHeader.FirstLink = link;
                                    break;
                                case "PREV":
                                    linkHeader.PrevLink = link;
                                    break;
                                case "NEXT":
                                    linkHeader.NextLink = link;
                                    break;
                                case "LAST":
                                    linkHeader.LastLink = link;
                                    break;
                            }
                        }
                    }
                }
            }

            return linkHeader;
        }
    }
}
