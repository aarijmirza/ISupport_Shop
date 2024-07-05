using Newtonsoft.Json.Linq;
using System.Data;
using WebAPICode.Helpers;

namespace ISupportWebsite.Models.BLL
{
    public class categoryBLL
    {
        public int? CategoryID { get; set; }
        public int? CompanyID { get; set; }
        public string? Name { get; set; }
        public string? ArabicName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? ImageUrl { get; set; }
        public int? DisplayOrder { get; set; }
        public int? StatusID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;
        public List<categoryBLL> GetCategory()
        {
            try
            {
                var lst = new List<categoryBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetAllCategory_Web");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<categoryBLL>>();
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
