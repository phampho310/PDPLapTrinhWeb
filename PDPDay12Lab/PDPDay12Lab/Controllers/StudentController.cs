using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDPDay12Lab.Models;

namespace PDPDay12Lab.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents;
        private readonly IWebHostEnvironment hostingEnvironment;
        public StudentController(IWebHostEnvironment hostingEnvironment)
        {
            // Tạo danh sách sinh viên với 4 dữ liệu mẫu
            listStudents = new List<Student>()
            {
                new Student() { Id = 101, Name = "Hải Nam", Branch = Branch. IT,
                    Gender = Gender. Male, IsRegular = true,
                    Address = "A1-2018", Email = "nam@g.com"},
                new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
                    Gender = Gender. Female, IsRegular=true,
                    Address = "A1-2019", Email = "tu@g.com"},
                new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
                    Gender = Gender. Male, IsRegular=false,
                    Address = "A1-2020", Email = "phong@g.com" },
                new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
                    Gender = Gender. Female, IsRegular = false,
                    Address = "A1-2021", Email = "mai@g.com" }
            };
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last<Student>().Id + 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }
            // lấy danh sách các giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            // lấy danh sách các giá trị Branch để hiển thị select-option trên form
            //Để hiển thị select-option trên View cần dùng List<SelectListItem>
            ViewBag.AllBranches = new List<SelectListItem>()
            {
            new SelectListItem { Text = "IT", Value = "1" },
            new SelectListItem { Text = "BE", Value = "2" },
            new SelectListItem { Text="CE", Value = "3" },
            new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student s, IFormFile? ProfileImage)
        {
            if (ProfileImage != null && ProfileImage.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + ProfileImage.FileName;
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImage.CopyToAsync(fileStream);
                }

                s.Avatar = uniqueFileName;
            }



            s.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}
