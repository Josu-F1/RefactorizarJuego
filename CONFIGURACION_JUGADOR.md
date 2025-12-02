# Configuración de Posición Inicial del Jugador

Este documento explica cómo resolver el problema donde el jugador aparece al final del nivel en lugar del inicio y no puede moverse.

## Problema Identificado

El script `PositionSaver` estaba guardando la última posición del jugador y cargándola al inicio del juego, causando que el personaje apareciera donde terminó la partida anterior.

## Soluciones Implementadas

### 1. PositionSaver Mejorado
- **Ubicación**: `Assets/Scripts/Utils/PositionSaver.cs`
- **Nuevas opciones**:
  - `useInitialPosition`: Usar posición inicial en lugar de la guardada
  - `initialPosition`: Posición específica donde aparecer
  - `resetPositionOnStart`: Limpiar posición guardada al iniciar

### 2. LevelInitializer 
- **Ubicación**: `Assets/Scripts/Managers/LevelInitializer.cs`
- **Función**: Inicializa correctamente el nivel
- **Configuración**:
  - `resetTimeScale`: Asegura que Time.timeScale = 1
  - `resetPlayerPosition`: Resetea posición del jugador
  - `playerSpawnPosition`: Posición donde aparecer

### 3. PlayerSpawn
- **Ubicación**: `Assets/Scripts/Managers/PlayerSpawn.cs`
- **Función**: Manejo específico del spawn del jugador
- **Configuración**:
  - `spawnPosition`: Posición de aparición
  - `useCurrentPositionAsSpawn`: Usar posición actual del objeto
  - `clearSavedPosition`: Limpiar posición guardada
  - `playerPositionSaverId`: ID del PositionSaver

## Cómo Configurar

### Opción 1: Usar PositionSaver (Recomendado)
1. En el objeto Player, encuentra el componente `PositionSaver`
2. Marca `useInitialPosition` como `true`
3. Marca `resetPositionOnStart` como `true`
4. Si quieres una posición específica, establece `initialPosition`

### Opción 2: Usar PlayerSpawn
1. Crea un GameObject vacío en la escena
2. Añade el script `PlayerSpawn`
3. Posiciona el objeto donde quieres que aparezca el jugador
4. Marca `useCurrentPositionAsSpawn` como `true`
5. Marca `clearSavedPosition` como `true`

### Opción 3: Usar LevelInitializer
1. Crea un GameObject vacío llamado "LevelManager"
2. Añade el script `LevelInitializer`
3. Marca `resetPlayerPosition` como `true`
4. Establece `playerSpawnPosition` con las coordenadas deseadas

## Corrección de Errores Adicionales

- **Movimiento**: Se corrigió un punto y coma innecesario en `MoveOnInput.cs`
- **TimeScale**: Se añadió inicialización de `Time.timeScale = 1f` en `GameManager.cs`

## Verificación

Para verificar que todo funciona:
1. Ejecuta el juego
2. El personaje debería aparecer en la posición inicial configurada
3. El personaje debería poder moverse con WASD
4. El tiempo del juego debería estar corriendo (Time.timeScale = 1)

## Notas Importantes

- El `LevelInitializer` tiene `executionOrder = -100` para ejecutarse primero
- El `PlayerSpawn` tiene `executionOrder = -50` para ejecutarse antes que otros scripts
- Los scripts mantienen compatibilidad con el sistema existente