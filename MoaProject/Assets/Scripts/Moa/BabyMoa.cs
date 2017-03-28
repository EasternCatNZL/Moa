using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMoa : MonoBehaviour {

    public float hungerMeter = 10.0f; //float to store hunnger of baby moa
    public float fHungerDecay = 0.1f; //float to use for decaying hunger meter over time, public so it can be adjusted in unity
    //public GameObject Moa;
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HungerDecay();
	}

    void HungerDecay() //decays hungerMeter over time
    {
        hungerMeter -= fHungerDecay * Time.deltaTime;
        if(fHungerDecay <= 0.0f)
        {
            //gameover
        }
        if(hungerMeter > 10.0f)
        {
            hungerMeter = 10.0f;
        }
    }

   public void HungerMeterIncrease() //used when baby moa recieves food, increases the hunger meter
    {
        hungerMeter++;        
    }
}
