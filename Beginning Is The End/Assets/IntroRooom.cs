using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroRooom : MonoBehaviour
{
    private bool Room1;
    [SerializeField] private GameObject Texte1;
    private bool Room2;
    [SerializeField] private GameObject Texte2;
    private bool Room3;
    [SerializeField] private GameObject Texte3;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 1" && !Room1)
        {
            Texte1.SetActive(true);
            Room1 = Texte1.GetComponent<TypeWriter>().isFinished;
        }
        else if (SceneManager.GetActiveScene().name == "Level 1" && Room1)
        {
            Texte1.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Level 2" && !Room2)
        {
            Texte2.SetActive(true);
            Room2 = Texte2.GetComponent<TypeWriter>().isFinished;
        }
        else if (SceneManager.GetActiveScene().name == "Level 2" && Room2)
        {
            Texte2.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Level 3" && !Room3)
        {
            Texte3.SetActive(true);
            Room3 = Texte3.GetComponent<TypeWriter>().isFinished;
        }
        else if (SceneManager.GetActiveScene().name == "Level 3" && Room3)
        {
            Texte3.SetActive(false);
        }
    }
}
