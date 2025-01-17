using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr I;
    public BusStation busStation;
    public OnTheBus onTheBus;
    public OldHouse oldHouse;
    public OnTheMountain onTheMountain;
    public Ending ending;



    private void Awake()
    {
        I = this;
        //Init each module here.
        busStation.Init();
        onTheBus.Init();
        oldHouse.Init();
        onTheMountain.Init();
        ending.Init();

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
