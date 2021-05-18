using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaglyphEffect : MonoBehaviour
{
   public Shader fxShader;
    public Camera leftEye;
    public float stereoWidth = 1.0f;
    public float distEye = 0.1f; 

    private Material environmentMaterial;
    private RenderTexture renderTexture;

    private void Start()
    {
        // set verticality
        transform.localEulerAngles = Vector3.up * stereoWidth;
        leftEye.transform.localEulerAngles = Vector3.up * -stereoWidth;

        // set eyes
        transform.localPosition = Vector3.right * distEye;
        leftEye.transform.localPosition = Vector3.right * -distEye;
    }

    private void OnEnable()
    {
        // Prevent errors.
        int w = Screen.width, h = Screen.height;
        if (fxShader == null || w == 0 || h == 0) {
            enabled = false;
            return;
        }

        // Initialise materials used for blitting.
        environmentMaterial = new Material(fxShader);
        environmentMaterial.hideFlags = HideFlags.HideAndDontSave;
        leftEye.enabled = false;

        // Initialse render texture.
        renderTexture = new RenderTexture(w, h, 8, RenderTextureFormat.Default);
        leftEye.targetTexture = renderTexture;
    }

    private void OnDisable()
    {
        // Clean up resources.
        if (environmentMaterial != null) { DestroyImmediate(environmentMaterial); }
        if (renderTexture != null) { renderTexture.Release(); }
        leftEye.targetTexture = null;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (leftEye == null || environmentMaterial == null || renderTexture == null) {
            enabled = false;
            return;
        }

        // Render to render texture
        leftEye.Render();

        // Apply second texture to shader. 
        environmentMaterial.SetTexture("_MainTex2", renderTexture);

        // Blit !
        Graphics.Blit(source, destination, environmentMaterial);

        // Clean up RenderTexture resources.
        renderTexture.Release();
    }
}
