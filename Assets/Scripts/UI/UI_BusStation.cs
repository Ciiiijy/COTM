using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BusStation : MonoBehaviour,SceneFunc
{
    public Button btn_R;

    public void Init() 
    {
        if (btn_R)
            btn_R.onClick.AddListener(() =>
            {

            });


    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowBtn() 
    {
        btn_R.gameObject.SetActive(true);
    }
    public void HideBtn() 
    {
        btn_R.gameObject.SetActive(false);
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
