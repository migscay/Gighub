﻿using System.Web;
using System.Web.Optimization;

namespace Gighub
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/services/attendanceService.js",
                "~/Scripts/app/services/followingService.js",
                "~/Scripts/app/controllers/gigDetailsController.js",
                "~/Scripts/app/controllers/gigsController.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/underscore-min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/animate.css",
                "~/Content/site.css"));
        }
    }
}
