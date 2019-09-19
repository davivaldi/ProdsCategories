using System.Collections.Generic;


namespace ProdsCategories.Models
{
    public class AddCategoryViewModel
    {
        public Product Product {get;set;}
        public List<Category> Categories{get;set;}
        public Associations Association{get;set;}
    }
}