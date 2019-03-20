using Coban.Market.BL.Abstract;
using Coban.Market.Entities;
using System.Linq;

namespace Coban.Market.BL
{
    public class CategoryManager : ManagerBase<Category>
    {
        public override int Delete(Category category)
        {
            ProductManager noteManager = new ProductManager();
            LikedManager likedManager = new LikedManager();
            CommentManager commentManager = new CommentManager();

            // Kategori ile ilişkili notların silinmesi gerekiyor.
            foreach (Product prd in category.Products.ToList())
            {

                // Note ile ilişikili like'ların silinmesi.
                foreach (Liked like in prd.Likes.ToList())
                {
                    likedManager.Delete(like);
                }

                // Note ile ilişkili comment'lerin silinmesi
                foreach (Comment comment in prd.Comments.ToList())
                {
                    commentManager.Delete(comment);
                }

                noteManager.Delete(prd);
            }

            return base.Delete(category);
        }
    }
}
