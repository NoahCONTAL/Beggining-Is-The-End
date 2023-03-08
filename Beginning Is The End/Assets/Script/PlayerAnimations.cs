
using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
   [SerializeField]
   private Animator anim;

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
      if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("WalkBack", true);
      }
      else
      {
         anim.SetBool("WalkBack", false);
      }
      
      if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("Left", true);
      }
      else
      {
         anim.SetBool("Left", false);
      }
      if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("Right", true);
      }
      else
      {
         anim.SetBool("Right", false);
      }
      
      if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("RunFront", true);
      }
      else
      {
         anim.SetBool("RunFront", false);
      }
      if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("RunBack", true);
      }
      else
      {
         anim.SetBool("RunBack", false);
      }
      if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("Left 0", true);
      }
      else
      {
         anim.SetBool("Left 0", false);
      }
      if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
      {
         anim.SetBool("Right 0", true);
      }
      else
      {
         anim.SetBool("Right 0", false);
      }
   }
}
