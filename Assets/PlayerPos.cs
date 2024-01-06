using UnityEngine;
using UnityEngine.VFX;

public class PlayerPos : MonoBehaviour
{
        public VisualEffect vfxRenderer;

    // Update is called once per frame
    void Update()
    {
        vfxRenderer.SetVector3("PlayerPos", transform.position);
    }
}