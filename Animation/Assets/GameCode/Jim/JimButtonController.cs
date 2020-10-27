using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class JimButtonController : MonoBehaviour
{
    private Animator anim;
    private int flyFloat = Animator.StringToHash("Fly");
    private int scaleFloat = Animator.StringToHash("Scale");
    private int shakeFloat = Animator.StringToHash("Shake");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PickRandomAnimation()
    {
        var rand = Random.Range(0.0f, 1.0f);
        anim.SetFloat(flyFloat, rand);
        rand = Random.Range(0.0f, 1.0f);
        anim.SetFloat(scaleFloat, rand);
        rand = Random.Range(0.0f, 1.0f);
        anim.SetFloat(shakeFloat, rand);
    }
}
