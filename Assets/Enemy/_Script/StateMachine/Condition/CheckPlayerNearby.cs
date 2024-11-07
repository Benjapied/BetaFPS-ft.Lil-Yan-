using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerNearby : Condition
{
    public override bool Test(Enemy enemy)
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(enemy.gameObject.transform.position, 5.0f);

        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject != enemy.gameObject)
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
