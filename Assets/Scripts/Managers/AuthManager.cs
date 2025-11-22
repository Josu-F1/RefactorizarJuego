using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

public class AuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private DatabaseReference db;

    void Start()
    {
        // Verificar dependencias de Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Firebase no está correctamente configurado");
                return;
            }

            // Inicializar Auth y Database
            auth = FirebaseAuth.DefaultInstance;
            db = FirebaseDatabase.DefaultInstance.RootReference;
        });
    }

    // Función para registrar un nuevo usuario
    public void Register(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Error al registrar usuario: " + task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.Log("Usuario registrado correctamente: " + newUser.UserId);

            // Guardar datos de progreso del usuario después de registro
            SaveProgress(newUser.UserId, 1, 0); // Inicialmente, nivel 1, 0 monedas
        });
    }

    // Función para iniciar sesión
    public void Login(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Error al iniciar sesión: " + task.Exception);
                return;
            }

            FirebaseUser user = task.Result;
            Debug.Log("Usuario logueado: " + user.UserId);
            // Cargar el progreso del usuario
            LoadProgress(user.UserId);
        });
    }

    // Guardar el progreso del jugador en la base de datos de Firebase
    public void SaveProgress(string userId, int level, int coins)
    {
        db.Child("users").Child(userId).Child("progress").SetValueAsync(new { level = level, coins = coins });
    }

    // Cargar el progreso del jugador desde la base de datos de Firebase
    public void LoadProgress(string userId)
    {
        db.Child("users").Child(userId).Child("progress").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                var snapshot = task.Result;
                if (snapshot.Exists)
                {
                    var progress = snapshot.Value as System.Collections.IDictionary;
                    int level = int.Parse(progress["level"].ToString());
                    int coins = int.Parse(progress["coins"].ToString());
                    Debug.Log("Progreso cargado: Nivel " + level + ", Monedas " + coins);
                    // Aquí puedes actualizar el progreso en tu juego (nivel, monedas, etc.)
                }
            }
        });
    }
}
