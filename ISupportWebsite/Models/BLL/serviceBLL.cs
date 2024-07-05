using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using WebAPICode.Helpers;

namespace ISupportWebsite.Models.BLL
{
    public class serviceBLL
    {
        public int? ServiceID { get; set; }
        public int? ItemID { get; set; }
        public int? ServiceCategoryID { get; set; }
        public string? Name { get; set; }
        public string? ArabicName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? AlternateImage { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string? SKU { get; set; }
        public string? Barcode { get; set; }
        public string? Type { get; set; }
        public int? DisplayOrder { get; set; }
        public int? StatusID { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public string? Termsandcondition { get; set; }
        public string? ImageUrl { get; set; }
        public List<Counts>? Counts { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;
        public List<serviceBLL> GetPopularService()
        {
            try
            {
                var lst = new List<serviceBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetPopularService_Web");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<serviceBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<serviceBLL> GetService(int? id)
        {
            try
            {
                var lst = new List<serviceBLL>();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@ServiceID", id);
                _dt = (new DBHelper().GetTableFromSP)("sp_GetFilterService_Web", p);
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<serviceBLL>>();
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
