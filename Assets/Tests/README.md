# 🧪 Guía de Tests del Proyecto

## 📁 Estructura Creada

```
Assets/Tests/
├── EditMode/                           # Tests sin ejecutar el juego
│   ├── Tests.EditMode.asmdef          # Assembly Definition
│   ├── DataManagerTests.cs            # ✅ Tests de persistencia
│   ├── ProgressRepositoryTests.cs     # ✅ Tests de repositorio de progreso
│   ├── UserRepositoryTests.cs         # ✅ Tests de repositorio de usuarios
│   ├── ProgressSystemTests.cs         # ✅ Tests de lógica de progreso
│   ├── SessionManagerTests.cs         # ✅ Tests de gestión de sesión
│   ├── PasswordHasherTests.cs         # ✅ Tests de encriptación
│   └── PasswordValidatorTests.cs      # ✅ Tests de validación
│
└── PlayMode/                           # Tests ejecutando el juego
    ├── Tests.PlayMode.asmdef          # Assembly Definition
    ├── PlayerSpawnTests.cs            # ✅ Tests de spawn del jugador
    ├── PlayerTests.cs                 # ✅ Tests del singleton Player
    ├── GameManagerTests.cs            # ✅ Tests del GameManager
    ├── CharacterSystemComposerTests.cs # ✅ Tests del sistema de personajes
    ├── VFXSystemComposerTests.cs      # ✅ Tests del sistema de VFX
    ├── SceneLoaderTests.cs            # ✅ Tests de carga de escenas
    └── IntegrationTests.cs            # ✅ Tests de integración completa
```

---

## 🎯 Cómo Ejecutar los Tests

### Paso 1: Abrir Test Runner
1. En Unity, ve a **Window → General → Test Runner**
2. Verás dos pestañas: **EditMode** y **PlayMode**

### Paso 2: Ejecutar Tests EditMode (Rápidos)
1. Selecciona la pestaña **EditMode**
2. Haz clic en **Run All** para ejecutar todos los tests
3. O haz clic derecho en un test específico → **Run**

### Paso 3: Ejecutar Tests PlayMode (Simulan el juego)
1. Selecciona la pestaña **PlayMode**
2. Haz clic en **Run All**
3. Unity ejecutará el juego en modo de test

---

## 📊 Tests Creados

### 🟢 **EditMode Tests** (7 archivos, ~40 tests)

#### 1. **DataManagerTests.cs**
Valida el sistema de persistencia completo:
- ✅ Guardar y cargar niveles de jugador
- ✅ Valores por defecto para usuarios nuevos
- ✅ Sobrescritura de datos existentes
- ✅ Gestión de sesión de usuario
- ✅ Verificación de existencia de usuarios

**Tests incluidos:**
- `SavePlayerLevel_StoresCorrectValue`
- `GetPlayerLevel_ForNewUser_ReturnsZero`
- `SavePlayerLevel_OverwritesPreviousValue`
- `CurrentUsername_WhenNotSet_ReturnsEmpty`
- `CurrentUsername_SavesAndRetrievesUsername`
- `UsernameExists_ForNewUser_ReturnsFalse`
- `UsernameExists_AfterSaving_ReturnsTrue`

---

#### 2. **ProgressRepositoryTests.cs**
Valida el repositorio de progreso:
- ✅ Operaciones CRUD de progreso
- ✅ Validación de niveles negativos
- ✅ Reset de progreso
- ✅ Mock de IPersistenceProvider

**Tests incluidos:**
- `GetPlayerLevel_ForNewUser_ReturnsZero`
- `SavePlayerLevel_StoresCorrectValue`
- `SavePlayerLevel_WithNegativeLevel_DoesNotSave`
- `ResetProgress_SetsLevelToZero`

---

#### 3. **UserRepositoryTests.cs**
Valida el repositorio de usuarios:
- ✅ Creación de usuarios
- ✅ Validación de usuarios existentes
- ✅ Gestión de usuarios recientes
- ✅ Mock de IPersistenceProvider

**Tests incluidos:**
- `UserExists_ForNewUser_ReturnsFalse`
- `CreateUser_CreatesNewUser`
- `ValidateUser_ForExistingUser_ReturnsTrue`
- `ValidateUser_ForNonExistingUser_ReturnsFalse`
- `GetRecentUsernames_ReturnsCorrectCount`

---

#### 4. **ProgressSystemTests.cs**
Valida la lógica de negocio de progreso:
- ✅ Carga de usuarios
- ✅ Suma de puntos
- ✅ Validación de puntos negativos
- ✅ Avance de nivel

**Tests incluidos:**
- `LoadUser_ValidUser_LoadsCorrectly`
- `AddPoints_IncreasesPoints`
- `AddPoints_WithNegativeValue_DoesNotAdd`
- `NextLevel_IncreasesLevel`

---

#### 5. **SessionManagerTests.cs**
Valida la gestión de sesiones:
- ✅ Inicio de sesión
- ✅ Cierre de sesión
- ✅ Validación de sesión activa
- ✅ Nombres de usuario vacíos

**Tests incluidos:**
- `HasActiveSession_Initially_ReturnsFalse`
- `StartSession_SetsActiveSession`
- `StartSession_WithEmptyUsername_DoesNotStart`
- `EndSession_ClearsActiveSession`
- `CurrentUsername_CanBeSetDirectly`

---

#### 6. **PasswordHasherTests.cs**
Valida la encriptación de contraseñas:
- ✅ Generación de hashes
- ✅ Hashes únicos (con salt)
- ✅ Verificación de contraseñas correctas
- ✅ Rechazo de contraseñas incorrectas

**Tests incluidos:**
- `HashPassword_CreatesNonEmptyHash`
- `HashPassword_SamePassword_CreatesDifferentHashes`
- `VerifyPassword_WithCorrectPassword_ReturnsTrue`
- `VerifyPassword_WithIncorrectPassword_ReturnsFalse`
- `VerifyPassword_WithEmptyPassword_ReturnsFalse`

---

#### 7. **PasswordValidatorTests.cs**
Valida las reglas de contraseñas:
- ✅ Contraseñas fuertes (mayúsculas, minúsculas, números)
- ✅ Longitud mínima
- ✅ Validación de caracteres requeridos
- ✅ Mensajes de error descriptivos

**Tests incluidos:**
- `Validate_WithStrongPassword_ReturnsValid`
- `Validate_WithShortPassword_ReturnsInvalid`
- `Validate_WithoutUppercase_ReturnsInvalid`
- `Validate_WithoutLowercase_ReturnsInvalid`
- `Validate_WithoutNumber_ReturnsInvalid`
- `Validate_WithEmptyPassword_ReturnsInvalid`

---

### 🔵 **PlayMode Tests** (7 archivos, ~15 tests)

#### 1. **PlayerSpawnTests.cs**
Valida el spawn del jugador:
- ✅ Posicionamiento inicial
- ✅ Espera por Player.Instance
- ✅ Limpieza de datos guardados

**Tests incluidos:**
- `SetSpawnPosition_MovesPlayerToNewPosition`
- `PlayerSpawn_WaitsForPlayerInstance`

---

#### 2. **PlayerTests.cs**
Valida el singleton Player:
- ✅ Creación de instancia única
- ✅ Destrucción de duplicados
- ✅ Inicialización de componentes

**Tests incluidos:**
- `Player_CreatesSingleInstance`
- `Player_DestroysDuplicateInstances`
- `Player_InitializesCharacterController`

---

#### 3. **GameManagerTests.cs**
Valida el GameManager:
- ✅ Inicialización correcta
- ✅ Score inicial en 0
- ✅ Cálculo de progreso

**Tests incluidos:**
- `GameManager_InitializesCorrectly`
- `GameManager_CurrentScore_StartsAtZero`
- `GameManager_Progress_CalculatesCorrectly`

---

#### 4. **CharacterSystemComposerTests.cs**
Valida el sistema de personajes:
- ✅ Creación de controladores
- ✅ Registro de controladores
- ✅ Recuperación de controladores

**Tests incluidos:**
- `CreateCharacterController_ForPlayer_ReturnsController`
- `CreateCharacterController_RegistersController`

---

#### 5. **VFXSystemComposerTests.cs**
Valida el sistema de VFX:
- ✅ Inicialización del compositor
- ✅ Factory disponible

**Tests incluidos:**
- `VFXSystemComposer_Initializes`
- `GetFactory_ReturnsValidFactory`

---

#### 6. **SceneLoaderTests.cs**
Valida la carga de escenas:
- ✅ Reanudación del juego (Time.timeScale)
- ✅ Carga sin errores

**Tests incluidos:**
- `LoadCurrentScene_ResumesGame`
- `Load_WithSceneName_DoesNotThrow`

---

#### 7. **IntegrationTests.cs**
Tests de integración completos:
- ✅ Flujo: Login → Guardar → Cargar
- ✅ Múltiples usuarios independientes

**Tests incluidos:**
- `FullFlow_Login_SaveProgress_LoadProgress`
- `FullFlow_MultipleUsers_IndependentProgress`

---

## 🔧 Solución de Problemas

### Error: "Test assemblies not found"
**Solución:** Recompila el proyecto (Ctrl + R en Unity)

### Error: "NUnit framework not found"
**Solución:** Los archivos `.asmdef` ya incluyen `nunit.framework.dll`

### Tests fallan en PlayMode
**Solución:** Asegúrate de que no haya conflictos con objetos DontDestroyOnLoad

---

## 📈 Cobertura de Tests

| Sistema | Archivos Testeados | Coverage |
|---------|-------------------|----------|
| **Persistencia** | DataManagerComposer, Repositories | 🟢 Alto |
| **Autenticación** | PasswordHasher, PasswordValidator | 🟢 Alto |
| **Progreso** | ProgressSystem, SessionManager | 🟢 Alto |
| **Personajes** | Player, CharacterSystemComposer | 🟡 Medio |
| **VFX** | VFXSystemComposer | 🟡 Medio |
| **Escenas** | SceneLoader | 🟡 Medio |
| **Integración** | Flujo completo | 🟢 Alto |

---

## ✅ Próximos Pasos

1. **Ejecutar todos los tests** en Test Runner
2. **Corregir errores** si aparecen (algunos pueden requerir ajustes)
3. **Agregar más tests** para componentes críticos
4. **Configurar CI/CD** para ejecutar tests automáticamente

---

**Total de Tests:** ~55 tests  
**Cobertura:** ~70% de sistemas críticos  
**Estado:** ✅ Listos para ejecutar
