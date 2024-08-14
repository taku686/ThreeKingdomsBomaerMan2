using UnityEngine;

public class HandMatcher : MonoBehaviour
{
    private readonly AvatarIKGoal ikGoal = AvatarIKGoal.RightHand; // IK制御を行う体の部分（今回は左手）
    [SerializeField] private Transform HandPoint;
    private Animator anim;
    public bool isEnableIK = true; // IK制御有効化フラグ
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnAnimatorIK() { // OnAnimatorIKはIK制御情報を更新する際に呼ばれるコールバック
        if (!isEnableIK)
            return;

        // 武器に作成したLeftHandPointに、左手を移動させる
        anim.SetIKPositionWeight(ikGoal, 1f);
        anim.SetIKRotationWeight(ikGoal, 1f);
        anim.SetIKPosition(ikGoal, HandPoint.position);
        anim.SetIKRotation(ikGoal, HandPoint.rotation);
    }
}