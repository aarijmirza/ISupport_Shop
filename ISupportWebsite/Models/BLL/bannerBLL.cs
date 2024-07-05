using Newtonsoft.Json.Linq;
using System.Data;
using WebAPICode.Helpers;

namespace ISupportWebsite.Models.BLL
{
    public class BannerBLL
    {
        public int? BannerID { get; set; }
        public int? ServiceID { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        public string? ArabicTitle { get; set; }
        public string? SubTitle { get; set; }
        public string? ArabicSubTitle { get; set; }
        public string? Description { get; set; }
        public string? ArabicDescription { get; set; }
        public string? Image { get; set; }
        public int? StatusID { get; set; }
        public int? CompanyID { get; set; }
        public DateTime? CreationDate { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;

        public List<BannerBLL> GetServiceBanner()
        {
            try
            {
                var lst = new List<BannerBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetServiceBanner_Web");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<BannerBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
