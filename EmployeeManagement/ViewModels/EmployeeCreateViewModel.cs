using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeCreateViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Dept? Department { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
