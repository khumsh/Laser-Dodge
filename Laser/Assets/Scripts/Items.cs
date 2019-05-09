using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {
	public Player player;
	public GameManager gameManager;
	public Animator anim;


	void Start(){
		player = FindObjectOfType<Player>();
		gameManager = FindObjectOfType<GameManager>();
		anim = GetComponent<Animator>();

		// Invoke("Blink", 8);
		Destroy(gameObject, 10f);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player" && this.tag == "Small Item"){
			gameManager.isSmall = true;
			other.transform.localScale = new Vector3(3.5f, 3.5f, 0);

			if(gameManager.isSmall){
				gameManager.itemTime = 15f;
				this.gameObject.SetActive(false);
			}else{
				Debug.Log("Get Small Item");
				gameManager.isSmall = true;
				this.gameObject.SetActive(false);
				gameManager.itemTime = 15f;
				other.transform.localScale = new Vector3(3.5f, 3.5f, 0);
			}

			if(gameManager.isFast){
				gameManager.isFast = false;
				player.speed = 5f;
			}
			gameManager.isEaten = true;

		}

		if(other.tag == "Player" && this.tag == "Speed Item"){
			gameManager.isFast = true;
			player.speed = 8f;

			if(gameManager.isFast){
				gameManager.itemTime = 15f;
				this.gameObject.SetActive(false);
			}else{
				Debug.Log("Get Speed Item");
				gameManager.isFast = true;
				this.gameObject.SetActive(false);
				gameManager.itemTime = 15f;
				player.speed = 8f;
			}

			if(gameManager.isSmall){
				gameManager.isSmall = false;
				player.transform.localScale = new Vector3(6f, 6f, 0);
			}

			gameManager.isEaten = true;
		}
	}

	public void GetBigger(){
		player.transform.localScale = new Vector3(6f, 6f, 0);
		gameManager.isSmall = false;
	}

	public void GetSlow(){
		player.speed -= 3f;
		gameManager.isFast = false;
	}

/*
	private void Blink(){	
		if(!gameManager.isEaten)
		anim.SetTrigger("Blink");
	}
*/
}
