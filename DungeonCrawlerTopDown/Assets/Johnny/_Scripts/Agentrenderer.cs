using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Agentrenderer : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    public void FaceDirection(Vector2 pointerInput)
    {
        var direction = (Vector3)pointerInput - transform.position;
        var result = Vector3.Cross(Vector2.up, direction);

        if (result.z > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (result.z < 0)
        {
            spriteRenderer.flipX = false;
        }

    }



}
