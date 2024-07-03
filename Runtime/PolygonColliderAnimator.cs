using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PolygonColliderAnimator : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private PolygonCollider2D _polygonCollider;
    private UnityAction<SpriteRenderer> _onSpriteChanged;
    private bool _isCallbackRegistered;

    private void Start()
    {
        SetReferences();
        RegisterCallback();
    }

    private void OnDisable() =>
        UnregisterCallback();

    public void SetReferences()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
        _onSpriteChanged += UpdateCollider;
    }

    public void RegisterCallback()
    {
        if (_isCallbackRegistered) return;
        _spriteRenderer.RegisterSpriteChangeCallback(_onSpriteChanged);
        _isCallbackRegistered = true;
    }

    public void UnregisterCallback()
    {
        if (!_isCallbackRegistered) return;
        _spriteRenderer.UnregisterSpriteChangeCallback(_onSpriteChanged);
        _isCallbackRegistered = false;
    }

    private void UpdateCollider(SpriteRenderer spriteRenderer)
    {
        Sprite currentSprite = spriteRenderer.sprite;
        if (!currentSprite) return;

        int pathsCount = currentSprite.GetPhysicsShapeCount();
        if (pathsCount == 0) return;

        List<Vector2>[] physicsShape = new List<Vector2>[pathsCount];
        for (int i = 0; i < pathsCount; i++)
        {
            physicsShape[i] = new List<Vector2>();
            currentSprite.GetPhysicsShape(i, physicsShape[i]);
        }

        _polygonCollider.pathCount = pathsCount;
        for (int i = 0; i < pathsCount; i++)
            _polygonCollider.SetPath(i, physicsShape[i]);
    }
}
