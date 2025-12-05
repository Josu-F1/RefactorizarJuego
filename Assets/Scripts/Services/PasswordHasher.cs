using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

/// <summary>
/// Servicio de hash de contraseñas aplicando principios SOLID
/// Principio: Single Responsibility Principle (SRP) - Solo maneja hash de contraseñas
/// Patrón: Strategy Pattern - Permite diferentes algoritmos de hash
/// </summary>
public class SecurePasswordHasher : IPasswordHasher
{
    private readonly string salt;
    private readonly int iterations;

    public SecurePasswordHasher(string salt = null, int iterations = 10000)
    {
        // Usar salt personalizado o generar uno por defecto
        this.salt = salt ?? "UnityGameSalt2024_SecureLogin";
        this.iterations = iterations;
    }

    public string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be null or empty");

        try
        {
            // Usar PBKDF2 para mayor seguridad
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), iterations))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 32 bytes = 256 bits
                return Convert.ToBase64String(hash);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[SecurePasswordHasher] Error hashing password: {ex.Message}");
            
            // Fallback a SHA256 si PBKDF2 falla
            return HashWithSHA256(password);
        }
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            return false;

        try
        {
            string hashOfInput = HashPassword(password);
            return hashOfInput.Equals(hashedPassword);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[SecurePasswordHasher] Error verifying password: {ex.Message}");
            return false;
        }
    }

    private string HashWithSHA256(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password + salt);
            byte[] hash = sha256.ComputeHash(saltedPassword);
            return Convert.ToBase64String(hash);
        }
    }
}

/// <summary>
/// Hasher simple para desarrollo/testing
/// Principio: Single Responsibility Principle (SRP)
/// </summary>
public class SimplePasswordHasher : IPasswordHasher
{
    private readonly string salt = "SimpleGameSalt123";

    public string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be null or empty");

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password + salt);
            byte[] hash = sha256.ComputeHash(saltedPassword);
            return Convert.ToBase64String(hash);
        }
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            return false;

        try
        {
            string hashOfInput = HashPassword(password);
            return hashOfInput.Equals(hashedPassword);
        }
        catch (Exception)
        {
            return false;
        }
    }
}

/// <summary>
/// Factory para crear diferentes tipos de hashers
/// Patrón: Factory Pattern
/// </summary>
public static class PasswordHasherFactory
{
    public static IPasswordHasher CreateSecure()
    {
        return new SecurePasswordHasher();
    }

    public static IPasswordHasher CreateSimple()
    {
        return new SimplePasswordHasher();
    }

    public static IPasswordHasher CreateForProduction()
    {
        return new SecurePasswordHasher(iterations: 15000);
    }
}