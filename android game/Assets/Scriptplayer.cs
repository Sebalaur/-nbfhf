using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scriptplayer : MonoBehaviour
{
    public float speed =20.0f;
    public float jumpForce = 300.0f;
    private float levelnum = 1;

	private float bestlevelnum = 1;

	public Text level;

	public Text bestlevel;
     
    private bool canJump = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, speed*Time.deltaTime);
        if(Input.GetKey("a")){
            transform.Translate(-5*Time.deltaTime,0,0);
        }
        if(Input.GetKey("d")){
            transform.Translate(5*Time.deltaTime,0,0);
        }
        if(Input.GetMouseButtonDown(0)&& canJump){
            canJump = false;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }
        if(transform.position.y < -1){
            transform.position = new Vector3(0,1,1);
            levelnum = 1;
			speed = 25;
			level.text = "Level: " + levelnum;
        }
        transform.Translate(Input.acceleration.x, 0, 0);
    }
    void OnCollisionEnter(Collision collision) {
        canJump = true;
        if(collision.gameObject.tag == "obstacle"){
            transform.position = new Vector3(0,1,1);
            levelnum = 1;
			speed = 25;
			level.text = "Level: " + levelnum;
        }
        if(collision.gameObject.tag == "end"){
            SceneManager.LoadScene("SampleScene");
            transform.position = new Vector3(0,1, 1);
            speed += 5;
			levelnum += 1;
			if(levelnum > bestlevelnum){
				bestlevelnum += 1;
			}
			bestlevel.text = "Best Level: " + bestlevelnum;
			level.text = "Level: " + levelnum;
        }
        
    }
}
