using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStation : MonoBehaviour,SceneFunc
{
    public Wall wall_L;
    public Wall wall_R;

    public void Init() 
    {
        Hide();
        wall_L.Init();
        wall_R.Init();
    }

    public void Show() 
    {
        gameObject.SetActive(true);
        GameMgr.I.player.Show();
        GameMgr.I.npcs.GetNpc("Rui").SetActive(true);
    }
    public void Hide() 
    {
        gameObject.SetActive(false);
        GameMgr.I.npcs.GetNpc("Rui").SetActive(false);
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
