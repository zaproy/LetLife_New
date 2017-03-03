using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotParticle : MonoBehaviour {
	
	public ParticleSystem waterSplash;
	
	void OnTriggerEnter2D(Collider2D trigg){
		if(trigg.gameObject.tag == "ingradiant"){
			waterSplash.Play();
		}
	}
}
