﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager cm=new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetLlistt(id);
            return View(values);
        }
    }
}
