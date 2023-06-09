using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Webhelp.Rh.Domain.Entities.Candidate.Services;
using Webhelp.Rh.Domain.Entities.Technology;
using Webhelp.Rh.Web.ViewModel;

namespace Webhelp.Rh.Web.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;
        private readonly ITechnologyService _technologyService;

        public CandidateController(ICandidateService candidateService, ITechnologyService technologyService)
        {
            _candidateService = candidateService;
            _technologyService = technologyService;
        }

        // GET: Candidate
        public async Task<ActionResult> Index()
        {
            var candidates = await _candidateService.GetAll();
            return View(candidates);
        }

        [HttpGet]
        public async Task<ActionResult> Candidate(Guid id)
        {
            CandidateViewModel model = new CandidateViewModel() { Id = id, Name = "name" };
            //await _service.GetById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var candidates = await _candidateService.GetAll();
            return View(candidates);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CandidateViewModel candidate)
        {
            if (ModelState.IsValid)
            {
                await _candidateService.Create(candidate.Name, candidate.Email, candidate.Phone, candidate.Technologies);

                return RedirectToAction("Index");
            }

            return View(candidate);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var create = new CandidateViewModel();

            await CreateTechnologiesListBox();

            return View(create);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CandidateViewModel candidate)
        {
            try
            {
                await _candidateService.Update(candidate.Id, candidate.Name, candidate.Email, candidate.Phone, candidate.Technologies);

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
            var candidate = await _candidateService.GetById(id);

            var technologies = candidate.Technologies?.Select(t => t.TechnologyId).ToArray();

            if (candidate != null)
            {
                var model = new CandidateViewModel()
                {
                    Name = candidate.Name,
                    Email = candidate.Email,
                    Phone = candidate.Phone,
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
                await _candidateService.Delete(id);

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