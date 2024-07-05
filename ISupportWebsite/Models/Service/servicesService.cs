using ISupportWebsite.Models.BLL;

namespace ISupportWebsite.Models.Service
{
    public class servicesService
    {
        serviceBLL _service;
        public servicesService()
        {
            _service = new serviceBLL();
        }

        public List<serviceBLL> GetPopularService()
        {
            try
            {
                return _service.GetPopularService();
            }
            catch (Exception ex)
            {
                return new List<serviceBLL>();
            }
        }
    }
}
