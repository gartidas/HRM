using AutoMapper;
using WebApi.Entities;
using WebApi.Features.Documentation;

namespace WebApi.MappingProfiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, GetAllDocumentsOfEmployee.DocumentDto>();
        }
    }
}
