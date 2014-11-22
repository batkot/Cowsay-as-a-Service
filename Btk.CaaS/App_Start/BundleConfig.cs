﻿using System.Web;
using System.Web.Optimization;

namespace Btk.CaaS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/countdown").Include(
                        "~/Scripts/TimeSpan-{version}.js").Include(
                        "~/Scripts/countdown.js"));

            bundles.Add(new ScriptBundle("~/bundles/cow").Include(
                        "~/Scripts/cowAnim.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/css/countdown").Include(
                "~/Content/Countdown.css"));
        }
    }
}
