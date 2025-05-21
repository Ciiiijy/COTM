using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRaycastDetector : MonoBehaviour
{
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
                BoxCollider boxcollider=hit.collider as BoxCollider;
                if (boxcollider != null) 
                {
                    print($"Hit>| {boxcollider.gameObject.name} ");
                    if (boxcollider.gameObject.name == "Calendar") 
                    {
                        UIMgr.I.ui_oldHouse.ShowCalendar();
                    }
                }
            }
        }
    }
}
