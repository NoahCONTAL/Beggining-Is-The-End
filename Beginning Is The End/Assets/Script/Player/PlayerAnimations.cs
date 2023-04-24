using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Update()
    {
        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && !Input.GetButton("Sprint"))
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && Input.GetButton("Sprint"))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}