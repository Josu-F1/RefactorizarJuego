# 🏗️ PLAN DE TRABAJO - COMPLETAR CLEAN ARCHITECTURE

**Fecha:** Diciembre 2, 2025  
**Objetivo:** Completar la refactorización del 60% de código legacy restante  
**Complejidad:** Media-Alta  
**Tiempo Estimado:** 3-4 semanas

---

## 📋 TAREAS PENDIENTES POR PRIORIDAD

### **FASE 1: INFRAESTRUCTURA CRÍTICA (Semana 1)**

#### **1.1 Implementar Dependency Injection Container** ⭐ CRÍTICO
**Ubicación:** `Assets/Scripts/CleanArchitecture/Infrastructure/DependencyInjection/`  
**Tiempo:** 2-3 días

**Por qué es crítico:**
```csharp
// ACTUALMENTE (Manual):
var healthRepository = new HealthComponentRepository();
var healthNotifier = new HealthUnityNotifier();
var healthService = new HealthService(healthRepository, healthNotifier);
// ❌ Acoplamiento manual, no escalable

// DESPUÉS (Con DI Container):
var healthService = container.Resolve<IHealthService>();
// ✅ Automático, escalable, testeable
```

**Qué implementar:**

a) **SimpleServiceLocator.cs** (Patrón Service Locator)
```csharp
public class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services = new();
    
    public static void Register<T>(object implementation)
    {
        _services[typeof(T)] = implementation;
    }
    
    public static T Resolve<T>() where T : class
    {
        if (_services.TryGetValue(typeof(T), out var service))
            return service as T;
        throw new Exception($"Service {typeof(T).Name} not registered");
    }
}
```

b) **GameComposer.cs** (Composición Root)
```csharp
public class GameComposer : MonoBehaviourSingleton<GameComposer>
{
    private void Start()
    {
        // Register Domain
        
        // Register Repositories
        ServiceLocator.Register<IHealthRepository>(
            new HealthComponentRepository());
        ServiceLocator.Register<IScoreRepository>(
            new ScoreSystemRepository());
        
        // Register Services
        ServiceLocator.Register<IHealthService>(
            new HealthService(
                ServiceLocator.Resolve<IHealthRepository>(),
                ServiceLocator.Resolve<IHealthNotifier>()));
        
        ServiceLocator.Register<IScoreService>(
            new ScoreService(
                ServiceLocator.Resolve<IScoreRepository>(), 100));
    }
}
```

**Beneficio:** 
- ✅ Inyección automática
- ✅ Fácil testing (mock services)
- ✅ Configuración centralizada
- ✅ Sin acoplamiento directo

---

#### **1.2 Crear Interfaces Repository Base** ⭐ CRÍTICO
**Ubicación:** `Assets/Scripts/CleanArchitecture/Domain/Common/`  
**Tiempo:** 1 día

**Interfaz base:**
```csharp
// Domain/Common/IRepository.cs
public interface IRepository<T> where T : class
{
    T Load(string id);
    void Save(T aggregate);
    void Delete(string id);
    IEnumerable<T> GetAll();
}

// Domain/Common/IUnitOfWork.cs
public interface IUnitOfWork
{
    IRepository<HealthAggregate> HealthRepository { get; }
    IRepository<Score> ScoreRepository { get; }
    void Commit();
    void Rollback();
}
```

**Beneficio:**
- ✅ Consistencia en todas las repositories
- ✅ Operaciones CRUD estandarizadas
- ✅ Transacciones con Unit of Work

---

#### **1.3 Crear Excepciones Personalizadas** ⭐ CRÍTICO
**Ubicación:** `Assets/Scripts/CleanArchitecture/Application/Common/Exceptions/`  
**Tiempo:** 1 día

**Excepciones necesarias:**
```csharp
// ApplicationException.cs
public class ApplicationException : Exception { }

// EntityNotFoundException.cs
public class EntityNotFoundException : ApplicationException { }

// ValidationException.cs
public class ValidationException : ApplicationException { }

// DomainException.cs
public class DomainException : ApplicationException { }

// BusinessRuleException.cs
public class BusinessRuleException : ApplicationException { }
```

**Ejemplo de uso:**
```csharp
public class HealthService
{
    public void DamageEntity(string entityId, float damage)
    {
        var health = repository.Load(entityId);
        if (health == null)
            throw new EntityNotFoundException($"Health {entityId} not found");
        
        if (damage < 0)
            throw new ValidationException("Damage cannot be negative");
        
        health.ApplyDamage(damage);
    }
}
```

---

### **FASE 2: REFACTORIZAR SISTEMAS CORE (Semana 2)**

#### **2.1 Block System Refactorización**
**Ubicación:** `Assets/Scripts/CleanArchitecture/*/Block/`  
**Tiempo:** 2-3 días

**Estructura a implementar:**
```
Domain/Block/
  ├─ BlockAggregate.cs
  │  └─ Propiedades: Position, Type, State, Health
  │  └─ Métodos: TakeDamage(), Destroy(), SetState()
  │  └─ Eventos: OnDestroyed, OnDamaged, OnStateChanged
  │
  ├─ BlockType.cs (Enum)
  │  └─ Normal, Destructible, Ice, Metal, Explosive
  │
  ├─ BlockState.cs (Value Object)
  │  └─ Intact, Cracked, Destroyed
  │
  └─ IBlockRepository.cs (Interface)
     └─ Load(id), Save(aggregate), GetAll()

Application/Block/
  ├─ BlockService.cs (Caso de uso)
  │  └─ CreateBlock()
  │  └─ DestroyBlock()
  │  └─ DamageBlock()
  │
  └─ BlockDTO.cs (Data Transfer Object)
     └─ BlockId, Position, Type, Health

Infrastructure/Block/
  ├─ BlockRepository.cs (Persistencia)
  │  └─ Load/Save/Delete
  │
  ├─ BlockFactory.cs (Creación)
  │  └─ CreateBlockByType()
  │
  └─ BlockUnityExecutor.cs (Detalles técnicos)
     └─ Render, Physics, VFX

Presentation/Block/
  └─ BlockController.cs (MonoBehaviour)
     └─ Conecta input → BlockService
```

**Código de ejemplo:**

Domain Layer:
```csharp
public class BlockAggregate
{
    public string Id { get; private set; }
    public Vector3 Position { get; private set; }
    public BlockType Type { get; private set; }
    public float Health { get; private set; }
    public BlockState State { get; private set; }
    
    public event Action<BlockSnapshot> OnStateChanged;
    public event Action OnDestroyed;
    
    public BlockAggregate(string id, Vector3 position, BlockType type)
    {
        Id = id;
        Position = position;
        Type = type;
        Health = GetMaxHealth(type);
        State = BlockState.Intact;
    }
    
    public void TakeDamage(float damage)
    {
        Health -= damage;
        
        if (Health <= 0)
        {
            State = BlockState.Destroyed;
            OnDestroyed?.Invoke();
        }
        else if (Health < 50)
        {
            State = BlockState.Cracked;
        }
        
        OnStateChanged?.Invoke(ToSnapshot());
    }
    
    public BlockSnapshot ToSnapshot() => new(Id, Position, Type, Health, State);
}
```

Application Layer:
```csharp
public class BlockService
{
    private readonly IBlockRepository repository;
    
    public BlockService(IBlockRepository repository)
    {
        this.repository = repository;
    }
    
    public BlockDTO CreateBlock(Vector3 position, BlockType type)
    {
        var id = Guid.NewGuid().ToString();
        var block = new BlockAggregate(id, position, type);
        repository.Save(block);
        return MapToDTO(block);
    }
    
    public void DamageBlock(string blockId, float damage)
    {
        var block = repository.Load(blockId);
        if (block == null) throw new EntityNotFoundException($"Block {blockId}");
        
        block.TakeDamage(damage);
        repository.Save(block);
    }
}
```

---

#### **2.2 Bomb System Refactorización**
**Ubicación:** `Assets/Scripts/CleanArchitecture/*/Bomb/`  
**Tiempo:** 2-3 días

**Similar a Block System:**
```
Domain/Bomb/
  ├─ BombAggregate.cs
  │  └─ Estado: Idle, Activated, Exploded
  │  └─ Métodos: Activate(), Explode(), Tick()
  │  └─ Eventos: OnExploded, OnTick
  │
  └─ IBombRepository.cs

Application/Bomb/
  └─ BombService.cs (Casos de uso)
     └─ CreateBomb(), DetonateBomb(), TickBombs()

Infrastructure/Bomb/
  ├─ BombRepository.cs
  ├─ BombFactory.cs
  └─ BombUnityExecutor.cs

Presentation/Bomb/
  └─ BombController.cs
```

---

#### **2.3 Audio System Refactorización**
**Ubicación:** `Assets/Scripts/CleanArchitecture/*/Audio/`  
**Tiempo:** 2-3 días

**Estructura:**
```
Domain/Audio/
  ├─ AudioClipAggregate.cs
  │  └─ Propiedades: Id, Clip, Volume, Pitch
  │
  └─ IAudioRepository.cs

Application/Audio/
  ├─ AudioService.cs
  │  └─ PlaySound()
  │  └─ StopSound()
  │  └─ SetVolume()
  │
  └─ AudioPlayStrategy.cs (Strategy Pattern)
     ├─ ImmediatePlayStrategy
     ├─ FadePlayStrategy
     └─ LoopPlayStrategy

Infrastructure/Audio/
  ├─ AudioRepository.cs
  ├─ UnityAudioExecutor.cs
  └─ AudioSourcePool.cs (Pool)

Presentation/Audio/
  └─ AudioManagerAdapter.cs
```

---

### **FASE 3: REFACTORIZAR SISTEMAS UI/GAME (Semana 2-3)**

#### **3.1 Game Manager Refactorización**
**Ubicación:** `Assets/Scripts/CleanArchitecture/Application/Game/`  
**Tiempo:** 2 días

**Qué hacer:**
```
Domain/Game/
  └─ GameState (Enum)
     ├─ MainMenu
     ├─ Playing
     ├─ Paused
     ├─ GameOver
     └─ LevelComplete

Application/Game/
  └─ GameService.cs (Orquesta todo)
     ├─ StartGame()
     ├─ PauseGame()
     ├─ ResumeGame()
     ├─ EndGame()
     └─ LoadLevel(levelId)

Infrastructure/Game/
  └─ GameStateRepository.cs (Persistencia)

Presentation/Game/
  └─ GameManagerAdapter.cs (Root Composer)
```

---

#### **3.2 Menu System Refactorización**
**Ubicación:** `Assets/Scripts/CleanArchitecture/*/Menu/`  
**Tiempo:** 2-3 días

**Estructura:**
```
Domain/Menu/
  └─ MenuState (Enum)
     ├─ MainMenu
     ├─ Pause
     ├─ Settings
     ├─ Credits

Application/Menu/
  └─ MenuService.cs
     ├─ OpenMenu()
     ├─ CloseMenu()
     └─ SelectOption()

Presentation/Menu/
  ├─ MenuController.cs
  ├─ MainMenuAdapter.cs
  ├─ PauseMenuAdapter.cs
  └─ SettingsMenuAdapter.cs
```

---

#### **3.3 UI System Refactorización**
**Ubicación:** `Assets/Scripts/CleanArchitecture/*/UI/`  
**Tiempo:** 2 días

**Estructura:**
```
Application/UI/
  └─ UIService.cs
     ├─ UpdateHealthBar()
     ├─ UpdateScoreDisplay()
     ├─ ShowNotification()

Presentation/UI/
  ├─ HealthBarController.cs
  ├─ ScoreDisplayController.cs
  └─ NotificationController.cs
```

---

### **FASE 4: TESTING & DOCUMENTACIÓN (Semana 3-4)**

#### **4.1 Agregar Unit Tests**
**Ubicación:** `Assets/Tests/EditMode/CleanArchitecture/`  
**Tiempo:** 3-4 días

**Tests para implementar:**

```csharp
// Tests/EditMode/Domain/Health/HealthAggregateTests.cs
public class HealthAggregateTests
{
    [Test]
    public void ApplyDamage_ReducesHealth()
    {
        var health = new HealthAggregate(100);
        health.ApplyDamage(25);
        Assert.AreEqual(75, health.Current);
    }
    
    [Test]
    public void ApplyDamage_WhenDead_DoesNothing()
    {
        var health = new HealthAggregate(100);
        health.ApplyDamage(100);
        health.ApplyDamage(50);
        Assert.AreEqual(0, health.Current);
    }
    
    [Test]
    public void OnDeath_EventFired()
    {
        var health = new HealthAggregate(100);
        var called = false;
        health.OnDeath += () => called = true;
        
        health.ApplyDamage(100);
        Assert.IsTrue(called);
    }
}

// Tests/EditMode/Application/Health/HealthServiceTests.cs
public class HealthServiceTests
{
    private Mock<IHealthRepository> repositoryMock;
    private HealthService healthService;
    
    [SetUp]
    public void Setup()
    {
        repositoryMock = new Mock<IHealthRepository>();
        healthService = new HealthService(repositoryMock.Object);
    }
    
    [Test]
    public void DamageEntity_CallsSaveRepository()
    {
        var health = new HealthAggregate("entity1", 100);
        repositoryMock.Setup(r => r.Load("entity1")).Returns(health);
        
        healthService.DamageEntity("entity1", 25);
        
        repositoryMock.Verify(r => r.Save(It.IsAny<HealthAggregate>()), Times.Once);
    }
}
```

**Tests a implementar:**
- ✅ 10-15 tests para Domain Layer
- ✅ 10-15 tests para Application Layer
- ✅ 5-10 tests para Infrastructure (Integration)

---

#### **4.2 Actualizar Documentación**
**Archivos a actualizar:**

1. **README.md** - Actualizar con estado real
2. **ARQUITECTURA.md** - Crear documento de arquitectura completa
3. **TESTING.md** - Guía de testing
4. **API_DOCUMENTATION.md** - Documentación de APIs públicas

---

### **FASE 5: OPTIMIZACIÓN & FINALIZACIÓN (Semana 4)**

#### **5.1 Implementar Event Bus Centralizado (Opcional pero Recomendado)**
**Ubicación:** `Assets/Scripts/CleanArchitecture/Infrastructure/EventBus/`  
**Tiempo:** 1-2 días

```csharp
// Infrastructure/EventBus/IEventBus.cs
public interface IEventBus
{
    void Subscribe<T>(Action<T> handler) where T : IDomainEvent;
    void Publish<T>(T domainEvent) where T : IDomainEvent;
    void Unsubscribe<T>(Action<T> handler) where T : IDomainEvent;
}

// Infrastructure/EventBus/SimpleEventBus.cs
public class SimpleEventBus : IEventBus
{
    private readonly Dictionary<Type, List<Delegate>> subscribers = new();
    
    public void Subscribe<T>(Action<T> handler) where T : IDomainEvent
    {
        var type = typeof(T);
        if (!subscribers.ContainsKey(type))
            subscribers[type] = new List<Delegate>();
        subscribers[type].Add(handler);
    }
    
    public void Publish<T>(T domainEvent) where T : IDomainEvent
    {
        var type = typeof(T);
        if (subscribers.TryGetValue(type, out var handlers))
        {
            foreach (var handler in handlers)
                ((Action<T>)handler)?.Invoke(domainEvent);
        }
    }
}

// Domain/Common/IDomainEvent.cs
public interface IDomainEvent
{
    Guid AggregateId { get; }
    DateTime OccurredAt { get; }
}

// Domain/Health/Events/HealthDamagedEvent.cs
public class HealthDamagedEvent : IDomainEvent
{
    public Guid AggregateId { get; }
    public DateTime OccurredAt { get; }
    public float DamageAmount { get; }
    
    public HealthDamagedEvent(Guid aggregateId, float damageAmount)
    {
        AggregateId = aggregateId;
        OccurredAt = DateTime.Now;
        DamageAmount = damageAmount;
    }
}
```

---

#### **5.2 Code Review & Refining**
**Actividades:**
- ✅ Revisar consistencia de naming
- ✅ Eliminar duplicación
- ✅ Optimizar performance
- ✅ Documentar patrones

---

## 📊 ROADMAP VISUAL

```
SEMANA 1: INFRAESTRUCTURA
├─ DI Container          ✓
├─ IRepository base      ✓
├─ Excepciones          ✓
└─ Error handling       ✓

SEMANA 2: SISTEMAS CORE
├─ Block System         ✓
├─ Bomb System          ✓
├─ Audio System         ✓
└─ Game Manager         ✓

SEMANA 3: UI & MENUS
├─ Menu System          ✓
├─ UI System            ✓
└─ Unit Tests (inicio)  ✓

SEMANA 4: FINALIZACIÓN
├─ Unit Tests (fin)     ✓
├─ Event Bus (Opt)      ✓
├─ Documentación        ✓
└─ Code Review          ✓
```

---

## 🎯 CHECKLIST DE TAREAS

### **FASE 1: INFRAESTRUCTURA**
- [ ] Crear ServiceLocator.cs
- [ ] Crear GameComposer.cs
- [ ] Crear IRepository<T> base
- [ ] Crear IUnitOfWork interface
- [ ] Crear custom exceptions
- [ ] Crear exception handlers

### **FASE 2: BLOCK SYSTEM**
- [ ] BlockAggregate.cs (Domain)
- [ ] BlockType.cs (Enum)
- [ ] BlockState.cs (Value Object)
- [ ] IBlockRepository.cs
- [ ] BlockService.cs (Application)
- [ ] BlockRepository.cs (Infrastructure)
- [ ] BlockFactory.cs (Infrastructure)
- [ ] BlockUnityExecutor.cs (Infrastructure)
- [ ] BlockController.cs (Presentation)

### **FASE 2: BOMB SYSTEM**
- [ ] BombAggregate.cs
- [ ] BombType.cs
- [ ] IBombRepository.cs
- [ ] BombService.cs
- [ ] BombRepository.cs
- [ ] BombFactory.cs
- [ ] BombUnityExecutor.cs
- [ ] BombController.cs

### **FASE 2: AUDIO SYSTEM**
- [ ] AudioClipAggregate.cs
- [ ] IAudioRepository.cs
- [ ] AudioService.cs
- [ ] AudioPlayStrategy.cs (+ implementations)
- [ ] AudioRepository.cs
- [ ] UnityAudioExecutor.cs
- [ ] AudioSourcePool.cs
- [ ] AudioManagerAdapter.cs

### **FASE 3: GAME MANAGER**
- [ ] GameState.cs (Enum)
- [ ] GameService.cs
- [ ] GameStateRepository.cs
- [ ] GameManagerAdapter.cs

### **FASE 3: MENU SYSTEM**
- [ ] MenuState.cs
- [ ] MenuService.cs
- [ ] MainMenuAdapter.cs
- [ ] PauseMenuAdapter.cs
- [ ] SettingsMenuAdapter.cs

### **FASE 3: UI SYSTEM**
- [ ] UIService.cs
- [ ] HealthBarController.cs
- [ ] ScoreDisplayController.cs
- [ ] NotificationController.cs

### **FASE 4: TESTING**
- [ ] Tests Domain (Health)
- [ ] Tests Domain (Score)
- [ ] Tests Domain (Block)
- [ ] Tests Domain (Bomb)
- [ ] Tests Application (HealthService)
- [ ] Tests Application (BlockService)
- [ ] Tests Application (BombService)
- [ ] Tests Infrastructure (Repositories)
- [ ] Tests Infrastructure (Factories)

### **FASE 4: DOCUMENTACIÓN**
- [ ] Actualizar README.md
- [ ] Crear ARQUITECTURA.md
- [ ] Crear TESTING.md
- [ ] Crear API_DOCUMENTATION.md
- [ ] Actualizar comentarios XML

### **FASE 5: OPCIONALES**
- [ ] Implementar Event Bus
- [ ] Code review completo
- [ ] Performance optimization
- [ ] Agile documentation

---

## 📌 PATRONES A USAR

### **Ya Implementados (Reutilizar):**
1. ✅ **Aggregate Pattern** - HealthAggregate, Score
2. ✅ **Repository Pattern** - IHealthRepository, IScoreRepository
3. ✅ **Service Layer** - HealthService, ScoreService
4. ✅ **Adapter Pattern** - HealthServiceAdapter, PlayerControllerAdapter
5. ✅ **DTO Pattern** - HealthSnapshot, ScoreSnapshot

### **A Implementar:**
1. **Factory Pattern** - BlockFactory, BombFactory
2. **Strategy Pattern** - AudioPlayStrategy, DamageStrategy
3. **Observer Pattern** - EventBus, DomainEvents
4. **Unit of Work** - IUnitOfWork interface
5. **Command Pattern** - Para acciones de usuario (Undo/Redo)

---

## 🔧 HERRAMIENTAS A UTILIZAR

- **Testing:** Unity Test Framework (UTF)
- **Mocking:** Moq library
- **DI:** ServiceLocator (manual) o Zenject (recomendado para futuro)
- **Logging:** Debug.Log + custom logger
- **Documentation:** XML comments + Markdown

---

## 📝 NOTAS IMPORTANTES

### **Mantener Consistencia:**
```csharp
// Todas las clases de dominio deben:
// 1. Ser POCOs (Plain Old C# Objects)
// 2. No depender de Unity
// 3. Exponer eventos para notificar cambios
// 4. Tener métodos de comportamiento (no solo properties)

// Todas las aplicaciones deben:
// 1. Orquestar dominio + infraestructura
// 2. Ser independientes de UI
// 3. Exponer DTOs, no agregados

// Todas las infraestructuras deben:
// 1. Implementar interfaces de dominio
// 2. Contener detalles técnicos (Unity, Persistencia)
// 3. Ser intercambiables

// Todos los adaptadores deben:
// 1. Ser MonoBehaviours
// 2. Inyectar servicios
// 3. Conectar entrada → aplicación
```

### **Evitar Antipatrones:**
```csharp
// ❌ NO HACER - Acoplamiento directo
public class BlockController : MonoBehaviour
{
    private BlockAggregate block = new();
}

// ✅ HACER - Inyección de dependencias
public class BlockController : MonoBehaviour
{
    [SerializeField] private BlockService service;
}

// ❌ NO HACER - Lógica en presentación
public class BlockController : MonoBehaviour
{
    public void TakeDamage()
    {
        health -= damage;  // ❌ Lógica aquí
    }
}

// ✅ HACER - Delegar al servicio
public class BlockController : MonoBehaviour
{
    public void OnTakeDamage(float damage)
    {
        blockService.DamageBlock(blockId, damage);  // ✅ Lógica en servicio
    }
}
```

---

## ⏱️ ESTIMACIÓN FINAL

| Fase | Tareas | Tiempo | Prioridad |
|------|--------|--------|-----------|
| 1 - Infraestructura | 6 | 3 días | 🔴 CRÍTICO |
| 2 - Block System | 9 | 2 días | 🔴 CRÍTICO |
| 2 - Bomb System | 8 | 2 días | 🟡 IMPORTANTE |
| 2 - Audio System | 8 | 2 días | 🟡 IMPORTANTE |
| 3 - Game Manager | 4 | 1 día | 🟡 IMPORTANTE |
| 3 - Menu System | 5 | 2 días | 🟡 IMPORTANTE |
| 3 - UI System | 4 | 1 día | 🟡 IMPORTANTE |
| 4 - Testing | 20 | 3 días | 🟢 RECOMENDADO |
| 4 - Documentación | 4 | 1 día | 🟢 RECOMENDADO |
| 5 - Event Bus (Opt) | 8 | 2 días | 🔵 OPCIONAL |
| **TOTAL** | **76** | **21 días** | |

**Tiempo Realista con revisión:** 3-4 semanas

---

## 🎓 CONCLUSIÓN

Para tener una **Clean Architecture COMPLETA**, faltan:

### **Crítico (Hacer PRIMERO):**
1. ✅ Dependency Injection Container
2. ✅ IRepository base interface
3. ✅ Custom exceptions
4. ✅ Block System refactorización

### **Importante (Hacer DESPUÉS):**
5. ✅ Bomb System refactorización
6. ✅ Audio System refactorización
7. ✅ Game Manager refactorización
8. ✅ Menu System refactorización

### **Recomendado (Hacer FINALMENTE):**
9. ✅ Unit Tests completos
10. ✅ Documentación actualizada
11. ✅ Event Bus (opcional pero buena idea)
12. ✅ Code review final

**Una vez completado esto, tendrás una Clean Architecture profesional y escalable.**

