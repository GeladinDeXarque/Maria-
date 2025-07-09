using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AranduGames.FinalCharacterController
{
    public class PlayerState : MonoBehaviour
    {
        [field: SerializeField] public PlayerMovementState CurrentPlayerMovementState { get; private set; } = PlayerMovementState.Idling;

        public void SetPlayerMovementState(PlayerMovementState playerMovementState)
        {
            CurrentPlayerMovementState = playerMovementState;
        }

        public bool InGroundedState()
        {
            return IsStateGroundedState(CurrentPlayerMovementState);
        }

        public bool IsStateGroundedState(PlayerMovementState MovementState)
        {
            return MovementState == PlayerMovementState.Idling ||
                   MovementState == PlayerMovementState.Walking ||
                   MovementState == PlayerMovementState.Running ||
                   MovementState == PlayerMovementState.Sprinting ||
                   MovementState == PlayerMovementState.Strafing;
        }
    }    
        public enum PlayerMovementState
        {
            Idling = 0,
            Walking = 1,
            Running = 2,
            Sprinting = 3,
            Jumping = 4,
            Falling = 5,
            Strafing = 6,
        }
    }