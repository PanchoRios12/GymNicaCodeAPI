﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using System.Linq;
public static class FluentValidationExtensions
{
    public static IReadOnlyDictionary<string, string[]> GeneratetDictionary(this ValidationResult validationResult)
    {
        return validationResult.Errors
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new
                    {
                        Key = propertyName,
                        Values = errorMessages.Distinct().ToArray()
                    })
                .ToDictionary(x => x.Key, x => x.Values);
    }
}