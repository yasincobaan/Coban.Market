using Coban.Market.BL.Abstract;
using Coban.Market.Entities;
using System.Linq;

namespace Coban.Market.BL
{
    public class CategoryManager : ManagerBase<Category>
    {
        public override int Delete(Category category)
        {
            ProductManager prdManager = new ProductManager();
            LikedManager likedManager = new LikedManager();
            CommentManager commentManager = new CommentManager();
            
            foreach (Product prd in category.Products.ToList())
            {
                foreach (Liked like in prd.Likes.ToList())
                {
                    likedManager.Delete(like);
                }
                foreach (Comment comment in prd.Comments.ToList())
                {
                    commentManager.Delete(comment);
                }
                prdManager.Delete(prd);
            }
            return base.Delete(category);
        }
    }
}
