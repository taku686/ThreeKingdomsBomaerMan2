/*
 The MIT License (MIT)

Copyright (c) 2013 yamamura tatsuhiko

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FadeImage : UnityEngine.UI.Graphic, IFade
{
    private Texture _maskTexture;
    private readonly Gradient _gradient = new();
    [SerializeField, Range(0, 1)] private float cutoutRange;
    [SerializeField] private List<Color> colorList = new();
    [SerializeField] private List<Texture> maskTextureList = new();
    [SerializeField] private Material cutoutMaterial;
    private static readonly int Range1 = Shader.PropertyToID("_Range");
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private static readonly int MaskTex = Shader.PropertyToID("_MaskTex");

    public float Range
    {
        get { return cutoutRange; }
        set
        {
            cutoutRange = value;
            UpdateMaskCutout(cutoutRange);
        }
    }

    public void UpdateMaskCutout(float range)
    {
        enabled = true;
        material.SetFloat(Range1, 1 - range);
        if (_gradient != null)
        {
            material.SetColor(Color1, _gradient.Evaluate(1 - range));
        }

        if (range <= 0)
        {
            this.enabled = false;
        }
    }

    public void UpdateMaskTexture(Texture texture)
    {
        material.SetTexture(MaskTex, texture);
        material.SetColor(Color1, _gradient.Evaluate(0));
    }

    public void SetRandomColor()
    {
        var index = Random.Range(0, colorList.Count);
        var index2 = Random.Range(0, colorList.Count);
        var colorKey = new GradientColorKey[2];
        colorKey[0].color = colorList[index];
        ProjectCommonData.Instance.fadeInColor = colorList[index];
        colorKey[0].time = 0.0f;
        colorKey[1].color = colorList[index2];
        ProjectCommonData.Instance.fadeOutColor = colorList[index2];
        colorKey[1].time = 1.0f;
        var alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.5f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;
        _gradient.SetKeys(colorKey, alphaKey);
    }

    public void SetColor(Color fadeInColor, Color fadeOutColor)
    {
        var colorKey = new GradientColorKey[2];
        colorKey[0].color = fadeInColor;
        colorKey[0].time = 0.0f;
        colorKey[1].color = fadeOutColor;
        colorKey[1].time = 1.0f;
        var alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.5f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;
        _gradient.SetKeys(colorKey, alphaKey);
    }

    public void SetRandomMaskTexture()
    {
        var index = Random.Range(0, maskTextureList.Count);
        _maskTexture = maskTextureList[index];
        ProjectCommonData.Instance.maskTextureIndex = index;
        UpdateMaskTexture(_maskTexture);
    }

    public void SetMaskTexture(int index)
    {
        _maskTexture = maskTextureList[index];
        UpdateMaskTexture(_maskTexture);
    }

#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
        UpdateMaskCutout(Range);
        UpdateMaskTexture(_maskTexture);
    }
#endif
}