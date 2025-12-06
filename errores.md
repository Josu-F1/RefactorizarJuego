EditorSecuritySettings: Configuración aplicada para evitar conexiones inseguras.
UnityEngine.Debug:Log (object)
EditorSecuritySettings:ConfigureEditorSettings () (at Assets/Scripts/Editor/EditorSecuritySettings.cs:24)
EditorSecuritySettings:.cctor () (at Assets/Scripts/Editor/EditorSecuritySettings.cs:13)
UnityEditor.EditorAssemblies:ProcessInitializeOnLoadAttributes (System.Type[])

SecureConnectionEnforcer: Conexiones HTTP inseguras bloqueadas (comportamiento por defecto en Unity 2022.3+)
UnityEngine.Debug:Log (object)
SecureConnectionEnforcer:DisableInsecureConnections () (at Assets/Scripts/SecureConnectionEnforcer.cs:15)

Servicios de Unity configurados para estar deshabilitados.
UnityEngine.Debug:Log (object)
DisableUnityServices:DisableRuntimeServices () (at Assets/Scripts/Editor/DisableUnityServices.cs:13)

[OBSOLETE] RegisterMenu is deprecated. Use MenuSystemComposer instead.
UnityEngine.Debug:LogWarning (object)
RegisterMenu:Start () (at Assets/Scripts/MenuComponents/RegisterMenu.cs:21)

[PasswordLoginComponent] ¡Bienvenido! Ingresa tus credenciales
UnityEngine.Debug:Log (object)
PasswordLoginComponent:ShowStatus (string,UnityEngine.Color) (at Assets/Scripts/UI/PasswordLoginComponent.cs:331)
PasswordLoginComponent:SetupUI () (at Assets/Scripts/UI/PasswordLoginComponent.cs:62)
PasswordLoginComponent:Start () (at Assets/Scripts/UI/PasswordLoginComponent.cs:31)

DataManagerComposer: System initialized
UnityEngine.Debug:Log (object)
DataManagerComposer:Initialize () (at Assets/Scripts/Managers/DataManagerComposer.cs:40)
DataManagerComposer:EnsureInitialized () (at Assets/Scripts/Managers/DataManagerComposer.cs:22)
DataManagerComposer:set_CurrentUsername (string) (at Assets/Scripts/Managers/DataManagerComposer.cs:68)
RegisterMenu:LoginWithUsername (string) (at Assets/Scripts/MenuComponents/RegisterMenu.cs:121)
RegisterMenu:OnLoginButton () (at Assets/Scripts/MenuComponents/RegisterMenu.cs:104)
UnityEngine.EventSystems.EventSystem:Update () (at ./Library/PackageCache/com.unity.ugui@1.0.0/Runtime/EventSystem/EventSystem.cs:530)

[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)

[PoolSystemComposer] No instance found in scene. Pool System will use legacy PoolManager if available.
UnityEngine.Debug:LogWarning (object)
PoolSystem.PoolSystemComposer:get_Instance () (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:49)
PoolSystem.PoolSystemComposer:ReturnToPool (PoolSystem.Interfaces.IPoolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:275)
PoolSystem.PoolSystemComposer/PoolManagerCompat:ReturnToPool (PoolObjectType,UnityEngine.GameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager:ReturnToPool (PoolObjectType,UnityEngine.GameObject) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolManager:AddToPool (PoolObjectType,int) (at Assets/Scripts/PoolSystem/PoolManager.cs:93)
PoolManager:Awake () (at Assets/Scripts/PoolSystem/PoolManager.cs:47)

StackOverflowException: The requested operation caused a stack overflow.
UnityEngine.Object.FindObjectOfType (System.Type type, System.Boolean includeInactive) (at <37cc348edc804f4cb176b63962c716e7>:0)
UnityEngine.Object.FindObjectOfType[T] () (at <37cc348edc804f4cb176b63962c716e7>:0)
CleanArchitecture.Presentation.Adapters.LegacyPoolAdapter.get_Instance () (at Assets/Scripts/CleanArchitecture/Presentation/Adapters/LegacyPoolAdapter.cs:124)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:99)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSys<message truncated>
[MapZonesManager] Usuario: MARLON, Nivel del jugador: 3
UnityEngine.Debug:Log (object)
MapZonesManager:Start () (at Assets/Scripts/Managers/MapZonesManager.cs:10)

[MapZonesManager] Encontrados 4 niveles para desbloquear
UnityEngine.Debug:Log (object)
MapZonesManager:Start () (at Assets/Scripts/Managers/MapZonesManager.cs:13)

[MapZonesManager] Desbloqueado nivel 1
UnityEngine.Debug:Log (object)
MapZonesManager:Start () (at Assets/Scripts/Managers/MapZonesManager.cs:21)

[MapZonesManager] Desbloqueado nivel 2
UnityEngine.Debug:Log (object)
MapZonesManager:Start () (at Assets/Scripts/Managers/MapZonesManager.cs:21)

[MapZonesManager] Desbloqueado nivel 3
UnityEngine.Debug:Log (object)
MapZonesManager:Start () (at Assets/Scripts/Managers/MapZonesManager.cs:21)

[MapZonesManager] Desbloqueado nivel 4
UnityEngine.Debug:Log (object)
MapZonesManager:Start () (at Assets/Scripts/Managers/MapZonesManager.cs:21)

[Player] OBSOLETO: Usando implementación legacy. Migrar a CharacterSystemComposer.
UnityEngine.Debug:LogWarning (object)
Player:Start () (at Assets/Scripts/Character/Player.cs:49)

NullReferenceException: Object reference not set to an instance of an object
Bomb.GetExplosion (UnityEngine.Vector3 position) (at Assets/Scripts/PoolObject/Bomb.cs:98)
Bomb.Explode () (at Assets/Scripts/PoolObject/Bomb.cs:58)
Bomb.Update () (at Assets/Scripts/PoolObject/Bomb.cs:45)

StackOverflowException: The requested operation caused a stack overflow.
UnityEngine.Object.FindObjectOfType (System.Type type, System.Boolean includeInactive) (at <37cc348edc804f4cb176b63962c716e7>:0)
UnityEngine.Object.FindObjectOfType[T] () (at <37cc348edc804f4cb176b63962c716e7>:0)
CleanArchitecture.Presentation.Adapters.LegacyPoolAdapter.get_Instance () (at Assets/Scripts/CleanArchitecture/Presentation/Adapters/LegacyPoolAdapter.cs:124)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:99)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSys<message truncated>
StackOverflowException: The requested operation caused a stack overflow.
UnityEngine.Object.FindObjectOfType (System.Type type, System.Boolean includeInactive) (at <37cc348edc804f4cb176b63962c716e7>:0)
UnityEngine.Object.FindObjectOfType[T] () (at <37cc348edc804f4cb176b63962c716e7>:0)
CleanArchitecture.Presentation.Adapters.LegacyPoolAdapter.get_Instance () (at Assets/Scripts/CleanArchitecture/Presentation/Adapters/LegacyPoolAdapter.cs:124)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:99)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSys<message truncated>
NullReferenceException: Object reference not set to an instance of an object
Bomb.GetExplosion (UnityEngine.Vector3 position) (at Assets/Scripts/PoolObject/Bomb.cs:98)
Bomb.Explode () (at Assets/Scripts/PoolObject/Bomb.cs:58)
Bomb.Update () (at Assets/Scripts/PoolObject/Bomb.cs:45)

NullReferenceException: Object reference not set to an instance of an object
Bomb.GetExplosion (UnityEngine.Vector3 position) (at Assets/Scripts/PoolObject/Bomb.cs:98)
Bomb.Explode () (at Assets/Scripts/PoolObject/Bomb.cs:58)
Bomb.Update () (at Assets/Scripts/PoolObject/Bomb.cs:45)

StackOverflowException: The requested operation caused a stack overflow.
UnityEngine.Object.FindObjectOfType (System.Type type, System.Boolean includeInactive) (at <37cc348edc804f4cb176b63962c716e7>:0)
UnityEngine.Object.FindObjectOfType[T] () (at <37cc348edc804f4cb176b63962c716e7>:0)
CleanArchitecture.Presentation.Adapters.LegacyPoolAdapter.get_Instance () (at Assets/Scripts/CleanArchitecture/Presentation/Adapters/LegacyPoolAdapter.cs:124)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:99)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSys<message truncated>
[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)

[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)

[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)

[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)

[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)

[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)

[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)

[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)

StackOverflowException: The requested operation caused a stack overflow.
UnityEngine.Object.FindObjectOfType (System.Type type, System.Boolean includeInactive) (at <37cc348edc804f4cb176b63962c716e7>:0)
UnityEngine.Object.FindObjectOfType[T] () (at <37cc348edc804f4cb176b63962c716e7>:0)
CleanArchitecture.Presentation.Adapters.LegacyPoolAdapter.get_Instance () (at Assets/Scripts/CleanArchitecture/Presentation/Adapters/LegacyPoolAdapter.cs:124)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:99)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSys<message truncated>
[AudioManager] OBSOLETO: Usando implementación legacy. Migrar a AudioSystemComposer.
UnityEngine.Debug:LogWarning (object)
AudioManager:Awake () (at Assets/Scripts/Audio/AudioManager.cs:61)

[Player] OBSOLETO: Usando implementación legacy. Migrar a CharacterSystemComposer.
UnityEngine.Debug:LogWarning (object)
Player:Start () (at Assets/Scripts/Character/Player.cs:49)

[ServiceLocator] ❌ Servicio IScoreService no encontrado
UnityEngine.Debug:LogError (object)
CleanArchitecture.Infrastructure.DependencyInjection.ServiceLocator:Get<CleanArchitecture.Application.Services.IScoreService> () (at Assets/Scripts/CleanArchitecture/Infrastructure/DependencyInjection/ServiceLocator.cs:59)
ScoreBar:Start () (at Assets/Scripts/UI/ScoreBar.cs:37)

Nombre de usuario actual: MARLON
UnityEngine.Debug:Log (object)
PlayerStatDisplay:Start () (at Assets/Scripts/UI/PlayerStatDisplay.cs:34)

[OBSOLETE] PauseMenu is deprecated. Use MenuSystemComposer instead.
UnityEngine.Debug:LogWarning (object)
PauseMenu:Start () (at Assets/Scripts/MenuComponents/PauseMenu.cs:15)

[FloatingTextSpawner] OBSOLETO: Usando implementación legacy. Migrar a VFXSystemComposer.
UnityEngine.Debug:LogWarning (object)
FloatingTextSpawner:Start () (at Assets/Scripts/VFX/FloatingTextSpawner.cs:42)

NullReferenceException: Object reference not set to an instance of an object
Bomb.GetExplosion (UnityEngine.Vector3 position) (at Assets/Scripts/PoolObject/Bomb.cs:98)
Bomb.Explode () (at Assets/Scripts/PoolObject/Bomb.cs:58)
Bomb.Update () (at Assets/Scripts/PoolObject/Bomb.cs:45)

[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)
UnityEngine.Object:Instantiate<UnityEngine.GameObject> (UnityEngine.GameObject,UnityEngine.Vector3,UnityEngine.Quaternion)
GameObjectSpawner:Get () (at Assets/Scripts/Utils/GameObjectSpawner.cs:10)
GameObjectSpawner:Spawn () (at Assets/Scripts/Utils/GameObjectSpawner.cs:14)
UnityEngine.Events.UnityEvent:Invoke ()
IntervalEvent:Update () (at Assets/Scripts/Events/IntervalEvent.cs:22)

[ColorFlash] OBSOLETO: Usando implementación legacy. Migrar a ColorFlashEffect.
UnityEngine.Debug:LogWarning (object)
ColorFlash:Awake () (at Assets/Scripts/VFX/ColorFlash.cs:43)
UnityEngine.Object:Instantiate<UnityEngine.GameObject> (UnityEngine.GameObject,UnityEngine.Vector3,UnityEngine.Quaternion)
GameObjectSpawner:Get () (at Assets/Scripts/Utils/GameObjectSpawner.cs:10)
GameObjectSpawner:Spawn () (at Assets/Scripts/Utils/GameObjectSpawner.cs:14)
UnityEngine.Events.UnityEvent:Invoke ()
IntervalEvent:Update () (at Assets/Scripts/Events/IntervalEvent.cs:22)

[Enemy] OBSOLETO: Usando implementación legacy. Migrar a CharacterSystemComposer.
UnityEngine.Debug:LogWarning (object)
Enemy:Start () (at Assets/Scripts/Character/Enemy.cs:59)

[Enemy] OBSOLETO: Usando implementación legacy. Migrar a CharacterSystemComposer.
UnityEngine.Debug:LogWarning (object)
Enemy:Start () (at Assets/Scripts/Character/Enemy.cs:59)

StackOverflowException: The requested operation caused a stack overflow.
UnityEngine.Object.FindObjectOfType (System.Type type, System.Boolean includeInactive) (at <37cc348edc804f4cb176b63962c716e7>:0)
UnityEngine.Object.FindObjectOfType[T] () (at <37cc348edc804f4cb176b63962c716e7>:0)
CleanArchitecture.Presentation.Adapters.LegacyPoolAdapter.get_Instance () (at Assets/Scripts/CleanArchitecture/Presentation/Adapters/LegacyPoolAdapter.cs:124)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:99)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:389)
PoolManager.ReturnToPool (PoolObjectType type, UnityEngine.GameObject g) (at Assets/Scripts/PoolSystem/PoolManager.cs:107)
PoolSystem.PoolSystemComposer.ReturnToPool (PoolSystem.Interfaces.IPoolable poolable) (at Assets/Scripts/PoolSystem/PoolSystemComposer.cs:285)
PoolSystem.PoolSystemComposer+PoolManagerCompat.ReturnToPool (PoolObjectType type, UnityEngine.GameObject gameObject) (at Assets/Scripts/PoolSystem/PoolSys<message truncated>
TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

Pool of type FlameBullet does not exist
UnityEngine.Debug:Log (object)
PoolManager:Get (PoolObjectType,UnityEngine.Vector3,UnityEngine.Quaternion) (at Assets/Scripts/PoolSystem/PoolManager.cs:62)
ObjectPool:Get (UnityEngine.Vector3,UnityEngine.Quaternion) (at Assets/Scripts/PoolSystem/ObjectPool.cs:32)
ShootComponent:Shoot (UnityEngine.Vector2,single) (at Assets/Scripts/Shooting/ShootComponent.cs:21)
AIShooter:Shoot (single) (at Assets/Scripts/Shooting/AIShooter.cs:24)
UnityEngine.Events.UnityEvent:Invoke ()
IntervalEvent:Update () (at Assets/Scripts/Events/IntervalEvent.cs:22)

NullReferenceException: Object reference not set to an instance of an object
ShootComponent.Shoot (UnityEngine.Vector2 direction, System.Single angleOffset) (at Assets/Scripts/Shooting/ShootComponent.cs:21)
AIShooter.Shoot (System.Single angleOffset) (at Assets/Scripts/Shooting/AIShooter.cs:24)
UnityEngine.Events.InvokableCall`1[T1].Invoke (T1 args0) (at <37cc348edc804f4cb176b63962c716e7>:0)
UnityEngine.Events.CachedInvokableCall`1[T].Invoke (System.Object[] args) (at <37cc348edc804f4cb176b63962c716e7>:0)
UnityEngine.Events.UnityEvent.Invoke () (at <37cc348edc804f4cb176b63962c716e7>:0)
IntervalEvent.Update () (at Assets/Scripts/Events/IntervalEvent.cs:22)

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

NullReferenceException: Object reference not set to an instance of an object
Bomb.GetExplosion (UnityEngine.Vector3 position) (at Assets/Scripts/PoolObject/Bomb.cs:98)
Bomb.Explode () (at Assets/Scripts/PoolObject/Bomb.cs:58)
Bomb.Update () (at Assets/Scripts/PoolObject/Bomb.cs:45)

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

TLS Allocator ALLOC_TEMP_TLS, underlying allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

Internal: Stack allocator ALLOC_TEMP_MAIN has unfreed allocations, size 14080

To Debug, run app with -diag-temp-memory-leak-validation cmd line argument. This will output the callstacks of the leaked allocations.

Allocation of 5888 bytes at 000001DC00502040

Allocation of 8192 bytes at 000001DC00500030

