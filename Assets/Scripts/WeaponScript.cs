using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponScript : MonoBehaviour
{
    public GameObject projectile; //This is the projectile
    public GameObject self;
    public string weaponName; //the number of the weapon, to tell the weaponManager which weapon to find.
    public bool attack = false; //is the peashooter attacking?

    // Start is called before the first frame update
    void Start()
    {
        weaponName = self.name;

        if (weaponName == "HeldPeashooter")
        {
            var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Pea.prefab", typeof(GameObject));
            projectile = prefab as GameObject;
        }

        if (weaponName == "HeldChomper")
        {
            var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Chomp.prefab", typeof(GameObject));
            projectile = prefab as GameObject;
        }

        /*if (weaponName == "Peashooter")
        {
            var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Pea.prefab", typeof(GameObject));
            projectile = prefab as GameObject;
        }

        if (weaponName == "Peashooter")
        {
            var prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Pea.prefab", typeof(GameObject));
            projectile = prefab as GameObject;
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}

