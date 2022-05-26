
using UnityEngine;

public class IdleLogic : MonoBehaviour
{
    private Animator animator = new Animator();
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    { 
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))

            PlayerMovement.isAttacking = false;
    }
}
