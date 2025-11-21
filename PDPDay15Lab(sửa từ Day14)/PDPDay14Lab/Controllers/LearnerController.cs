using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDPDay14Lab.Data;
using PDPDay14Lab.Models;

namespace PDPDay14Lab.Controllers
{
    public class LearnerController : Controller
    {
        private readonly SchoolContext db;

        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        private int pageSize = 3;
        // GET: Index
        public IActionResult Index(int? mid)
        {
            var learners = (IQueryable<Learner>)db.Learners.Include(m => m.Major);
            if(mid != null)
            {
                learners = (IQueryable<Learner>)db.Learners.Where(l => l.MajorID == mid).Include(m => m.Major);
            }
            /// Tính số trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            // Trả số trang về view để hiển thị nav-trang
            ViewBag.pageNum = pageNum;
            // Lấy dữ liệu trang đầu
            var relust = learners.Take(pageSize).ToList();
            return View(relust);
        }

        public IActionResult LearnerFilter(int? mid, string? keyword, int? pageIndex)
        {
            // lấy toàn bộ learners trong dbset chuyển về IQuerrable<Learner> để query
            var learners = (IQueryable<Learner>)db.Learners;
            // lấy chỉ số trang , nếu chỉ số trang null thì gán ngầm định bằng 1
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            //nếu có mid thì lọc learner theo mid
            if(mid != null)
            {
                //lọc
                learners = learners.Where(l => l.MajorID == mid);
                //gửi mid về view để ghi lại trên nav-Phân trang
                ViewBag.mid = mid;
            }
            // nếu có keyword thì tìm kiếm theo tên
            if(keyword != null)
            {
                // tìm kiếm
                learners = learners.Where(l => l.FirstMidName.ToLower().Contains(keyword.ToLower()));
                // gửi keyword về view để ghi trên nav-phân trang
                ViewBag.keyword = keyword;
            }
            // tính số trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            // gửi số trang về view để hiển thị nav-trang
            ViewBag.pageNum = pageNum;
            // chọn dữ liệu trong trang hiện tại
            var result = learners.Skip(pageSize * (page - 1)).Take(pageSize).Include(m => m.Major);
            return PartialView("LearnerTable", result);
        }

        public IActionResult LearnerByMajorID(int mid)
        {
            var learners = db.Learners.Where(l => l.MajorID == mid).Include(m => m.Major).ToList();
            return PartialView("LearnerTable", learners);
        }

        // GET: Create
        public IActionResult Create()
        {
            // Chỉ cần 1 cách: dùng SelectList
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Nếu model lỗi, vẫn phải gán lại ViewBag.MajorID
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);

            return View(learner);
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            if (db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }

            // Gán SelectList cho dropdown Major
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);

            return View(learner);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("LearnerId,FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (id != learner.LearnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Nếu model lỗi, vẫn gán lại SelectList
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        // Kiểm tra Learner tồn tại
        private bool LearnerExists(int id)
        {
            return (db.Learners?.Any(e => e.LearnerId == id)).GetValueOrDefault();
        }

        // GET: Learner/Delete/5
        public IActionResult Delete(int id)
        {
            if (db.Learners == null)
                return NotFound();

            var learner = db.Learners
                .Include(l => l.Major)
                .Include(e => e.Enrollments)
                .FirstOrDefault(m => m.LearnerId == id);

            if (learner == null)
                return NotFound();

            if (learner.Enrollments.Count() > 0)
                return Content("This learner has some enrollments, can't delete!");

            return View(learner);
        }

        // POST: Learner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null)
                return Problem("Entity set 'Learners' is null.");

            var learner = db.Learners.Find(id);
            if (learner != null)
            {
                db.Learners.Remove(learner);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
