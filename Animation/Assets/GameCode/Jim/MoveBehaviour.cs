using UnityEngine;

public class MoveBehaviour : StateMachineBehaviour
{
    [SerializeField] float idleTimerValue = 5.0f;
    private float timer = 0.0f;
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > idleTimerValue)
        {
            EventManager.OnIdleStay();
            timer = 0.0f;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0.0f;
    }
}
