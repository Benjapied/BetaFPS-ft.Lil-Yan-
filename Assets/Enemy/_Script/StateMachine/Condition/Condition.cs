using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition 
{
    

    public virtual bool Test(Enemy enemy)
    {
        return false;
    }
}
