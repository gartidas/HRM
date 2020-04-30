using Desktop.Models;
using Desktop.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.UserControls.FileHandling
{
    class CandidatesFileHandler : IFileHandler
    {
        public async Task<string> LoadSubjectEmailAsync(string subjectId)
        {
            var result = await ApiHelper.Instance.GetSelectedCandidateAsync(subjectId);

            if (result != null)
            {
                return result.Email;
            }

            return default;
        }

        public async Task<List<Document>> LoadFilesAsync(string subjectId)
        {
            var result = await ApiHelper.Instance.GetAllDocumentsOfCandidateAsync(subjectId);
            return result;
        }

        public async Task<AlternativeGenericResponse> RemoveFileAsync(string documentId)
        {
            var result = await ApiHelper.Instance.RemoveDocumentAsync(documentId);
            return result;
        }

        public async Task<GenericResponse> UploadFileAsync(string subjectId, byte[] content, string name)
        {
            var result = await ApiHelper.Instance.CreateDocumentAsync("candidate", subjectId, content, name);
            return result;
        }
    }
}
