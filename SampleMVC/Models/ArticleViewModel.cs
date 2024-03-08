using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebFormApp.BLL.DTOs;

namespace SampleMVC.Models
{
    public class ArticleViewModel
{
    public required IEnumerable<ArticleDTO> Articles { get; set; }
    public required IEnumerable<CategoryDTO> Categories { get; set; }
}
}