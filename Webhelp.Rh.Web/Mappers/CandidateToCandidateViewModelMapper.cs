using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
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