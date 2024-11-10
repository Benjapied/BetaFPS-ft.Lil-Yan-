using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class CheckPlayerNearby : Condition
{
    public override bool Test(IBehaviour iBehaviour)
    {
        if (iBehaviour is Enemy enemy)
        {
            Vector3 directionToPlayer = (enemy._transform.position - enemy.gameObject.transform.position).normalized;
            
            float angleToPlayer = Vector3.Angle(enemy.gameObject.transform.forward, directionToPlayer);
            if (angleToPlayer < enemy.visionAngle / 2)
            {
                
                float distanceToPlayer = Vector3.Distance(enemy.gameObject.transform.position, enemy._transform.position);
                if (distanceToPlayer < enemy.DistanceDetection)
                {
                    //return true;
                    // Faire un raycast pour vérifier si le joueur est caché par un obstacle
                    if (!Physics.Raycast(enemy.gameObject.transform.position, directionToPlayer, distanceToPlayer, enemy.maskObstacle))
                    {
                        // Le joueur est dans le cône de vision et n'est pas caché par un obstacle
                        return true;
                    }
                }
            }   
        }
        return false;
    }
}
