using UnityEngine;
using UnityEngine.Events;

public interface IAgentInput
{
    UnityEvent OnShootButtonPressed { get; set; }
    UnityEvent OnShootButtonReleased { get; set; }
    UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    UnityEvent<Vector2> OnPointerPositionChange { get; set; }
}