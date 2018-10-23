using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UserStudyApi.Models;
using Newtonsoft.Json;

namespace UserStudyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly SurveyContext _context;

        public SurveyController(SurveyContext context)
        {
            _context = context;

            if (_context.SurveyItems.Count() == 0)
            {
                var surveyList = new List<Survey> {
                    new Survey { SurveyId = "A-ID", Answer = 1, UserId = "ABC" },
                    new Survey { SurveyId = "B", Answer = 5, UserId = "DEF" },
                    new Survey { SurveyId = "C", Answer = 6, UserId = "XYZ" },
                    new Survey { SurveyId = "D", Answer = 2, UserId = "ABC" },
                    new Survey { SurveyId = "A-ID", Answer = 5, UserId = "BCD" }
                };
                _context.AddRange(surveyList);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Survey>> GetAll()
        {
            var surveyData = _context.SurveyItems.ToList();
            var modifiedSurvey = new object();
            var json = JsonConvert.SerializeObject(surveyData);
            foreach (Survey survey in surveyData)
            {
                Console.WriteLine("TEST");
                Console.WriteLine(json);
                var type = modifiedSurvey.GetType();
                if (type.GetMethod(survey.SurveyId) != null)
                {
                    modifiedSurvey[json.SurveyId].Count++;
                    modifiedSurvey[json.SurveyId].Add(json.UserId);
                }
                else
                {
                    modifiedSurvey[json.SurveyId] = new ModifiedSurvey()
                    {
                        Count = 1,
                        UserIds = new string[] {json.UserId}
                    };
                }
            }
            return modifiedSurvey;
        }

        [HttpGet("{id}", Name = "GetSurvey")]
        public ActionResult<Survey> GetById(string id)
        {
            var item = _context.SurveyItems.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}