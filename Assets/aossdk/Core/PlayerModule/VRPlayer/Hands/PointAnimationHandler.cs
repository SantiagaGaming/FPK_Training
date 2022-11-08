using UnityEngine;

namespace AosSdk.Core.PlayerModule.VRPlayer.Hands
{
    public class PointAnimationHandler : StateMachineBehaviour
    {
        public bool IsInPointState { get; private set; }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            IsInPointState = true;
        }
    
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            IsInPointState = false;
        }
    }
}
