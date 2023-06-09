using System.Configuration;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Webhelp.Rh.Data;
using Webhelp.Rh.Data.Repository;
using Webhelp.Rh.Domain.Entities.Candidate.Services;
using Webhelp.Rh.Domain.Repository;
using AutoMapper;
using Webhelp.Rh.Domain.Entities.Vacancy.Services;
using Webhelp.Rh.Web.Mappers;

[assembly: OwinStartup(typeof(Webhelp.Rh.Web.Startup))]

namespace Webhelp.Rh.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var connectionString = ConfigurationManager.AppSettings["Database:ConnectionString:App"];

            var container = new UnityContainer();

            container.RegisterType<RhDbContext>();

            container.RegisterType<IRepository, Repository>();

            container.RegisterType<ICandidateService, CandidateService>();

            container.RegisterType<ITechnologyService, TechnologyService>();

            container.RegisterType<IVacancyService, VacancyService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
