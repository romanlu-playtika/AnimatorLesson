using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class ButtonAnimationController : MonoBehaviour
{
    private Animator anim;
    private int jumpFloat = Animator.StringToHash("Jump");
    private int colorFloat = Animator.StringToHash("Color");
    private int rotationFloat = Animator.StringToHash("Rotation");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PickRandomAnimation()
    {
        var rand = Random.Range(0.0f, 1.0f);
        anim.SetFloat(jumpFloat, rand);
        rand = Random.Range(0.0f, 1.0f);
        anim.SetFloat(colorFloat, rand);
        rand = Random.Range(0.0f, 1.0f);
        anim.SetFloat(rotationFloat, rand);
    }
}
