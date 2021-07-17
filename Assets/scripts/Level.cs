using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int BrokenBLocks =0  ;
    SceneLoader sceneLoader;
    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBrokenBlocks()
    {
            BrokenBLocks++;
    }
    public void ReduceBlockCount()
    {
        BrokenBLocks--;
        if(BrokenBLocks==0)
        {
            sceneLoader.LoadIntScene();
        }
    }
}
