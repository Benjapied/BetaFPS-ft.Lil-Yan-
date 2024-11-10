using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class WeaponManager : MonoBehaviour
{

    BehaviourGeneral _behaviour;
    public GameObject _prefabWeapon;
    // Start is called before the first frame update
    void Start()
    {
        _behaviour = new BehaviourGeneral();


        _behaviour.AddState(Context.State.ShootWeapon, new WeaponShootState());
        _behaviour.AddState(Context.State.ReloadingWeapon, new WeaponReloadingState());


        // Transition Shoot To Reload
        Transition shootToReload = new Transition();
        shootToReload.TargetState = Context.State.ReloadingWeapon;
        shootToReload.AddCondition(new CheckNumberBall());

        _behaviour.AddTransition(Context.State.ShootWeapon, shootToReload);

        // Transition Reload To Shoot
        Transition reloadToShoot = new Transition();
        reloadToShoot.TargetState = Context.State.ShootWeapon;
        reloadToShoot.AddCondition(new CheckTimeReload());

        _behaviour.AddTransition(Context.State.ReloadingWeapon, reloadToShoot);





        _prefabWeapon.GetComponent<Weapon>().State = Context.State.ShootWeapon;
        _prefabWeapon.GetComponent<Weapon>().Behaviour = _behaviour;

        _prefabWeapon.GetComponent<Weapon>().SetState(Context.State.ShootWeapon);

    }

    // Update is called once per frame
    void Update()
    {
        _prefabWeapon.GetComponent<Weapon>().UpdateObject();
    }
}
