using UnityEditor;

[CustomEditor(typeof(PolygonColliderAnimator))]
public class PolygonColliderAnimatorEditor : Editor
{
    private void OnEnable()
    {
        var PCAscript = (PolygonColliderAnimator)target;
        PCAscript.SetReferences();
        PCAscript.RegisterCallback();
    }
}
