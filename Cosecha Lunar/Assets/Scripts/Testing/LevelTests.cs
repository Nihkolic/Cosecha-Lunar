using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTests : MonoBehaviour
{
    [SerializeField] private Transform Position01, Position02, Position03;
    private GameObject _player;
    public static bool DEBUG_MODE;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        DEBUG_MODE = true;
    }
    private void Update()
    {
        if (DEBUG_MODE)
        {
            LevelChange();
        }
    }
    private void Health()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Input.GetKeyDown(KeyCode.Alpha9))
        {
            _player.GetComponent<PlayerHealth>().Heal(10);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            _player.GetComponent<PlayerHealth>().TakeDamage(10);
        }
    }
    private void LevelChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _player.GetComponent<PlayerCombat>().BlasterRevert();
            _player.transform.position = Position01.transform.position;
            print("Nivel 1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = Position02.transform.position;
            print("Nivel 2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _player.GetComponent<PlayerCombat>().BlasterGet();
            _player.transform.position = Position03.transform.position;
            print("Nivel 3");
        }
    }
}
