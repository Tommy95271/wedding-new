using System.Web;
using System.Web.Optimization;

namespace prjWedding
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-2.2.4.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/main.js",
                      "~/Scripts/custom.js",
                      "~/Scripts/swiper.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/responsive.css",
                      "~/Content/custom.css",
                      "~/Content/style.css",
                      "~/Content/PagedList.css"));
        }
    }
}
