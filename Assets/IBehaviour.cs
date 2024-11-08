using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehaviour 
{
    public void SetState(Context.State state);
    public Context.State GetState();

    public void UpdateObject();
}
