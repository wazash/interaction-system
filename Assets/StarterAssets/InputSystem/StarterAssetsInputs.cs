using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        [Header("Tool Manager")]
        public ToolManager toolManager;
        public int toolIndex;
        public float maxInteractionDistance = 5f;

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

        /** TOOL INPUTS **/

        public void OnSwitchTool(InputValue value)
        {
            if (value.Get<Vector2>().y > 0)
            {
                SwitchTool(toolIndex + 1);
            }
            else if (value.Get<Vector2>().y < 0)
            {
                SwitchTool(toolIndex - 1);
            }
        }

        public void OnSelectTool1(InputValue value)
        {
            SwitchTool(0);
        }
        public void OnSelectTool2(InputValue value)
        {
            SwitchTool(1);
        }
        public void OnSelectTool3(InputValue value)
        {
            SwitchTool(2);
        }

        public void OnUseTool(InputValue value)
        {
            UseTool();
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

        /** TOOL METHODS **/

        public void SwitchTool(float toolIndex)
        {
            toolManager.SwitchTool((int)toolIndex);
            this.toolIndex = toolManager.CurrentToolIndex;
        }

        public void UseTool()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, maxInteractionDistance))
            {
                GameObject target = hit.collider.gameObject;
                toolManager.UseTool(target);
            }
        }
    }
}
