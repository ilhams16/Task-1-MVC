using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebFormApp.BLL.DTOs;

namespace SampleMVC.Models
{
    public class EditViewModel
{
    public required ArticleDTO Article { get; set; }
    public required IEnumerable<CategoryDTO> Categories { get; set; }
}
}