using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
   [SerializeField]
   private Animator anim;
   
   private void Update()
   {
      
      if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) && !Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("Walk", true);
      }
      else
      {
         anim.SetBool("Walk", false);
      }
      
      if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) && Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("Run", true);
      }
      else
      {
         anim.SetBool("Run", false);
      }
   }
}
