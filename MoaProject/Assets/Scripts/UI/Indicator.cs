using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public float destroyDelay = 5.0f;
    //public Canvas canvas; //reference to the canvas
    public GameObject moa; //reference to moa object
    //public GameObject indicatorArm; //reference to the indicator arm, used to rotate indicator around
    public GameObject indicatorHead; //reference to the indicator head, where the arrow should be
    public GameObject target; //reference to target to point at
    public GameObject indicatorArrow; //reference to indicator arrow object

    // Use this for initialization
    void Start()
    {
        moa = GameObject.FindGameObjectWithTag("Moa");
        target = GameObject.FindGameObjectWithTag("Egg");
        PointAtTarget();
        StartCoroutine("DestroyAfterDelay");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //point an arrow towards the target inside ui
    public void PointAtTarget()
    {
        //get angle that target is located compared to current transform
        float angle = Vector3.Angle(moa.transform.forward, target.transform.position - moa.transform.position);
        print("Angle: " + angle);
        //set arm to rotation, for circular effect
        //check if moa is on x +ve side of egg
        if (moa.transform.position.x - target.transform.position.x >= 0)
        {
            transform.Rotate(0.0f, 0.0f, angle);
        }
        //else on -ve side
        else if (moa.transform.position.x - target.transform.position.x < 0)
        {
            transform.Rotate(0.0f, 0.0f, 360 - angle);
        }
        //make clone of arrow object
        GameObject arrowClone = indicatorArrow;
        //spawn arrow at point
        Instantiate(arrowClone, indicatorHead.transform.position, indicatorHead.transform.rotation, transform);

        GameObject clone = Instantiate(indicatorArrow, indicatorHead.transform.position, indicatorHead.transform.rotation) as GameObject;
        clone.transform.SetParent(indicatorHead.transform, false);
        print("Tried to spawn arrow");
        //set parent to canvas
        //arrowClone.transform.parent = gameObject.transform;
        
    }

    IEnumerator DestroyAfterDelay()
    {
        //wait brief delay
        print("coroutine started");
        yield return new WaitForSeconds(destroyDelay);
        //destroy object
        print("couroutine returned");
        Destroy(gameObject);
    }
}
