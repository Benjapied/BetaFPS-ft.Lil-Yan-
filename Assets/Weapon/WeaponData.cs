using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "My Game / Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string _nameWeapon;
    public GameObject _weaponPrefab;
    public int _weaponDamage;
    public float _timeReloading;
    public float _timeBetweenShoot;
    public int _nbBalls;
}
