using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using WebAPICode.Helpers;

namespace ISupportWebsite.Models.BLL
{
    public class serviceCategoryBLL
    {
        public int? ServiceCategoryID { get; set; }
        public int? CompanyID { get; set; }
        public string? Name { get; set; }
        public string? ArabicName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? DisplayOrder { get; set; }
        public int? StatusID { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public int? CatCount { get; set; }

        public static DataTable _dt;
        public static DataSet _ds;
        public List<serviceCategoryBLL> GetServiceCategory()
        {
            try
            {
                var lst = new List<serviceCategoryBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetServiceCategory_Web");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<serviceCategoryBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }       
        public List<serviceCategoryBLL> GetServiceCategoryCount()
        {
            try
            {
                var lst = new List<serviceCategoryBLL>();
                _dt = (new DBHelper().GetTableFromSP)("sp_GetServiceCategoryCount_Web");
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<serviceCategoryBLL>>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<serviceBLL> GetServiceByCategoryID(int? id)
        {
            try
            {
                var lst = new List<serviceBLL>();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@ServiceCategoryID", id);
                _dt = (new DBHelper().GetTableFromSP)("sp_GetFilterServicebyID_Web", p);
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
    public class Counts
    {
        public int? Internet { get; set; }
        public int? MobileTablet { get; set; }
        public int? PrinterScanner { get; set; }
        public int? SmartTV { get; set; }
        public int? CCTV { get; set; }
        public int? ComputerSoftware { get; set; }
        public int? ComputerHardware { get; set; }
    }

}
