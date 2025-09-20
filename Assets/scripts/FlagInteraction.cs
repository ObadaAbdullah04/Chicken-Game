using UnityEngine;

public class FlagInteraction : MonoBehaviour
{
    public Animator flagAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            flagAnimator.SetTrigger("FlagTouched");
        }
    }
}
