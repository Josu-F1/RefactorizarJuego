using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// Validador de contraseñas aplicando principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo valida contraseñas
/// Principio: Open/Closed Principle (OCP) - Extensible para nuevas reglas
/// </summary>
public class PasswordValidator : IPasswordValidator
{
    private readonly int minLength;
    private readonly int maxLength;
    private readonly bool requireUppercase;
    private readonly bool requireLowercase;
    private readonly bool requireNumbers;
    private readonly bool requireSpecialChars;

    public PasswordValidator(
        int minLength = 4, 
        int maxLength = 50, 
        bool requireUppercase = false,
        bool requireLowercase = false,
        bool requireNumbers = false,
        bool requireSpecialChars = false)
    {
        this.minLength = minLength;
        this.maxLength = maxLength;
        this.requireUppercase = requireUppercase;
        this.requireLowercase = requireLowercase;
        this.requireNumbers = requireNumbers;
        this.requireSpecialChars = requireSpecialChars;
    }

    public bool IsValidPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            return false;

        if (password.Length < minLength || password.Length > maxLength)
            return false;

        if (requireUppercase && !Regex.IsMatch(password, @"[A-Z]"))
            return false;

        if (requireLowercase && !Regex.IsMatch(password, @"[a-z]"))
            return false;

        if (requireNumbers && !Regex.IsMatch(password, @"[0-9]"))
            return false;

        if (requireSpecialChars && !Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]"))
            return false;

        return true;
    }

    public string GetPasswordValidationError(string password)
    {
        if (string.IsNullOrEmpty(password))
            return "La contraseña no puede estar vacía";

        if (password.Length < minLength)
            return $"La contraseña debe tener al menos {minLength} caracteres";

        if (password.Length > maxLength)
            return $"La contraseña no puede exceder {maxLength} caracteres";

        if (requireUppercase && !Regex.IsMatch(password, @"[A-Z]"))
            return "La contraseña debe contener al menos una letra mayúscula";

        if (requireLowercase && !Regex.IsMatch(password, @"[a-z]"))
            return "La contraseña debe contener al menos una letra minúscula";

        if (requireNumbers && !Regex.IsMatch(password, @"[0-9]"))
            return "La contraseña debe contener al menos un número";

        if (requireSpecialChars && !Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]"))
            return "La contraseña debe contener al menos un carácter especial";

        return string.Empty;
    }

    public bool PasswordsMatch(string password, string confirmPassword)
    {
        return !string.IsNullOrEmpty(password) && password.Equals(confirmPassword);
    }
}

/// <summary>
/// Configuración predefinida para validadores de contraseñas
/// Patrón: Factory Pattern
/// </summary>
public static class PasswordValidatorFactory
{
    public static IPasswordValidator CreateSimple()
    {
        return new PasswordValidator(minLength: 3, maxLength: 20);
    }

    public static IPasswordValidator CreateSecure()
    {
        return new PasswordValidator(
            minLength: 8, 
            maxLength: 128,
            requireUppercase: true,
            requireLowercase: true,
            requireNumbers: true
        );
    }

    public static IPasswordValidator CreateForGame()
    {
        return new PasswordValidator(
            minLength: 4, 
            maxLength: 20,
            requireNumbers: true
        );
    }
}