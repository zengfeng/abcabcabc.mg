using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PostCameraEvent : MonoBehaviour
{
    private List<BasePostEffects> _postEffects = new List<BasePostEffects>();

    void Start()
    {
    
    }
    
    void Update()
    {
    
    }

    void OnPostRender()
    {
        foreach (BasePostEffects effect in _postEffects)
        {
            effect.OnPostRenderFromCamera();
        }
    }

    public void AddPostEffect(BasePostEffects effect)
    {
        _postEffects.Add(effect);
    }
}
