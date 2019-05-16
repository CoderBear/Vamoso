using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EndScreen : MonoBehaviour
{
    public PostProcessProfile blurProfile;
    public PostProcessProfile normalProfile;
    public PostProcessVolume cameraPostProcess;

    public void EnableCameraBlur(bool state)
    {
        if(cameraPostProcess != null && blurProfile != null && normalProfile != null)
        {
            cameraPostProcess.profile = (state) ? blurProfile : normalProfile;
        }
    }
}
