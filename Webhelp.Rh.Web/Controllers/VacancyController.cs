using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Webhelp.Rh.Domain.Entities.Candidate;
using Webhelp.Rh.Domain.Entities.Candidate.Services;
using Webhelp.Rh.Domain.Entities.Vacancy.Services;
using Webhelp.Rh.Web.ViewModel;

namespace Webhelp.Rh.Web.Controllers
{
    public class VacancyController : Controller
    {
        private readonly IVacancyService _vacancyService;
        private readonly ITechnologyService _technologyService;

        public VacancyController(IVacancyService vacancyService, ITechnologyService technologyService)
        {
            _vacancyService = vacancyService;
            _technologyService = technologyService;
        }

        // GET: Vacancy
        public async Task<ActionResult> Index()
        {
            var vacancies = await _vacancyService.GetAll();
            return View(vacancies);
        }

        [HttpGet]
        public async Task<ActionResult> Vacancy(Guid id)
        {
            VacancyViewModel model = new VacancyViewModel() { Id = id, Name = "name" };
            //await _service.GetById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var vacancies = await _vacancyService.GetAll();
            return View(vacancies);
        }

        [HttpPost]
        public async Task<ActionResult> Create(VacancyViewModel vacancy)
        {
            if (ModelState.IsValid)
            {
                await _vacancyService.Create(vacancy.Name, vacancy.Technologies);

                return RedirectToAction("Index");
            }

            return View(vacancy);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var create = new VacancyViewModel();

            await CreateTechnologiesListBox();

            return View(create);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(VacancyViewModel vacancy)
        {
            try
            {
                await _vacancyService.Update(vacancy.Id, vacancy.Name, vacancy.Technologies);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var vacancy = await _vacancyService.GetById(id);

            var technologies = vacancy.Technologies?.Select(t => t.TechnologyId).ToArray();

            if (vacancy != null)
            {
                var model = new VacancyViewModel()
                {
                    Id = vacancy.Id,
                    Name = vacancy.Name,
                    Technologies = technologies
                };

                await CreateTechnologiesListBox();

                return View(model);
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _vacancyService.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        private async Task CreateTechnologiesListBox()
        {
            var technologies = await _technologyService.GetAll();

            ViewBag.listTechnologies = new MultiSelectList(technologies, "Id", "Name");
        }
    }
}