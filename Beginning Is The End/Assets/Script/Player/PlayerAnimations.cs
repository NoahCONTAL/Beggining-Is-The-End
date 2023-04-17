using UnityEngine;
using Unity.Netcode;

public class PlayerAnimations : NetworkBehaviour
{
   [SerializeField]
   private Animator anim;
   
   private void Update()
   {
      if (!IsOwner) return;

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
