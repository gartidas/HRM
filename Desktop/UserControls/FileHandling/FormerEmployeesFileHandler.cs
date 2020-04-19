using Desktop.Models;
using Desktop.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.UserControls.FileHandling
{
    class FormerEmployeesFileHandler : IFileHandler
    {
        public async Task<List<Document>> LoadFilesAsync(string subjectId)
        {
            var result = await ApiHelper.Instance.GetAllDocumentsOfFormerEmployeeAsync(subjectId);
            return result;
        }

        public async Task<string> LoadSubjectEmailAsync(string subjectId)
        {
            var result = await ApiHelper.Instance.GetSelectedFormerEmployeeAsync(subjectId);

            if (result != null)
            {
                return result.Email;
            }

            return default;
        }

        public Task<AlternativeGenericResponse> RemoveFileAsync(string documentId)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> UploadFileAsync(string subjectId, byte[] content, string name)
        {
            throw new NotImplementedException();
        }
    }
}
