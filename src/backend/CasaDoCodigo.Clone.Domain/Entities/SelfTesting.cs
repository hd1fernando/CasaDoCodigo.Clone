﻿namespace CasaDoCodigo.Clone.Domain.Entities;

public static class SelfTesting
{
    public static void IsRequiredWithException(string? value, string propName)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException($"{propName} is required.");
    }
}
