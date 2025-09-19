using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive_OnTheMountain : MonoBehaviour
{
    public GameObject billBoard;

    public void ShowItemsCollider()
    {
        billBoard.SetActive(true);
    }
    public void HideItemsCollider()
    {
        billBoard.SetActive(false);
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
                    if (boxcollider.gameObject.name == "BillBoard")
                    {
                        UIMgr.I.ui_onTheMountain.pnl_billBoard.ShowBillBoard();
                    }
                    else if (boxcollider.gameObject.name == "Temple")
                    {
                        UIMgr.I.ui_onTheMountain.pnl_temple.ShowTemple();
                    }
                }
            }
        }
    }
}
