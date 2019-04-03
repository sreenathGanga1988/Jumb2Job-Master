using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace QuizAPI.Services
{
    public class Sitemapsection
    {
    }




    public class UrlSitenodes
    {

        public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }

        public IReadOnlyCollection<SitemapNode> GetSitemapNodes(UrlHelper urlHelper)
        {
            List<SitemapNode> nodes = new List<SitemapNode>();


            nodes.Add(
               new SitemapNode()
               {
                   Url = AbsoluteRouteUrl(urlHelper, "", new
                   {
                       action = "InterviewDoesandDont",
                       controller = "HRInterview"
                   }),
                   Priority = 0.9,
                   LastModified = new DateTime(2018, 11, 15),
                   Frequency = SitemapFrequency.Weekly
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = AbsoluteRouteUrl(urlHelper, "", new
                   {
                       action = "CommonHRQuestions",
                       controller = "HRInterview"
                   }),
                   Priority = 0.9,
                   LastModified = new DateTime(2018, 11, 15),
                   Frequency = SitemapFrequency.Weekly
               });


            nodes.Add(
              new SitemapNode()
              {
                  Url = AbsoluteRouteUrl(urlHelper, "", new
                  {
                      action = "PreparingforInterview",
                      controller = "HRInterview"
                  }),
                  Priority = 0.9,
                  LastModified = new DateTime(2018, 11, 15),
                  Frequency = SitemapFrequency.Weekly
              });



            nodes.Add(
         new SitemapNode()
         {
             Url = AbsoluteRouteUrl(urlHelper, "", new
             {
                 action = "SamplePMPQuestion",
                 controller = "Certification"
             }),
             Priority = 0.9,
             LastModified = new DateTime(2018, 11, 15),
             Frequency = SitemapFrequency.Weekly
         });




            nodes.Add(
         new SitemapNode()
         {
             Url = AbsoluteRouteUrl(urlHelper, "", new
             {
                 action = "UaeEquivalancyCertificate",
                 controller = "Documents"
             }),
             Priority = 0.9,
             LastModified = new DateTime(2018, 11, 15),
             Frequency = SitemapFrequency.Weekly
         });


            nodes.Add(
      new SitemapNode()
      {
          Url = AbsoluteRouteUrl(urlHelper, "", new
          {
              action = "PassWordStrengthCheck",
              controller = "Utility"
          }),
          Priority = 0.9,
          LastModified = new DateTime(2018, 11, 22),
          Frequency = SitemapFrequency.Weekly
      });
            nodes.Add(
            new SitemapNode()
                 {
                     Url = AbsoluteRouteUrl(urlHelper, "", new
                     {
                         action = "Index",
                         controller = "JobVaccancies"
                     }),
                     Priority = 0.9,
                     LastModified = new DateTime(2018, 11, 22),
                     Frequency = SitemapFrequency.Weekly
                 });


            nodes.Add(
          new SitemapNode()
          {
              Url = AbsoluteRouteUrl(urlHelper, "", new
              {
                  action = "EnglishPSCQuestions",
                  controller = "KeralaPSC"
              }),
              Priority = 0.9,
              LastModified = new DateTime(2018, 11, 22),
              Frequency = SitemapFrequency.Weekly
          });
            nodes.Add(
        new SitemapNode()
        {
            Url = AbsoluteRouteUrl(urlHelper, "", new
            {
                action = "PSCMalayalamQuestions",
                controller = "KeralaPSC"
            }),
            Priority = 0.9,
            LastModified = new DateTime(2018, 11, 22),
            Frequency = SitemapFrequency.Weekly
        });



            nodes.Add(
                  new SitemapNode()
                  {
                      Url = AbsoluteRouteUrl(urlHelper, "", new
                      {
                          action = "OnlineEnglishPSCTest",
                          controller = "KeralaPSC"
                      }),
                      Priority = 0.9,
                      LastModified = new DateTime(2018, 12, 11),
                      Frequency = SitemapFrequency.Weekly
                  });


            nodes.Add(
                 new SitemapNode()
                 {
                     Url = AbsoluteRouteUrl(urlHelper, "", new
                     {
                         action = "OnlineMalayalamPSCTest",
                         controller = "KeralaPSC"
                     }),
                     Priority = 0.9,
                     LastModified = new DateTime(2018, 12, 11),
                     Frequency = SitemapFrequency.Weekly
                 });


            nodes.Add(
               new SitemapNode()
               {
                   Url = AbsoluteRouteUrl(urlHelper, "", new
                   {
                       action = "MCSD70480HtmlandJavascript",
                       controller = "Certification"
                   }),
                   Priority = 0.9,
                   LastModified = new DateTime(2018, 12, 11),
                   Frequency = SitemapFrequency.Weekly
               });


            nodes.Add(
             new SitemapNode()
             {
                 Url = AbsoluteRouteUrl(urlHelper, "", new
                 {
                     action = "KeralaPSCUniversityAssistantTest",
                     controller = "KeralaPSC"
                 }),
                 Priority = 0.9,
                 LastModified = new DateTime(2018, 12, 13),
                 Frequency = SitemapFrequency.Weekly
             });




            nodes.Add(
             new SitemapNode()
             {
                 Url = AbsoluteRouteUrl(urlHelper, "", new
                 {
                     action = "KeralaPSCUniversityAssistantQuestions",
                     controller = "KeralaPSC",
                     
                    
                 }),
                 Priority = 0.9,
                 LastModified = new DateTime(2018, 12, 13),
                 Frequency = SitemapFrequency.Weekly
             });


            nodes.Add(
           new SitemapNode()
           {
               Url = AbsoluteRouteUrl(urlHelper, "", new
               {
                   action = "index",
                   controller = "JobVaccanies"
              

               }),
               Priority = 0.9,
               LastModified = new DateTime(2018, 12, 13),
               Frequency = SitemapFrequency.Weekly
           });


            nodes.Add(
          new SitemapNode()
          {
              Url = AbsoluteRouteUrl(urlHelper, "", new
              {
                  action = "TestEngine",
                  controller = "test",
                  Area = "OnlineTest"


              }),
              Priority = 0.9,
              LastModified = new DateTime(2019, 03, 15),
              Frequency = SitemapFrequency.Weekly
          });



            return nodes;
        }

        public string AbsoluteRouteUrl(UrlHelper urlHelper, string routeName, object routeValues = null)
        {
            string scheme = urlHelper.RequestContext.HttpContext.Request.Url.Scheme;
            return urlHelper.RouteUrl(routeName, routeValues, scheme);
        }
    }



    public class SitemapNode
    {
        public SitemapFrequency? Frequency { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Priority { get; set; }
        public string Url { get; set; }
    }

    public enum SitemapFrequency
    {
        Never,
        Yearly,
        Monthly,
        Weekly,
        Daily,
        Hourly,
        Always
    }
}