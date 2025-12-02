using UnityEngine;

/// <summary>
/// Validador de entrada de usuario
/// Principio: Single Responsibility Principle (SRP) - Solo validación
/// Principio: Open/Closed Principle (OCP) - Extensible sin modificar
/// </summary>
public class UserInputValidator : IUserInputValidator
{
    private readonly int minLength;
    private readonly int maxLength;
    private readonly bool allowSpaces;
    
    public UserInputValidator(int minLength = 2, int maxLength = 20, bool allowSpaces = false)
    {
        this.minLength = minLength;
        this.maxLength = maxLength;
        this.allowSpaces = allowSpaces;
    }
    
    public bool IsValidUserName(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            return false;
            
        string trimmed = userName.Trim();
        
        if (trimmed.Length < minLength || trimmed.Length > maxLength)
            return false;
            
        if (!allowSpaces && trimmed.Contains(" "))
            return false;
            
        // Verificar caracteres válidos (letras, números, algunos símbolos)
        foreach (char c in trimmed)
        {
            if (!char.IsLetterOrDigit(c) && c != '_' && c != '-')
            {
                if (!allowSpaces || c != ' ')
                    return false;
            }
        }
        
        return true;
    }
    
    public string GetValidationError(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            return "El nombre de usuario no puede estar vacío";
            
        string trimmed = userName.Trim();
        
        if (trimmed.Length < minLength)
            return $"El nombre debe tener al menos {minLength} caracteres";
            
        if (trimmed.Length > maxLength)
            return $"El nombre no puede tener más de {maxLength} caracteres";
            
        if (!allowSpaces && trimmed.Contains(" "))
            return "El nombre no puede contener espacios";
            
        foreach (char c in trimmed)
        {
            if (!char.IsLetterOrDigit(c) && c != '_' && c != '-')
            {
                if (!allowSpaces || c != ' ')
                    return "Solo se permiten letras, números, guiones y guiones bajos";
            }
        }
        
        return "";
    }
}