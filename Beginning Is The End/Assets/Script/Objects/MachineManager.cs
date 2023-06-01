using System;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    [SerializeField] private GameObject Machine1;
    [SerializeField] private GameObject Machine2;
    [SerializeField] private GameObject Machine3;
    [SerializeField] private GameObject Machine4;

    public bool level1finished = false;
    public bool level2finished = false;
    public bool level3finished = false;


    private void Update()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        
        if (players.Length == 0)
        {
            return;
        }
        
        level1finished = players[0].GetComponent<LevelManagger>().level1finished; 
        level2finished = players[0].GetComponent<LevelManagger>().level2finished;
        level3finished = players[0].GetComponent<LevelManagger>().level3finished;
        
        if (level1finished)
        {
            Machine1.SetActive(false);
            Machine2.SetActive(true);
            Machine3.SetActive(false);
            Machine4.SetActive(false);
        }
        
        if (level2finished)
        {
            Machine1.SetActive(false);
            Machine2.SetActive(false);
            Machine3.SetActive(true);
            Machine4.SetActive(false);
        }
        
        if (level3finished)
        {
            Machine1.SetActive(false);
            Machine2.SetActive(false);
            Machine3.SetActive(false);
            Machine4.SetActive(true);
        }
    }
}