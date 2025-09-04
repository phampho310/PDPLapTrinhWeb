using Microsoft.AspNetCore.Mvc;
using PDPDay3View.Models;

namespace PDPDay3View.ViewComponents

{
    public class HotItem : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var hp = new List<Item>
            {
                new Item  { Name = "Nồi cơm", Img = "image/noicom.jpeg" },
                new Item  { Name = "Nồi cơm", Img = "image/noicom.jpeg" },
                new Item  { Name = "Nồi cơm", Img = "image/noicom.jpeg" }

            };

            return View(hp);
        }
    }
}
