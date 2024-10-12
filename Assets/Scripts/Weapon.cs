using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Weapons/WeaponBase")]
public class Weapon : ScriptableObject
{
    [field: SerializeField, TextArea] public string Description { get; private set; }

    [field: SerializeField] public float WeaponCooldown { get; private set; }
    [field: SerializeField] public float WeaponDamage { get; private set; }

}
