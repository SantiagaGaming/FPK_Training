using UnityEngine;

namespace AosSdk.Core.PlayerModule.VRPlayer.Hands
{
    public class UseAnimationHandler : StateMachineBehaviour
    {
        public bool IsInUseState { get; private set; }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            IsInUseState = true;
        }
    
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            IsInUseState = false;
        }
    }
}
