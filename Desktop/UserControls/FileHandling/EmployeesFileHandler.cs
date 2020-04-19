using Desktop.Models;
using Desktop.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.UserControls.FileHandling
{
    class EmployeesFileHandler : IFileHandler
    {
        public async Task<List<Document>> LoadFilesAsync(string subjectId)
        {
            var result = await ApiHelper.Instance.GetAllDocumentsOfEmployeeAsync(subjectId);
            return result;
        }

        public async Task<string> LoadSubjectEmailAsync(string subjectId)
        {
            var result = await ApiHelper.Instance.GetSelectedEmployeeDataAsync(subjectId);

            if (result != null)
            {
                return result.Data.EmailAddress;
            }

            return default;
        }

        public async Task<AlternativeGenericResponse> RemoveFileAsync(string documentId)
        {
            var result = await ApiHelper.Instance.RemoveDocumentAsync(documentId);
            return result;
        }

        public async Task<GenericResponse> UploadFileAsync(string subjectId, byte[] content, string name)
        {
            var result = await ApiHelper.Instance.CreateDocumentAsync("employee", subjectId, content, name);
            return result;
        }
    }
}
