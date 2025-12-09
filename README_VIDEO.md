# 🎥 Guía para Video: Patrones de Diseño en RefactorizarJuego
## Duración: 3 minutos

---

## 🎬 **INTRODUCCIÓN (0:00 - 0:20)**
**"Este proyecto implementa una arquitectura limpia con múltiples patrones de diseño y principios SOLID"**

---

## 📋 **ESTRUCTURA DEL VIDEO**

### **1️⃣ SINGLETON PATTERN (0:20 - 0:50)** 
**¿Qué es?** Una única instancia global accesible desde cualquier parte  
**¿Para qué?** Gestión centralizada de sistemas críticos  
**¿Dónde está?**
```
📂 Assets/Scripts/
   └── Managers/
       ├── GameManager.cs (línea 11)
       │   • Gestiona victoria/derrota
       │   • Coordina eventos globales
       │
       ├── GameManagerComposer.cs
       │   • Versión refactorizada
       │   • Orquesta sistemas especializados
       
   └── VFX/
       └── VFXSystemComposer.cs (línea 12)
           • Singleton para efectos visuales
           • Coordina Factory + Pool + Observer
```

**Qué mostrar en pantalla:**
- Abrir `GameManager.cs` línea 11: `public class GameManager : MonoBehaviourSingleton<GameManager>`
- Destacar `Instance` propiedad estática
- Mostrar llamada desde otra clase: `GameManager.Instance.OnVictory()`

---

### **2️⃣ FACTORY PATTERN (0:50 - 1:20)**
**¿Qué es?** Centraliza la creación de objetos complejos  
**¿Para qué?** Evitar `new` disperso, facilitar testing y extensibilidad  
**¿Dónde está?**

```
📂 Assets/Scripts/
   ├── VFX/
   │   └── VFXFactory.cs (línea 10)
   │       • Crea efectos visuales (explosiones, textos flotantes)
   │       • RegisterEffectPrefab() - línea 21
   │       • CreateEffect() - línea 27
   │
   ├── Character/
   │   └── CharacterControllerFactory.cs
   │       • Crea controladores de personajes (Player, Enemy)
   │       • CreateCharacterController() método
   │
   ├── PoolSystem/
   │   └── PoolFactory.cs
   │       • Crea pools de objetos reutilizables
   │
   ├── Bomb/
   │   └── PooledBombFactory.cs
   │       • Factory específico para bombas
   │
   └── Services/
       └── PasswordHasher.cs (línea 114)
           • PasswordHasherFactory - Crea hashers de contraseñas
```

**Qué mostrar en pantalla:**
- Abrir `VFXFactory.cs` línea 10-27
- Mostrar método `RegisterEffectPrefab()` y `CreateEffect()`
- Ejemplo: `factory.CreateEffect(EffectType.Explosion, position)`

---

### **3️⃣ OBSERVER PATTERN (1:20 - 1:50)**
**¿Qué es?** Notifica cambios sin acoplamiento directo  
**¿Para qué?** Comunicación entre sistemas desacoplados (VFX reacciona a muerte sin conocer Enemy)  
**¿Dónde está?**

```
📂 Assets/Scripts/
   ├── VFX/
   │   ├── VFXGameEventObserver.cs (línea 9)
   │   │   • Escucha eventos del juego
   │   │   • OnEnemyDeath() → Crea efectos
   │   │   • OnPlayerDamaged() → Muestra feedback
   │   │
   │   └── IVFXInterfaces.cs (línea 52)
   │       • IGameEventObserver interface
   │       • Subscribe/Unsubscribe methods
   │
   ├── Services/
   │   ├── PasswordAuthenticationService.cs (línea 8)
   │   │   • Observer para autenticación
   │   │   • OnLoginSuccess event
   │   │
   │   └── SimplePasswordAuthService.cs (línea 9)
   │       • Observer para login simplificado
   │
   └── UI/
       ├── PasswordLoginComponent.cs (línea 9)
       │   • Reacciona a cambios de estado auth
       │
       └── ProgressDisplayUI.cs (línea 6)
           • Observer de progreso de nivel
```

**Qué mostrar en pantalla:**
- Abrir `VFXGameEventObserver.cs` línea 30-50
- Mostrar suscripción: `Enemy.OnAnyEnemyKilled += OnEnemyDeath`
- Mostrar reacción: método `OnEnemyDeath()` crea efectos VFX

---

### **4️⃣ REPOSITORY PATTERN (1:50 - 2:15)**
**¿Qué es?** Abstrae acceso a datos (DB, PlayerPrefs, archivo)  
**¿Para qué?** Cambiar persistencia sin tocar lógica de negocio  
**¿Dónde está?**

```
📂 Assets/Scripts/
   └── Managers/
       ├── UserRepository.cs (línea 5-8)
       │   • Patrón: Repository Pattern
       │   • Gestiona usuarios (CRUD)
       │   • UserExists(), CreateUser(), DeleteUser()
       │   • Usa IPersistenceProvider (abstracción)
       │
       ├── ProgressRepository.cs
       │   • Gestiona progreso de niveles
       │   • SavePlayerLevel(), GetPlayerLevel()
       │
       └── IPersistenceProvider.cs
           • Interfaz para almacenamiento
           • Implementaciones: PlayerPrefs, JSON, SQLite
```

**Qué mostrar en pantalla:**
- Abrir `UserRepository.cs` línea 8-17
- Mostrar constructor: `UserRepository(IPersistenceProvider provider)`
- Explicar: "Si cambio de PlayerPrefs a JSON, solo cambio el provider"

---

### **5️⃣ STRATEGY PATTERN (2:15 - 2:35)**
**¿Qué es?** Intercambia algoritmos en tiempo de ejecución  
**¿Para qué?** Diferentes comportamientos sin if/else gigantes  
**¿Dónde está?**

```
📂 Assets/Scripts/
   ├── Services/
   │   └── PasswordHasher.cs (línea 9)
   │       • Strategy para algoritmos de hash
   │       • SimpleHashStrategy - Básico
   │       • SHA256Strategy - Seguro
   │
   ├── VFX/
   │   ├── VFXEffects.cs (línea 9)
   │   │   • Strategy para comportamientos de efectos
   │   │   • FloatingTextEffect, ColorFlashEffect
   │   │
   │   └── VFXFactory.cs (línea 178)
   │       • Strategy para spawn de efectos
   │
   └── PoolSystem/
       └── PoolStrategyFactory.cs
           • Standard, Aggressive, Conservative
           • Diferentes estrategias de pooling
```

**Qué mostrar en pantalla:**
- Abrir `PasswordHasher.cs` línea 76-120
- Mostrar `SimpleHashStrategy` vs `SHA256Strategy`
- Ejemplo: `var hasher = new PasswordHasher(new SHA256Strategy())`

---

### **6️⃣ FACADE PATTERN + COMPOSER (2:35 - 2:55)**
**¿Qué es?** Simplifica acceso a sistemas complejos  
**¿Para qué?** Interfaz simple para subsistemas múltiples  
**¿Dónde está?**

```
📂 Assets/Scripts/
   ├── VFX/
   │   └── VFXSystemComposer.cs (línea 7)
   │       • Patrón: Facade Pattern
   │       • Orquesta: Factory + Pool + Observer
   │       • API simple: SpawnEffect(type, position)
   │
   ├── Character/
   │   └── CharacterSystemComposer.cs (línea 7)
   │       • Facade para sistema de personajes
   │       • Maneja: Movement + Health + Abilities
   │
   ├── PoolSystem/
   │   └── PoolSystemComposer.cs (línea 15)
   │       • Facade + Composite Pattern
   │       • Coordina pools múltiples
   │
   └── Managers/
       └── GameManagerComposer.cs
           • Facade para gestión del juego
           • Conecta todos los sistemas
```

**Qué mostrar en pantalla:**
- Abrir `VFXSystemComposer.cs` línea 7-50
- Mostrar inicialización: Factory + Pool + Observer
- Ejemplo: `VFXSystemComposer.Instance.SpawnEffect(...)` → internamente usa 3 sistemas

---

### **7️⃣ OBJECT POOL PATTERN (2:55 - 3:10)**
**¿Qué es?** Reutiliza objetos en lugar de crear/destruir  
**¿Para qué?** Optimización de rendimiento (balas, efectos, enemigos)  
**¿Dónde está?**

```
📂 Assets/Scripts/
   ├── VFX/
   │   └── VFXFactory.cs (línea 74-75)
   │       • VFXEffectPool class
   │       • Get() - Obtiene del pool
   │       • Return() - Devuelve al pool
   │
   └── PoolSystem/
       ├── PoolSystemComposer.cs
       │   • Sistema completo de pooling
       │
       └── PoolFactory.cs
           • Crea pools configurables
```

**Qué mostrar en pantalla:**
- Abrir `VFXFactory.cs` línea 74-120
- Mostrar `VFXEffectPool` class
- Diagrama: `Get() → Usa objeto → Return() → Reusa`

---

## 🎯 **CIERRE (3:10 - 3:20)**
**"Esta arquitectura permite:**
- ✅ **Testear** fácilmente (interfaces mock)
- ✅ **Extender** sin romper (OCP)
- ✅ **Cambiar** implementaciones (DIP)
- ✅ **Reutilizar** componentes (Composer)
- ✅ **Optimizar** rendimiento (Pool)"

---

## 📊 **RESUMEN VISUAL RÁPIDO**

| Patrón | Ubicación Principal | Línea Clave | Beneficio |
|--------|---------------------|-------------|-----------|
| **Singleton** | `GameManager.cs` | 11 | Acceso global |
| **Factory** | `VFXFactory.cs` | 10-27 | Creación centralizada |
| **Observer** | `VFXGameEventObserver.cs` | 9, 30-50 | Desacoplamiento |
| **Repository** | `UserRepository.cs` | 8 | Abstracción de datos |
| **Strategy** | `PasswordHasher.cs` | 76-120 | Intercambio de algoritmos |
| **Facade** | `VFXSystemComposer.cs` | 7, 40-70 | Simplificación de API |
| **Pool** | `VFXFactory.cs` | 74-120 | Optimización memoria |

---

## 🎬 **TIPS PARA GRABAR**

### **Pantalla 1: Visual Studio Code**
- Usa split screen para mostrar 2 archivos
- Resalta líneas con el cursor
- Usa búsqueda (Ctrl+F) para saltar rápido a "Patrón:", "Principio:"

### **Pantalla 2: Diagrama (opcional)**
```
[GameManager] ──Singleton──> Acceso Global
      │
      ├──> [VFXSystemComposer] ──Facade──> Simplifica
      │           │
      │           ├──> [VFXFactory] ──Factory──> Crea
      │           ├──> [VFXPool] ──Pool──> Reutiliza
      │           └──> [VFXObserver] ──Observer──> Reacciona
      │
      └──> [UserRepository] ──Repository──> Abstrae Datos
                   │
                   └──> [IPersistenceProvider] ──Strategy──> Intercambia
```

### **Narración Ejemplo:**
> "En la línea 11 de GameManager vemos el patrón Singleton, que nos da acceso global. 
> Luego en VFXFactory línea 27, el Factory centraliza la creación de efectos. 
> El Observer en línea 30 escucha eventos sin acoplamiento. 
> El Repository en UserRepository línea 8 abstrae la persistencia..."

---

## 📝 **CHECKLIST PRE-GRABACIÓN**

- [ ] Abrir Visual Studio Code
- [ ] Cargar proyecto en Unity (para mostrar escena si es necesario)
- [ ] Preparar archivos clave en pestañas:
  - [ ] `GameManager.cs`
  - [ ] `VFXFactory.cs`
  - [ ] `VFXGameEventObserver.cs`
  - [ ] `UserRepository.cs`
  - [ ] `PasswordHasher.cs`
  - [ ] `VFXSystemComposer.cs`
- [ ] Aumentar tamaño de fuente en VS Code (Zoom 150%)
- [ ] Cerrar paneles innecesarios (Terminal, Debug)
- [ ] Preparar cronómetro visible

---

## 🔍 **ATAJOS DE TECLADO ÚTILES**
- `Ctrl + P` → Ir a archivo rápido
- `Ctrl + G` → Ir a línea específica
- `Ctrl + Shift + F` → Buscar en todo el proyecto
- `Ctrl + Click` → Ir a definición

---

## 📌 **ARCHIVOS COMPLETOS DE REFERENCIA**

### Singleton
```
Assets/Scripts/Managers/GameManager.cs (línea 11)
Assets/Scripts/VFX/VFXSystemComposer.cs (línea 12)
Assets/Scripts/Character/CharacterSystemComposer.cs (línea 12)
```

### Factory
```
Assets/Scripts/VFX/VFXFactory.cs (línea 10-27)
Assets/Scripts/Services/PasswordHasher.cs (línea 114)
Assets/Scripts/Character/CharacterControllerFactory.cs
Assets/Scripts/PoolSystem/PoolFactory.cs
```

### Observer
```
Assets/Scripts/VFX/VFXGameEventObserver.cs (línea 9, 30-50)
Assets/Scripts/Services/PasswordAuthenticationService.cs (línea 8)
Assets/Scripts/UI/PasswordLoginComponent.cs (línea 9)
```

### Repository
```
Assets/Scripts/Managers/UserRepository.cs (línea 5-8)
Assets/Scripts/Managers/ProgressRepository.cs
```

### Strategy
```
Assets/Scripts/Services/PasswordHasher.cs (línea 9, 76-120)
Assets/Scripts/VFX/VFXEffects.cs (línea 9)
Assets/Scripts/PoolSystem/PoolStrategyFactory.cs
```

### Facade/Composer
```
Assets/Scripts/VFX/VFXSystemComposer.cs (línea 7, 40-70)
Assets/Scripts/Character/CharacterSystemComposer.cs (línea 7)
Assets/Scripts/PoolSystem/PoolSystemComposer.cs (línea 15)
```

### Pool
```
Assets/Scripts/VFX/VFXFactory.cs (línea 74-120)
Assets/Scripts/PoolSystem/PoolSystemComposer.cs
```

---

## ✅ **VALIDACIÓN FINAL**
- ✅ Cada patrón tiene ubicación clara
- ✅ Cada archivo tiene línea específica
- ✅ Cada patrón tiene explicación de 3 preguntas (Qué/Para qué/Dónde)
- ✅ Total: 7 patrones en 3 minutos (25 segundos promedio por patrón)
- ✅ Intro/Outro: 40 segundos total

**¡Listo para grabar! 🎥**
