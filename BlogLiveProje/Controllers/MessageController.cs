﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogLiveProje.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IActionResult InBox()
        {
            int id = 12;
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }

   
        public IActionResult MessageDetails(int id)
        {
          
            var value = mm.TGetById(id);
            return View(value);
        }
    }
}
