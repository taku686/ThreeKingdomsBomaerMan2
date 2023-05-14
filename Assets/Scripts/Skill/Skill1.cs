using System.Collections.Generic;
using Common.Data;
using UnityEngine;

public class Skill1 : SkillBase
{
    private const int AttackRange = 3;
    public List<GameObject> effectObjs = new();

    public override void Initialize(GameObject effect, Transform playerTransform)
    {
        base.Initialize(effect, playerTransform);
    }

    public override void SkillActivation()
    {
        var dir = GameCommonData.GetPlayerDirection(PlayerTransform.rotation.y);
        if (dir == Vector3.zero)
        {
            return;
        }

        effectObjs.Clear();
        for (int i = 0; i < AttackRange; i++)
        {
            if (dir.z == 0)
            {
                var position = PlayerTransform.position;
                var createPos = new Vector3(position.x + dir.x, 0, position.z + 1 - i);
                effectObjs.Add(CreateEffectObj(createPos));
            }
            else
            {
            }
        }
    }

    public void DestroyEffectObj()
    {
        foreach (var effect in effectObjs)
        {
            Destroy(effect);
        }

        effectObjs.Clear();
    }

    private GameObject CreateEffectObj(Vector3 createPos)
    {
        var effectObj = new GameObject
        {
            transform =
            {
                position = createPos
            },
            tag = GameCommonData.BombEffectTag
        };

        var boxCollider = effectObj.AddComponent<BoxCollider>();
        boxCollider.size = Vector3.one;
        boxCollider.center = Vector3.zero;
        boxCollider.isTrigger = true;
        return effectObj;
    }
}