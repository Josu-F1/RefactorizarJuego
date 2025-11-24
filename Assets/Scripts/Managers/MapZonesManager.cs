using UnityEngine;

public class MapZonesManager : MonoBehaviour
{
    public void Start()
    {
        int level = DataManager.GetPlayerLevel(DataManager.CurrentUsername);

        MapSelectZone[] levels = GetComponentsInChildren<MapSelectZone>();

        for (int i = 0; i <= level; i++)
        {
            levels[i].IsLocked = false;
        }
    }
}
