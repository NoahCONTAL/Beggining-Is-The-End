using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
   [SerializeField]
   private Animator anim;
   
   private bool IsNotTired(float ernegyCost)
   {
      return true;
   }
   
   private void Update()
   {
      
      if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("WalkFront", true);
      }
      else
      {
         anim.SetBool("WalkFront", false);
      }
      
      if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift) && IsNotTired(0.1f))
      {
         anim.SetBool("RunFront", true);
      }
      else
      {
         anim.SetBool("RunFront", false);
      }
   }
}
