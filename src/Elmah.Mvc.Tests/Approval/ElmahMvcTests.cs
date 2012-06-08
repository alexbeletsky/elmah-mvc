using System.Text.RegularExpressions;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace Elmah.Mvc.Tests.Approval
{
    [UseReporter(typeof(DiffReporter))]
    public class ElmahMvcTests
    {
        private readonly string ElmahMvcAppUrl = "http://localhost:49800";

        [Test]
        public void should_open_elmah_page(string path)
        {
            // do
            var url = ElmahMvcAppUrl + path;

            // verify
            ApprovalTests.Approvals.VerifyHtml(GetContent(url));
        }

        [Test]
        public void should_open_stylesheets()
        {
            // do
            var url = ElmahMvcAppUrl + "/admin/elmah/stylesheet";

            // verify
            ApprovalTests.Approvals.VerifyHtml(GetContent(url));            
        }

        [Test]
        public void should_open_rss()
        {
            // do
            var url = ElmahMvcAppUrl + "/admin/elmah/rss";

            // verify
            ApprovalTests.Approvals.VerifyHtml(GetContent(url));            
        }

        [Test]
        public void should_open_digest_rss()
        {
            // do
            var url = ElmahMvcAppUrl + "/admin/elmah/digestrss";

            // verify
            ApprovalTests.Approvals.VerifyHtml(GetContent(url));
        }

        [Test]
        public void should_open_details()
        {
            // do
            var url = ElmahMvcAppUrl + "/admin/elmah/detail?id=d5b2db50-0d5b-4c1d-a4dc-30324081191a";

            // verify
            ApprovalTests.Approvals.VerifyHtml(GetContent(url));
        }

        [Test]
        public void should_open_not_found_page()
        {
            // do
            var url = ElmahMvcAppUrl + "/admin/elmah/detail";

            // verify
            ApprovalTests.Approvals.VerifyHtml(GetContent(url));
        }

        [Test]
        public void should_open_json_page()
        {
            // do
            var url = ElmahMvcAppUrl + "/admin/elmah/json?id=d6c13c5b-f57f-41e0-b23d-6de2dfa5bba7";

            // verify
            ApprovalTests.Approvals.VerifyHtml(GetContent(url));
        }

        [Test]
        public void should_open_xml_page()
        {
            // do
            var url = ElmahMvcAppUrl + "/admin/elmah/xml?id=d6c13c5b-f57f-41e0-b23d-6de2dfa5bba7";

            // verify
            ApprovalTests.Approvals.VerifyHtml(GetContent(url));
        }

        private string GetContent(string url)
        {
            return HackServertTime(ApprovalTests.Asp.AspApprovals.GetUrlContents(url));
        }

        private string HackServertTime(string content)
        {
            return new Regex("Server time is \\d+:\\d+:\\d+").Replace(content, string.Empty);
        }
    }
}
