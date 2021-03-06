﻿using System.Web;
using System.Web.Optimization;

namespace ProjetoSGP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //As dependcias do Kendo
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include("~/Scripts/kendo/kendo.all.min.js",
                                                        "~/Scripts/kendo/jszip.min.js",
                                                        "~/Scripts/kendo/cultures/kendo.culture.en-US.min.js",
                                                        "~/Scripts/kendo/cultures/kendo.culture.pt-BR.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include("~/Content/kendo/kendo.common.min.css", "~/Content/kendo/kendo.default.min.css", "~/Content/kendo/kendo.custom.css"));

            bundles.IgnoreList.Clear();

        }
    }
}
