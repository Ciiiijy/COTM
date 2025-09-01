using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_Altar : MonoBehaviour
{
    public GameObject protrait;
    public TextMeshProUGUI context;

    public void Init()
    {
        Hide();
        protrait?.gameObject.SetActive(false);
        context?.gameObject.SetActive(false);
    }

    public void ShowAltar()
    {
        protrait.gameObject.SetActive(true);
        context.gameObject.SetActive(true);

        this.gameObject.SetActive(true);
        UIMgr.I.ui_oldHouse.ShowBtnBack(this.gameObject);
        GameMgr.I.player.CanMove(false);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
