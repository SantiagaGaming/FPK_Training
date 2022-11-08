using UnityEngine;

namespace AosSdk.Core.PlayerModule.VRPlayer.Hands
{
    public class TeleportAnimationHandler : StateMachineBehaviour
    {
        public bool IsInTeleportState { get; private set; }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            IsInTeleportState = true;
        }
    
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            IsInTeleportState = false;
        }
    }
}
