using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Repositories;

public interface IImagesRepository
{
    IEnumerable<ImagesEntity> GetAll();
}