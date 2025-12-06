#pragma warning disable CS0618 // Type or member is obsolete
using UnityEngine;

public class MapSelectZone : MonoBehaviour
{
    [SerializeField]
    private string mapSceneName;

    private bool isTriggeredByPlayer;
    private MapDisplay mapDisplay;

    private bool isLocked = true;
    public bool IsLocked
    {
        get => isLocked;
        set => isLocked = value;
    }

    public void Start()
    {
        mapDisplay = MapDisplay.Instance;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        isTriggeredByPlayer = true;
        mapDisplay.VisitedMapSceneName = mapSceneName;
        mapDisplay.IsLocked = isLocked;

        if (isLocked)
            mapDisplay.SetTooltipText("Map Locked");
        else
            mapDisplay.SetTooltipText(
                string.Format("Press {0} to enter", mapDisplay.DisplayKey.ToString())
            );

        mapDisplay.SetLocationText(mapSceneName);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null)
            return;

        isTriggeredByPlayer = false;
        mapDisplay.VisitedMapSceneName = null;
        mapDisplay.SetLocationTextToDefault();
        mapDisplay.SetTooltipTextToDefault();
    }
}
