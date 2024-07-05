using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using WebAPICode.Helpers;

namespace ISupportWebsite.Models.BLL
{
    public class ItemBLL
    {
        public int? ItemID { get; set; }
        public int? ServiceID { get; set; }
        public int? CategoryID { get; set; }
        public string? Name { get; set; }
        public string? ArabicName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? AlternateImage { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string? SKU { get; set; }
        public string? Barcode { get; set; }
        public string? Type { get; set; }
        public int? DisplayOrder { get; set; }
        public int? Inventory { get; set; }
        public int? InStock { get; set; }
        public int? IsTrending { get; set; }
        public int? IsOffer { get; set; }
        public int? IsBestSeller { get; set; }
        public int? StatusID { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;

        public List<ItemBLL> GetItems()
        {
            try
            {
                var lst = new List<ItemBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetItems_Web");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<ItemBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ItemBLL> GetFilterItems(int? CategoryID)
        {
            try
            {
                var lst = new List<ItemBLL>();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@CategoryID", CategoryID);
                _dt = (new DBHelper().GetTableFromSP)("sp_GetFilterItems_Web",p);
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<ItemBLL>>();
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
