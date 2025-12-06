# 🎯 PLAN PARA ALCANZAR 100% CLEAN ARCHITECTURE

**Fecha:** Diciembre 5, 2025  
**Estado Actual:** 50% Clean Architecture  
**Objetivo:** 100% Clean Architecture  
**Tiempo Estimado:** 6-8 horas de trabajo continuo

---

## 📊 ESTADO ACTUAL

### ✅ **YA IMPLEMENTADO (50%)**
- ServiceLocator + DI Container
- GameStateService, ScoreService, AudioService, PoolService, PlayerService
- GameBootstrapper (inicialización)
- Adaptadores legacy (EnemyScoreConnector, PlayerDeathConnector, etc.)
- Interfaces limpias en Application Layer

### ❌ **PENDIENTE (50% - 142 archivos)**
- 10+ Composers con `MonoBehaviourSingleton`
- 28 usos de `FindObjectOfType`
- UI sin Presenters
- Pickups acoplados a `Player.Instance`
- Managers legacy sin migrar

---

## 🚀 PLAN DE MIGRACIÓN (10 FASES)

---

## **FASE 1: ELIMINAR MONOBEHAVIOURSINGLETON DE COMPOSERS** ⏱️ 30min

### Objetivo:
Convertir todos los Composers a servicios registrados en ServiceLocator

### Archivos a modificar:
1. `GameManagerComposer` → `IGameManagementService`
2. `PoolSystemComposer` → Ya existe `IPoolService` ✅
3. `AudioSystemComposer` → Ya existe `IAudioService` ✅
4. `ShootingSystemComposer` → `IShootingService`
5. `LightSystemComposer` → `ILightService`
6. `BlockSystemComposer` → `IBlockService`
7. `MenuSystemComposer` → `IMenuService`

### Estrategia:
```csharp
// ANTES
public class PoolSystemComposer : MonoBehaviourSingleton<PoolSystemComposer>
{
    public static PoolSystemComposer Instance { get; }
}

// DESPUÉS
public class PoolSystemInitializer : MonoBehaviour
{
    void Awake() {
        var service = new PoolServiceImpl(config);
        ServiceLocator.Instance.Register<IPoolService>(service);
    }
}
```

---

## **FASE 2: MIGRAR POOLSYSTEMCOMPOSER A SERVICIO** ⏱️ 45min

### Pasos:
1. ✅ Crear `IPoolService` completo (YA EXISTE)
2. ✅ Implementar `PoolService` (YA EXISTE)
3. Crear `PoolSystemInitializer` para configuración
4. Actualizar referencias de `PoolSystemComposer.Instance` → `ServiceLocator.Get<IPoolService>()`
5. Marcar `PoolSystemComposer` como `[Obsolete]`

### Archivos impactados:
- 20+ archivos que usan `PoolSystemComposer.Instance`
- `BombSpawnerComposer`, `PooledBombFactory`, `ShootingSystemComposer`

---

## **FASE 3: MIGRAR AUDIOSYSTEMCOMPOSER A SERVICIO** ⏱️ 30min

### Pasos:
1. ✅ `IAudioService` ya existe
2. ✅ `AudioService` ya existe
3. ✅ `LegacySoundAdapter` ya existe
4. Actualizar referencias de `AudioSystemComposer.Instance`
5. Marcar como `[Obsolete]`

### Archivos impactados:
- `AudioPlayer`, `AudioServiceAdapter`
- 5+ archivos usando `AudioSystemComposer.Instance`

---

## **FASE 4: MIGRAR SHOOTINGSYSTEMCOMPOSER A SERVICIO** ⏱️ 60min

### Pasos:
1. Crear `IShootingService` interface
2. Implementar `ShootingService` 
3. Crear `ShootingSystemInitializer`
4. Actualizar 15+ referencias
5. Integrar con PoolService

### Archivos impactados:
- `ShootingControllers`, `WeaponStrategies`, `ShootingFactories`
- `AIShooter`, scripts de jugador

---

## **FASE 5: MIGRAR LIGHTSYSTEMCOMPOSER A SERVICIO** ⏱️ 30min

### Pasos:
1. Crear `ILightService` interface
2. Implementar `LightService`
3. Crear `LightSystemInitializer`
4. Actualizar referencias de `GlobalLight.Instance`
5. Adaptar `BlindAbility`

### Archivos impactados:
- `GlobalLightRepository`, `LightServiceAdapter`
- `BlindAbility`

---

## **FASE 6: REFACTORIZAR UI CON PRESENTERS** ⏱️ 90min

### Pasos:
1. Crear Presenters para UI existente:
   - `HealthBarPresenter`
   - `ScoreDisplayPresenter`
   - `BombStatsPresenter`
   - `GameOverPresenter`

2. Conectar Presenters con servicios vía ServiceLocator

3. Eliminar referencias directas a managers

### Archivos impactados:
- `HealthBar.cs` → `HealthBarPresenter`
- `PlayerHealthBar.cs` → Usar `IPlayerService`
- `BombStatsAdapter.cs` → `BombStatsPresenter`
- `ScoreDisplay.cs` → Ya existe `ScoreUIPresenter` ✅

---

## **FASE 7: MIGRAR PICKUPS A USAR SERVICIOS** ⏱️ 45min

### Archivos a refactorizar (7 archivos):
1. `Pickup.cs` (base)
2. `HealthPickup.cs`
3. `SpeedPickup.cs`
4. `DamagePickup.cs`
5. `BombLimitPickup.cs`
6. `BombLengthPickup.cs`

### Estrategia:
```csharp
// ANTES
void OnTriggerEnter(Collider other) {
    if (other.GetComponent<Player>()) {
        Player.Instance.Health += amount;
    }
}

// DESPUÉS
void OnTriggerEnter(Collider other) {
    var playerService = ServiceLocator.Instance.Get<IPlayerService>();
    if (playerService.IsPlayer(other.gameObject)) {
        var healthService = ServiceLocator.Instance.Get<IHealthService>();
        healthService.AddHealth(amount);
    }
}
```

---

## **FASE 8: ELIMINAR FINDOBJECTOFTYPE RESTANTES** ⏱️ 45min

### Ubicaciones (28 usos):
1. `LegacySoundAdapter` → Ya usa ServiceLocator ✅
2. `LegacyPoolAdapter` → Ya usa ServiceLocator ✅
3. `PasswordLoginComponent` → Usar DI
4. `ShootingControllers` → Inyectar servicios
5. Otros adapters → Convertir a DI

### Estrategia:
- Reemplazar por inyección via constructor o `ServiceLocator.Get<>()`
- Usar patrón `[SerializeField]` cuando sea necesario en Unity
- Implementar `[RequireComponent]` cuando aplique

---

## **FASE 9: ELIMINAR GAMEMANAGER LEGACY** ⏱️ 30min

### Pasos:
1. Verificar que `GameManagerAdapter` sincroniza correctamente
2. Marcar `GameManager` como `[Obsolete]` con error=true
3. Eliminar lógica redundante
4. Mantener solo como fachada vacía temporalmente

### Archivos impactados:
- `GameManager.cs` → Solo fachada
- Todas las referencias ya usan `GameStateService` vía adaptadores

---

## **FASE 10: VERIFICACIÓN FINAL** ⏱️ 60min

### Checklist:
- [ ] 0 usos de `MonoBehaviourSingleton` (excepto temporales obsoletos)
- [ ] 0 usos de `FindObjectOfType` (excepto inicializadores)
- [ ] Todos los servicios registrados en `GameBootstrapper`
- [ ] Todas las interfaces en `Application/Services/`
- [ ] Todas las implementaciones en `Infrastructure/Services/`
- [ ] Todos los adapters en `Presentation/Adapters/`
- [ ] UI usando Presenters
- [ ] Testing manual completo
- [ ] Generar reporte final

---

## 📋 ORDEN DE EJECUCIÓN

### **BLOQUE 1: SERVICIOS CORE (2 horas)**
1. ✅ Fase 1: Eliminar MonoBehaviourSingleton
2. ✅ Fase 2: Migrar PoolSystemComposer
3. ✅ Fase 3: Migrar AudioSystemComposer

### **BLOQUE 2: SERVICIOS ESPECÍFICOS (2 horas)**
4. Fase 4: Migrar ShootingSystemComposer
5. Fase 5: Migrar LightSystemComposer

### **BLOQUE 3: PRESENTACIÓN (2 horas)**
6. Fase 6: Refactorizar UI
7. Fase 7: Migrar Pickups

### **BLOQUE 4: LIMPIEZA (2 horas)**
8. Fase 8: Eliminar FindObjectOfType
9. Fase 9: Eliminar GameManager legacy
10. Fase 10: Verificación final

---

## 🎯 MÉTRICAS DE ÉXITO

### Antes (Actual):
```
Clean Architecture:     50% (124 archivos)
Legacy:                 50% (125 archivos)
Total:                  249 archivos
```

### Después (Objetivo):
```
Clean Architecture:     95%+ (236+ archivos)
Legacy obsoleto:        5%  (13 archivos - marcados [Obsolete])
Total:                  249 archivos
```

### Archivos que quedarán como `[Obsolete]`:
- `MonoBehaviourSingleton.cs` (por si algo lo necesita temporalmente)
- `GameManager.cs` (fachada vacía)
- `PoolManager.cs` (fachada vacía)
- `AudioManager.cs` (fachada vacía)
- Otros singletons legacy (solo como fallback)

---

## ⚠️ PRINCIPIOS A MANTENER

1. **NO ROMPER EL JUEGO** - Cada fase debe compilar y funcionar
2. **MIGRACIÓN GRADUAL** - Mantener adaptadores hasta el final
3. **TESTING CONTINUO** - Probar después de cada fase
4. **DOCUMENTAR CAMBIOS** - Comentar código obsoleto claramente
5. **MANTENER COMPATIBILIDAD** - Los adaptadores garantizan funcionalidad

---

## 🚀 EMPEZAMOS AHORA

**ESTADO:** ✅ PLAN COMPLETO  
**SIGUIENTE:** Fase 1 - Eliminar MonoBehaviourSingleton de Composers

¿Empezamos con la Fase 1?
