using BlogLiveProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogLiveProje.ViewComponents
{
	public class CommentList:ViewComponent
	{ public IViewComponentResult Invoke()
		{
			var commentvalues=new List<UserComment>();
			{
                var commentValues = new List<UserComment>
            {
                new UserComment
                {
                     ID=1,
                      UserName="Samet"
                },
                new UserComment
                {
                     ID=2,
                      UserName="Burak"
                },
                new UserComment
                {
                     ID=3,
                      UserName="Muco"
                }
            };


            }
			return View(commentvalues);
		}
	}
}
