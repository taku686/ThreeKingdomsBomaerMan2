using UnityEngine;

public class ArrowSkillIndicatorView : MonoBehaviour
{
    private Material _material;
    private const float ArrowWidthRate = 0.2f;
    private float _defaultOffsetY;

    public void Setup(float range)
    {
        if (_material == null)
        {
            _material = GetComponent<Renderer>().material;
            _defaultOffsetY = _material.mainTextureOffset.y;
        }

        transform.localPosition = new Vector3(0, 0.2f, range * 0.5f);
        transform.localEulerAngles = new Vector3(90, 0, 0);
        transform.localScale = new Vector3(range * ArrowWidthRate, range, 1);
        NoEnemyHit();
    }

    public void UpdateIndicatorLength(float range)
    {
        if (_material == null)
        {
            return;
        }

        var length = range * _defaultOffsetY / transform.localScale.y;
        _material.mainTextureOffset = new Vector2(0, length);
    }

    public void NoEnemyHit()
    {
        SetColor(Color.red);
    }

    public void EnemyHit()
    {
        SetColor(Color.green);
    }

    private void SetColor(Color color)
    {
        if (_material != null)
        {
            _material.color = color;
        }
    }

    private void OnDestroy()
    {
        if (_material != null)
        {
            Destroy(_material);
        }
    }
}