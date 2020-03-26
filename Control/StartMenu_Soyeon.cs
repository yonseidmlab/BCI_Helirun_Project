using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class StartMenu_Soyeon : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
    public GameObject scene2Heli;
    public GameObject scene3to11Heli;
    public GameObject scene12to14Heli;
    public GameObject appearDepressGroup;
    public GameObject floatDepressGroup;
    public GameObject heli9_1;
    public GameObject heli9_2;
    public GameObject heli9_3;
    public GameObject scene11Heli;
    public GameObject electricFriends;
    public GameObject statusPane;

    // When highlighted with mouse.
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Do something.
        Debug.Log("<color=red>Event:</color> Completed mouse highlight.");
    }
    // When selected.
    public void OnSelect(BaseEventData eventData)
    {
        // Do something.
        Debug.Log("<color=red>Event:</color> Completed selection.");
        Destroy(scene2Heli);
        Destroy(scene3to11Heli);
        Destroy(scene12to14Heli);
        Destroy(appearDepressGroup);
        Destroy(floatDepressGroup);
        Destroy(heli9_1);
        Destroy(heli9_2);
        Destroy(heli9_3);
        Destroy(scene11Heli);
        Destroy(electricFriends);
        Destroy(statusPane);

    }
}