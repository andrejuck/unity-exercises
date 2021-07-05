using UnityEngine;

public class AnimatedPanel : MonoBehaviour
{
    public Animator animator;
    public void Toggle()
    {
        animator.SetTrigger("Toggle");
    }
}
