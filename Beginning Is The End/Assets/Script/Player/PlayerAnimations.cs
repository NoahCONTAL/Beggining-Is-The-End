using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
   [SerializeField]
   private Animator anim;
   
   private void Update()
   {
      
      if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("WalkFront", true);
      }
      else
      {
         anim.SetBool("WalkFront", false);
      }
      
      if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("RunFront", true);
      }
      else
      {
         anim.SetBool("RunFront", false);
      }
   }
}
