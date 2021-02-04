using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public GameObject collectible;
    private bool focus = false;
    void Start()
    {
        
    }
    public void LoadStart(){
        focus = true;
        StartCoroutine(Loading());
    }
    public void LoadStop()
    {
        focus = false;
        StopAllCoroutines();
    }
    IEnumerator Loading(){
        while(true){
            yield return new WaitForSeconds(1f);
            LoadingDone();
        }
    }
    void LoadingDone(){
        if(focus){
            Destroy(collectible);
            StopAllCoroutines();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
