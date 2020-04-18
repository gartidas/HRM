using Desktop.Models;
using Desktop.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.UserControls.FileHandling
{
    public interface IFileHandler
    {
        Task<string> LoadSubjectEmailAsync(string subjectId);
        Task<GenericResponse> UploadFileAsync(string subjectId, byte[] content, string name);
        Task<List<Document>> LoadFilesAsync(string subjectId);
        Task<AlternativeGenericResponse> RemoveFileAsync(string documentId);
    }
}
