using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Resolvers;
using System.Web;
using System.Web.Optimization;


namespace MvcAdventurer
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var nullBuilder = new NullBuilder();
            var nullOrderer = new NullOrderer();

            BundleResolver.Current = new CustomBundleResolver();
            var commonStyleBundle = new CustomStyleBundle("~/Bundle/sass");
            commonStyleBundle.Include("~/Content/MyCssStyles/main.scss");
            commonStyleBundle.Orderer = nullOrderer;
            bundles.Add(commonStyleBundle);

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include( "~/Scripts/jquery.validate*"));

           bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

         //   bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/MyCssStyles/Layout.css"));
        }
    }
}
