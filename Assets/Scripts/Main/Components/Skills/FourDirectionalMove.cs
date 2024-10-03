using UnityEngine;

[System.Serializable]
public class FourDirectionalMove : SkillBase
{
    public float moveSpeed = 5f;

    public Rigidbody2D Rb2D { get; set; }

    private Vector2 _movement;

    public Vector2 Movement { get => _movement; set => _movement = value; }

    public override void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();

        if (!Rb2D)
        {
            Debug.LogError("Rigidbody2D not found", SkillUser);
        }
    }

    public override void FixedUpdate()
    {
        if (Rb2D)
        {
            Rb2D.MovePosition(Rb2D.position + _movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
