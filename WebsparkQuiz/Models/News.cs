using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsparkQuiz.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string NewsUrl { get; set; }

        public NewsCategory Category { get; set; }
    }
}
