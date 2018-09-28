using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebsparkQuiz.Models;

namespace WebsparkQuiz.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class NewsController : Controller
    {
        private static readonly IList<NewsViewModel> NewsModels = new List<NewsViewModel>();
        
        public NewsController()
        {
            InitializeNewsModel();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NewsViewModel>), 200)]
        public IActionResult Get()
        {
            return Ok(NewsModels);
        }
        
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(NewsViewModel), 200)]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var result = NewsModels.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), 201)]
        public IActionResult Post([FromBody] NewsViewModel newsViewModel)
        {
            if (newsViewModel == null)
            {
                return BadRequest();
            }

            newsViewModel.Id = NewsModels.Max(x => x.Id) + 1;
            NewsModels.Add(newsViewModel);
            return Created(this.Request.GetDisplayUrl(), newsViewModel);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(NewsViewModel), 200)]
        public IActionResult Put(int id, [FromBody] NewsViewModel newsViewModel)
        {
            if (newsViewModel == null)
            {
                return BadRequest();
            }

            var result = NewsModels.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            result.Description = newsViewModel.Description;
            result.ImageUrl = newsViewModel.ImageUrl;
            result.NewsUrl = newsViewModel.NewsUrl;
            result.Title = newsViewModel.Title;

            return Ok(newsViewModel);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(NewsViewModel), 200)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var result = NewsModels.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            NewsModels.Remove(result);
            return Ok();
        }

        private static void InitializeNewsModel()
        {
            if (NewsModels.Any())
            {
                return;
            }

            NewsModels.Add(new NewsViewModel()
            {
                Id = 1,
                Description = "How intelligent sparks cooperation.",
                ImageUrl = "/images/inline11.png",
                NewsUrl = "https://www.bbc.co.uk/news/newsbeat-45675726",
                Title = "Why smart people build better societies",
                Category = new NewsCategory()
                {
                    Id = 1,
                    CategoryName = "Capital"
                }
            });

            NewsModels.Add(new NewsViewModel()
            {
                Id = 2,
                Description = "How JK Rowking's novels have influenced the March For Our Lives movement.",
                ImageUrl = "/images/inline9.png",
                NewsUrl = "https://www.bbc.co.uk/news/newsbeat-45642620",
                Title = "How Harry Potter became a rallying cry",
                Category = new NewsCategory()
                {
                    Id = 2,
                    CategoryName = "Culture"
                }
            });

            NewsModels.Add(new NewsViewModel()
            {
                Id = 3,
                Description = "Dali and Picasso are among the surprising names featured in a Paris exhibition.",
                ImageUrl = "/images/inline2.png",
                NewsUrl = "https://www.bbc.co.uk/news/newsbeat-45642620",
                Title = "Why smart people build better societies",
                Category = new NewsCategory()
                {
                    Id = 3,
                    CategoryName = "Designed"
                }
            });
        }
    }
}
