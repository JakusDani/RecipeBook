using RecipeBook.Common.Enumeration;

namespace RecipeBook.Common.Models.Requests;

public record UnitOfMeasurementRequest(
    string Name,
    MeasurementSystems MeasurementSystemId);