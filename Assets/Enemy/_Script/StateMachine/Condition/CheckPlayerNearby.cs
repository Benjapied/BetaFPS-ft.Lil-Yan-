using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerNearby : Condition
{
    public override bool Test(Enemy enemy)
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5.0f);

        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject != gameObject)
            {
                if(collider.gameObject.tag == "Player")
                {
                    return true;
                }
                
            }
        }

        return false;
    }
}
