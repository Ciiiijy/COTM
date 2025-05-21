using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_OldHouse : MonoBehaviour, SceneFunc
{
    public Button btn_L;

    public Button btn_back;
    private GameObject currentObj;
    public GameObject calendar;
    
    public void Init()
    {
        btn_L?.gameObject.SetActive(false);
        Hide();
        btn_back.onClick.AddListener(() => 
        {
            btn_back.gameObject.SetActive(false);
            currentObj?.SetActive(false);
        });
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowCalendar() 
    {
        calendar.SetActive(true);
        btn_back.gameObject.SetActive(true);
        currentObj = calendar;
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
