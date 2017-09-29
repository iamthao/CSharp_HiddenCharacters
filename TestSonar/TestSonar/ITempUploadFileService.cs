using System.Web;
namespace TestSonar
{
    public interface ITempUploadFileService
    {
        string SaveFile(HttpPostedFileBase file, int? newWidthImg = null);
        void RemoveFile(string file);

        string FilePath { get; set; }
    }
}
