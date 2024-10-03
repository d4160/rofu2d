using UnityEngine;

public class ContiGuyInput : InputBase<ContiGuy>
{
    void Update()
    {
        Vector2 movement;

        // Capturar input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalizar el vector de movimiento para evitar velocidad diagonal mayor
        movement.Normalize();

        _entity.SetMoveInput(movement);
    }
}
