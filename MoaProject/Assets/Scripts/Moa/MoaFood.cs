using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoaFood : MonoBehaviour
{

    public float fStones = 0.0f; //float to store stones, public for testing
    public float fBerries = 0.0f; //float to store berries/food, public for testing

    public float stoneDecay = 0.1f; //float to use for decaying stones over time, public so it can be edited in unity
   
    //bool bHasStones = false;
    bool bCanEat; //used in CanEatBerries()


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //CanEatBerries();
        StoneDecay();
    }

    bool CanEatBerries() //will return true if the moa has stones
    {
        if (fStones > 0)
        {
            bCanEat = true;
        }
        else
        {
            bCanEat = false;
        }

        return bCanEat;
    }

    void StoneDecay() //decays stones eaten over time
    {
        if (bCanEat == true && fStones > 0)
        {
            fStones -= stoneDecay * Time.deltaTime;
            //print("losing stones");
            if(fStones < 0)
            {
                fStones = 0;
                bCanEat = false;
            }
        }

    }

    void OnTriggerStay(Collider other) //compares colleder with gameobject tag to do actions
    {
        if(other.gameObject.CompareTag("Stone") && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.SetActive(false);
            fStones++;
            //bHasStones = true;
            print("ate stone");       
        }

        if(other.gameObject.CompareTag("Berry") && Input.GetKeyDown(KeyCode.E))
        {
            CanEatBerries();
            if (bCanEat == true)
            {
                other.gameObject.SetActive(false);
                fBerries++;
                print("ate berry");
            }
            else
            {

            }
        }

        if(other.gameObject.CompareTag("Nest") && Input.GetKeyDown(KeyCode.E))
        {
            if(fBerries > 0)
            {
                fBerries--;
                other.gameObject.GetComponent<BabyMoa>().HungerMeterIncrease();
                print("fed berry");              
            }
            else
            {

            }
            
        }
    }

}
