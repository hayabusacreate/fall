using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectS : MonoBehaviour
{
    public Material sepia
        ;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, sepia);
    }
}
