using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoaFood : MonoBehaviour
{

    public float fStones = 0.0f;
    public float fBerries = 0.0f;

    public float stoneDecay = 1.0f;

    bool bHasStones = false;
    bool bCanEat = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CanEatBerries();
        StoneDecay();
    }

    bool CanEatBerries()
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

    void StoneDecay()
    {
        if (bHasStones == true && fStones > 0)
        {
            fStones -= stoneDecay * Time.deltaTime;
            if(fStones < 0)
            {
                fStones = 0;
                bHasStones = false;
            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Stone") && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.SetActive(false);
            fStones++;
            bHasStones = true;       
        }

        if(other.gameObject.CompareTag("Berry") && Input.GetKeyDown(KeyCode.E))
        {
            if(bCanEat == true)
            {
                other.gameObject.SetActive(false);
                fBerries++;
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
            }
            else
            {

            }
            
        }
    }

}
