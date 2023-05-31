using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagger : MonoBehaviour
{
    public bool level1finished = false;
    public bool level2finished = false;
    public bool level3finished = false;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            level1finished = GameObject.Find("ExitWhenCompleted").GetComponent<ExitWhenCompleted>().levelCompleted;
        }
        
        if (SceneManager.GetActiveScene().name == "Level2")
        { 
            level2finished = GameObject.Find("Sphere").GetComponent<Level2Completed>().ended;
        }
        
        if (SceneManager.GetActiveScene().name == "Level3")
        {
        }
        
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (level1finished && !level2finished && !level3finished)
            {
                GameObject.Find("Machines_1").SetActive(false);
                GameObject.Find("Machines_2").SetActive(true);
                GameObject.Find("Machines_3").SetActive(false);
                GameObject.Find("Machines_4").SetActive(false);
                
            }
            
            if (level1finished && level2finished && !level3finished)
            {
                GameObject.Find("Machines_1").SetActive(false);
                GameObject.Find("Machines_2").SetActive(false);
                GameObject.Find("Machines_3").SetActive(true);
                GameObject.Find("Machines_4").SetActive(false);
            }
            
            if (level1finished && level2finished && level3finished)
            {
                GameObject.Find("Machines_1").SetActive(false);
                GameObject.Find("Machines_2").SetActive(false);
                GameObject.Find("Machines_3").SetActive(false);
                GameObject.Find("Machines_4").SetActive(true);
            }
        }
    }
}
