using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructure.Commons.Bases.Request;
using POS.Infraestructure.Commons.Bases.Response;
using POS.Infraestructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructure.Persistences.Repositories
{
    public class CategoryRepository:GenericRepository<Category>, ICategoryRepository
    {
        private readonly POSContext _context;

        public CategoryRepository(POSContext context)
        {
           _context = context;
        }

        public Task<bool> EditCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseEntityResponse<Category>> ListCategories(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Category>();

            var categories = (from c in _context.Categories
                              where c.AuditDeleteUser == null && c.AuditDeleteDate == null
                              select c).AsNoTracking().AsQueryable();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        categories = categories.Where(x => x.Name!.Contains(filters.TextFilter)); 
                        break;
                    case 2:
                        categories = categories.Where(x => x.Description!.Contains(filters.TextFilter));
                        break;

                }
            }

            if (filters.StateFilter is not null) 
            {
                categories = categories.Where(x => x.State.Equals(filters.StateFilter));
            }

            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndtDate))
            {
                categories = (categories.Where(x => x.AuditCreateDate > Convert.ToDateTime(filters.StartDate) &&
                 x.AuditCreateDate < Convert.ToDateTime(filters.EndtDate).AddDays(1));
            }
        }

        public Task<IEnumerable<Category>> ListSelectCategories()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
