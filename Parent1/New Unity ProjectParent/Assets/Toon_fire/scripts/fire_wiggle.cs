using UnityEngine;
using System.Collections;

public class fire_wiggle : MonoBehaviour {
	private float t=0f;
	private float wiggle_t=0f;
	private float initial_start_speed;
	private float initial_emission_rate;
	private float initial_lifetime;
	private float initial_size;
	// Use this for initialization
	
	void Start () {
	initial_start_speed=this.particleSystem.startSpeed;
    initial_emission_rate=this.particleSystem.emissionRate;
	initial_lifetime = this.particleSystem.startLifetime;
	initial_size = this.particleSystem.startSize;
	}
	
	// Update is called once per frame
	void Update () {
		t+=Time.deltaTime;
		wiggle_t+=Time.deltaTime;
		
		
		//creatin bursts of fire to make it more physically  realistic-->
		if (t>(2f+(2f-Mathf.Sin(wiggle_t)))){
			
		
		
		this.particleSystem.emissionRate+=(initial_emission_rate*.4f-this.particleSystem.emissionRate)/30f;
			this.particleSystem.startLifetime+=(initial_lifetime*.9f-this.particleSystem.startLifetime)/30f;
			
			if (this.particleSystem.emissionRate<initial_emission_rate*.42f){
				this.particleSystem.emissionRate = initial_emission_rate*1.1f;
					this.particleSystem.startLifetime=initial_lifetime*1.1f;
				this.particleSystem.startSpeed=initial_start_speed*.7f;
					this.particleSystem.startSize= initial_size*1.1f;
				t=0f;
			}
		} else{
		this.particleSystem.emissionRate+=(initial_emission_rate-this.particleSystem.emissionRate)/30f;
			this.particleSystem.startLifetime+=(initial_lifetime-this.particleSystem.startLifetime)/30f;
			this.particleSystem.startSpeed+=(initial_start_speed-this.particleSystem.startSpeed)/30f;
			this.particleSystem.startSize+=(initial_size-this.particleSystem.startSize)/30f;
				
			
		}
	}
}
