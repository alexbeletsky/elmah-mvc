using System.Text;
using System.Text.RegularExpressions;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace Elmah.Mvc.Tests.Approval
{
    [Ignore]
    [UseReporter(typeof(DiffReporter))]
    public class ElmahMvcTests
    {
        private const string ElmahMvcAppUrl = "http://localhost:49800/elmah";

        [Test]
        public void lock_elmah_mvc_pages()
        {
            // do
            var content = new StringBuilder();            
            var pages = new[] 
                            {
                                ElmahMvcAppUrl,
                                ElmahMvcAppUrl + "/",
                                ElmahMvcAppUrl + "/stylesheet",
                                ElmahMvcAppUrl + "/rss",
                                ElmahMvcAppUrl + "/digestrss",
                                ElmahMvcAppUrl + "/detail?id=5dd2a560-c6fd-4847-a6cc-e3e253db5764",
                                ElmahMvcAppUrl + "/json?id=5dd2a560-c6fd-4847-a6cc-e3e253db5764",
                                ElmahMvcAppUrl + "/xml?id=5dd2a560-c6fd-4847-a6cc-e3e253db5764"
                            };

            foreach (var page in pages)
            {
                content.Append(GetContent(page));
            }

            // verify
            ApprovalTests.Approvals.VerifyHtml(content.ToString());
        }

        private string GetContent(string url)
        {
            return HackServertTime(ApprovalTests.Asp.AspApprovals.GetUrlContents(url));
        }

        private string HackServertTime(string content)
        {
            var pattern = "<p id=\"Footer\">(.*)</p>";
            return new Regex(pattern).Replace(content, string.Empty);
        }
    }
}
