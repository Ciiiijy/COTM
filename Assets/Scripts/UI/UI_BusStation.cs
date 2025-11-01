using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BusStation : MonoBehaviour,SceneFunc
{
    public Button btn_R;
    //public Button btn_L;

    public void Init() 
    {
        Hide();
        //btn_L?.gameObject.SetActive(false);
        btn_R?.gameObject.SetActive(false); 
    }
    

    public void Show()
    {
        this.gameObject.SetActive(true);
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
