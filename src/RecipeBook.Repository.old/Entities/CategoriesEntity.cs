using System.Collections;

namespace RecipeBook.Repository.old.Entities;

public class CategoriesEntity : EnumBaseEntity
{
    public virtual ICollection<RecipesEntity> Recipes { get; set; } = [];
}