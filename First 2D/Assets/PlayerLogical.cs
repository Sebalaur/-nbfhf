using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogical : MonoBehaviour
{
    public ScoreLogic scoreGUIScript;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var tempMousePosition = Input.mousePosition;
        tempMousePosition = Camera.main.ScreenToWorldPoint(tempMousePosition);
        tempMousePosition.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, tempMousePosition, 2000 * Time.deltaTime);

    }
    void OnCollisionEnter2D(Collision2D tempCollision){
        if (tempCollision.gameObject.tag == "Collectable"){
            Destroy(tempCollision.gameObject);
            scoreGUIScript.score += 1;
        }
        else if (tempCollision.gameObject.tag == "BadCollectable"){
            SceneManager.LoadScene("SampleScene");
        }
    }
}
