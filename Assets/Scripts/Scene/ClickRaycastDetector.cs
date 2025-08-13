using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRaycastDetector : MonoBehaviour
{
    public GameObject photo;
    public GameObject calendar;
    public GameObject clock;
    public GameObject chair;
    public GameObject drawer;
    public GameObject altar;


    public void ShowItemsCollider()
    {
        photo.SetActive(true);
        calendar.SetActive(true);
        clock.SetActive(true);
        chair.SetActive(true);
        drawer.SetActive(true);
        altar.SetActive(true);
    }

    public void HideItemsCollider()
    {
        photo.SetActive(false);
        calendar.SetActive(false);
        clock.SetActive(false);
        chair.SetActive(false);
        drawer.SetActive(false);
        altar.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                BoxCollider boxcollider = hit.collider as BoxCollider;
                if (boxcollider != null)
                {
                    print($"Hit>| {boxcollider.gameObject.name} ");
                    if (boxcollider.gameObject.name == "Calendar")
                    {
                        UIMgr.I.ui_oldHouse.pnl_calendar.ShowCalendar();
                    }
                    else if (boxcollider.gameObject.name == "Clock")
                    {
                        UIMgr.I.ui_oldHouse.pnl_clock.TryShowClock();
                    }
                    else if (boxcollider.gameObject.name == "Chair")
                    {
                        UIMgr.I.ui_oldHouse.pnl_chair.TryMoveChair();
                    }
                    else if (boxcollider.gameObject.name == "Drawer")
                    {
                        UIMgr.I.ui_oldHouse.pnl_drawer.ShowDrawer();
                    }
                    else if (boxcollider.gameObject.name == "Photo")
                    {
                        UIMgr.I.ui_oldHouse.pnl_photo.ShowPhoto();
                    }
                    else if (boxcollider.gameObject.name == "Altar")
                    {
                        UIMgr.I.ui_oldHouse.pnl_altar.ShowAltar();
                    }
                }
            }
        }
    }
}
