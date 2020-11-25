using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
public GameObject ballPrefab;
public int ballAmount = 10;
    void Start()
    {
        for (int i = 0; i<ballAmount; ++i){
        GameObject ballObject = Instantiate(ballPrefab);
        ballObject.transform.position = new Vector3(
            Random.Range(-10,10),
            Random.Range(5, 10),
            Random.Range(10, 20)
        );
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
