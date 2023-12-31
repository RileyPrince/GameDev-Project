using UnityEngine;
using System.Linq;

public class WeaponManager : MonoBehaviour
{
    public GameObject weapon;
    public GameObject spawnWeapon;
    public WeaponScript weaponScript;
    public Transform spawnTransform; //Where the projectile is fired from
    public Transform weaponTransform;
    public float reload1 = 0;
    public float reload2 = 0;
    public float reload3 = 0;

    public GameObject PeaShooter;
    public GameObject Chomper;
    public GameObject Melon;
    public ShopScript script;
    GameManager gameManager;


    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon"); //default weapon is peashooter
        weaponScript = weapon.GetComponent<WeaponScript>(); //access the weapon's script
        script = Resources.FindObjectsOfTypeAll<ShopScript>().FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
        if (reload1 > 0)
        {
            reload1 = reload1 - Time.deltaTime;
        }
        else if (reload1 < 0)
        {
            reload1 = 0;
        }


        if (reload2 > 0)
        {
            reload2 = reload2 - Time.deltaTime;
        }
        else if (reload2 < 0)
        {
            reload2 = 0;
        }

        if (reload3 > 0)
        {
            reload3 = reload3 - Time.deltaTime;
        }
        else if (reload3 < 0)
        {
            reload3 = 0;
        }

        if (Input.GetKeyDown("1"))
        {
            Destroy(weapon);
            weapon = Instantiate(PeaShooter, weaponTransform.position, weaponTransform.rotation, weaponTransform);
            weapon.transform.Rotate(90, 0, 0, Space.Self);
            weaponScript = weapon.GetComponent<WeaponScript>();
        }
        if (gameManager.Weapon_2_Buy && Input.GetKeyDown("2"))
        {
            Destroy(weapon);
            weapon = Instantiate(Chomper, weaponTransform.position, weaponTransform.rotation, weaponTransform);
            weapon.transform.Rotate(90, 0, 0, Space.Self);
            weaponScript = weapon.GetComponent<WeaponScript>();
        }
        if (gameManager.Weapon_3_Buy && Input.GetKeyDown("3"))
        {
            Destroy(weapon);
            weapon = Instantiate(Melon, weaponTransform.position, weaponTransform.rotation, weaponTransform);
            weapon.transform.Rotate(90, 0, 0, Space.Self);
            weaponScript = weapon.GetComponent<WeaponScript>();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (weaponScript.projectile.name == "Pea" && reload1 <= 0)
            {
                GameObject temp = Instantiate(weaponScript.projectile, spawnTransform.position, spawnTransform.rotation);
                reload1 = weaponScript.cooldown;
            }
            else if (weaponScript.projectile.name == "Chomp" && reload2 <= 0)
            {
                GameObject temp = Instantiate(weaponScript.projectile, spawnTransform.position, spawnTransform.rotation);
                reload2 = weaponScript.cooldown;
            }
            else if (weaponScript.projectile.name == "Melon" && reload3 <= 0)
            {
                GameObject temp = Instantiate(weaponScript.projectile, spawnTransform.position, spawnTransform.rotation);
                reload3 = weaponScript.cooldown;
            }
        }
    }
}
