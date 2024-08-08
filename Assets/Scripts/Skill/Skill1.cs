using System.Collections.Generic;
using Common.Data;
using UnityEngine;
using UnityEngine.Serialization;

public class Skill1 : SkillBase
{
    private const int AttackRange = 3;
    public List<GameObject> colliderObjs = new();

    public override void SkillActivation()
    {
        var dir = GameCommonData.GetPlayerDirection(PlayerTransform.rotation.y);
        if (dir == Vector3.zero)
        {
            return;
        }

        colliderObjs.Clear();
        for (int i = 0; i < AttackRange; i++)
        {
            if (dir.z == 0)
            {
                var position = PlayerTransform.position;
                var createPos = new Vector3(position.x + dir.x, 0, position.z + dir.z * (1 - i));
                colliderObjs.Add(CreateColliderObj(createPos));
            }
            else
            {
                var position = PlayerTransform.position;
                var createPos = new Vector3(position.x + dir.x * (1 - i), 0, position.z + dir.z);
                colliderObjs.Add(CreateColliderObj(createPos));
            }
        }
    }

    private GameObject CreateColliderObj(Vector3 createPos)
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