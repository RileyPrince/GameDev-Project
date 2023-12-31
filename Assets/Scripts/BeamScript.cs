using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{
    public float swingTime = 10f;
    private float timer;
    public float damage = 10;
    public Unit script;
    public BattleSystem battleScript;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        script = FindObjectOfType<Unit>();
        battleScript = FindObjectOfType<BattleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= swingTime)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.back / 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            script = other.GetComponent<Unit>();
            script.currentHP = script.currentHP - damage;
            if (script.currentHP <= 0)  //Once we have an enemy attack coded in move this script to there, to check  if the player is dead
            {
                battleScript.GameOverUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            Destroy(gameObject);
        }
    }
}
