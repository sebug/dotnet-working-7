using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OutputFormatterSample;

public class PersonsCsvBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        // Specify a default argument name if none is set by ModelBinderAttribute
        var modelName = bindingContext.BinderModelName;
        if (String.IsNullOrEmpty(modelName))
        {
            modelName = "persons";
        }

        // Try to fetch the value of the argument by name
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

        var value = valueProviderResult.FirstValue;
        // Check if the argument value is null or empty
        if (String.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }

        var stringReader = new StringReader(value);
        var reader = new CsvReader(stringReader, CultureInfo.InvariantCulture);

        var model = reader.GetRecords<Person>().ToList();
        bindingContext.Result = ModelBindingResult.Success(model);

        return Task.CompletedTask;
    }
}