using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class GaussianBlurImage : BasePostEffects {

    public RawImage target;

    public int CullMaskNumber;

    public enum BlurType {
        StandardGauss = 0,
        SgxGauss = 1,
    }

    public BlurType blurType= BlurType.StandardGauss;

    [Range(0.1f, 1.0f)]
    public float sampleScale = 1;

    [Range(0.0f, 10.0f)]
    public float startBlurSize = 0.0f;

	[Range(0.0f, 10.0f)]
	public float targetBlurSize = 1.0f;

	[Range(0.0f, 10.0f)]
	public float blurSize = 0;
    
    //[Range(1, 10)]
    private int blurIterations = 1;

	public float blurTime = 0.5f;
    public bool isAutoRand = true;

    public Shader blurShader = null;
	public string cameraTag = "UICamera";
	public bool alwayRendering = false;

    private Material _blurMaterial = null;
    private RenderTexture _orginTexture = null;
    private RenderTexture _texture = null;
    private Camera _camera = null;
    private bool _firstRender = true;
    private bool _rendering = false;
	private Sequence _blurSeq = null;

    
    void Start () {
        _texture = new RenderTexture(Screen.width / 8, Screen.height / 8, 0);
        _orginTexture = new RenderTexture(Screen.width / 8, Screen.height / 8, 0);

        ClearRenderTexture(_texture);
        ClearRenderTexture(_orginTexture);

        target.texture = _texture;

        if (!string.IsNullOrEmpty(cameraTag))
		{
			_camera = GameObject.FindGameObjectWithTag(cameraTag).GetComponent<Camera>();
		}
		if (_camera == null)
		{
			Canvas canvas = GetComponentInParent<Canvas>();
			_camera = canvas.worldCamera;
		}
        Rect rect = new Rect(0, 0, Screen.width / 8, Screen.height / 8);

        alwayRendering = false;
        blurSize = targetBlurSize;
        target.color = new Color(150f / 255f, 150f / 255f, 150f / 255f, 0);
        if(isAutoRand == true)
        {
            Render();
        }
        
    }
	
	void Update () {
        if (Input.GetKeyDown("k"))
        {
//            byte[] arr = _tex.EncodeToPNG();
//            System.IO.File.WriteAllBytes("/Users/Lynx/Desktop/a.png", arr);
        }
        if (Input.GetKeyDown("l"))
        {
        }
	}

    void LateUpdate()
    {
		if (_rendering || alwayRendering)
            Render();
    }

  

    public void ClearRenderTexture(RenderTexture renderTex)
    {
        RenderTexture.active = renderTex;
        GL.Begin(GL.TRIANGLES);
        GL.Clear(true, true, new Color(0, 0, 0, 0));
        GL.End();
    }

    public override bool CheckResources () {
        CheckSupport (false);
        
        _blurMaterial = CheckShaderAndCreateMaterial (blurShader, _blurMaterial);
        
        if (!isSupported)
            ReportAutoDisable ();
        return isSupported;
    }

    public void AdvanceBlur()
    {
        gameObject.SetActive(true);
        
        _firstRender = true;
        _rendering = true;
        
        if (_blurSeq != null)
			_blurSeq.Kill();

		_blurSeq = DOTween.Sequence();
		_blurSeq.Append(
//            DOTween.To(()=>sampleScale, v=>sampleScale = v, 0.5f, 0.1f).SetEase(Ease.Linear)).
//            Append(
			DOTween.To(()=>blurSize, v=>blurSize = v, targetBlurSize, blurTime).SetEase(Ease.Linear)).
            OnComplete(()=>
            {
                    _rendering = false;
            });
    }

    public void BackBlur()
    {
        _rendering = true;

		if (_blurSeq != null)
			_blurSeq.Kill();

		_blurSeq = DOTween.Sequence();
		_blurSeq.Append(
//            DOTween.To(()=>sampleScale, v=>sampleScale = v, 1f, 0.1f).SetEase(Ease.OutCirc)).
//            Append(
			DOTween.To(()=>blurSize, v=>blurSize = v, startBlurSize, blurTime).SetEase(Ease.Linear)).
            OnComplete(()=>
                {
                    gameObject.SetActive(false);
                    _rendering = false;
                });

    }

    [ContextMenu("RenderForce")]
    public void RenderForce()
    {
        _firstRender = true;
        target.color = new Color(150f / 255f, 150f / 255f, 150f / 255f, 0);
        Render();
    }

    public void Render () {

        if (_firstRender)
        {
            RenderTexture last = RenderTexture.active;
            int lastMask = _camera.cullingMask;
            //_camera.cullingMask = 1 << 2;

            RenderTexture.active = _orginTexture;
            _camera.targetTexture = _orginTexture;
            _camera.Render();

            RenderTexture.active = _texture;
            _camera.targetTexture = _texture;
            _camera.Render();

            _camera.targetTexture = null;
            _camera.cullingMask = lastMask;
            //RenderTexture.active = last;
            RenderTexture.active = null;
            _firstRender = false;

            target.color = new Color(150f / 255f, 150f / 255f, 150f / 255f, 1);
            //return;
        }
        if (target == null)
            return;

        if (!CheckResources())
            return;

        _texture.filterMode = FilterMode.Bilinear;
        
        int rtW = (int)(_texture.width * sampleScale);
        int rtH = (int)(_texture.height * sampleScale);

        RenderTexture rt = RenderTexture.GetTemporary (rtW, rtH, 0, _texture.format);
        
        rt.filterMode = FilterMode.Bilinear;
        Graphics.Blit (_orginTexture, rt);

        var passOffs = blurType == BlurType.StandardGauss ? 0 : 2;
        
        for(int i = 0; i < blurIterations; i++) {
            float iterationOffs = (i*1.0f);
            _blurMaterial.SetVector ("_Parameter", new Vector4 (blurSize + iterationOffs*(blurSize/2), -blurSize - iterationOffs*(blurSize/2), 0.0f, 0.0f));
            
            RenderTexture rt2 = RenderTexture.GetTemporary (rtW, rtH, 0, _texture.format);
            rt2.filterMode = FilterMode.Bilinear;
            Graphics.Blit (rt, rt2, _blurMaterial, 1 + passOffs);
            RenderTexture.ReleaseTemporary (rt);
            rt = rt2;
            
            rt2 = RenderTexture.GetTemporary (rtW, rtH, 0, _texture.format);
            rt2.filterMode = FilterMode.Bilinear;
            Graphics.Blit (rt, rt2, _blurMaterial, 2 + passOffs);
            RenderTexture.ReleaseTemporary (rt);
            rt = rt2;
        }

        Graphics.Blit (rt, _texture);

        RenderTexture.ReleaseTemporary (rt);
    }
}
