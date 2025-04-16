using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr I;
    public NPCs npcs;      
    public Player player;
    public BusStation busStation;
    public OnTheBus onTheBus;
    public FangsOldHouse fangsOldHouse;
    public OldHouse oldHouse;
    public OnTheMountain onTheMountain;
    public Ending ending;

   

    public Dictionary<string, SceneFunc> dic_SceneGameObj = new Dictionary<string, SceneFunc>();


    private void Awake()
    {
        I = this;
        //Init each module here.
        player.Init();
        npcs.Init();            //Must do at the beginning.
        busStation.Init();
        //fangsOldHouse.Init();
        onTheBus.Init();
        oldHouse.Init();
        onTheMountain.Init();
        ending.Init();
  

        InitDictionary();
    }
    public void InitDictionary()
    {
        dic_SceneGameObj.Add("OnTheBus", onTheBus);
        dic_SceneGameObj.Add("BusStation", busStation);
        dic_SceneGameObj.Add("OldHouse",oldHouse);
        //dic_SceneGameObj.Add(,);
    }
}

public interface SceneFunc 
{
    public void Show();
    public void Hide();
}