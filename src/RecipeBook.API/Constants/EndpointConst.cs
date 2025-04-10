namespace RecipeBook.API.Constants;

public static class EndpointConst
{
    private const string _basePath = "/api/v1";

    public static class Recipe
    {
        private const string _recipeBase = "recipe";

        public const string GetAll = $"{_basePath}/{_recipeBase}";
        public const string GetById = $"{_basePath}/{_recipeBase}/{{id:guid}}";
        public const string Create = $"{_basePath}/{_recipeBase}";
        public const string Update = $"{_basePath}/{_recipeBase}/{{id:guid}}";
        public const string Delete = $"{_basePath}/{_recipeBase}/{{id:guid}}";
    }
}