namespace DhlLesson09Bai2TuLam.Areas.DhlAdmin.Models
{
    public class DhlErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
