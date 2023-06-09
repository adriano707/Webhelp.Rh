using AutoMapper;
using Webhelp.Rh.Domain.Entities.Candidate;
using Webhelp.Rh.Web.ViewModel;

namespace Webhelp.Rh.Web.Mappers
{
    public class CandidateToCandidateViewModelMapper : Profile
    {
        public CandidateToCandidateViewModelMapper()
        {
            CreateMap<Candidate, ListCandidateViewModel>();
        }
    }
}