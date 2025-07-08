using UnityEngine;

namespace Player.Common
{
    public class ComboAttack : MonoBehaviour
    {
        [SerializeField] private float _comboWindow = 0.3f; // 次の攻撃を受け付ける時間
        private int _currentComboStep;
        private float _lastAttackTime;
        private Animator _animator;

        public void Initialize(Animator animator)
        {
            if (animator == null)
            {
                Debug.LogError("Animatorコンポーネントが見つかりません。");
                enabled = false; // スクリプトを無効にする
            }

            _animator = animator;
        }

        public void UpdateComboWindow(float comboWindow)
        {
            // コンボウィンドウが過ぎたか確認し、過ぎていればリセット
            if (Time.time - _lastAttackTime > _comboWindow)
            {
                ResetCombo();
            }
        }

        public void TryCombo()
        {
            // まだコンボウィンドウ内であれば
            if (Time.time - _lastAttackTime < _comboWindow)
            {
                // 次のコンボステップへ
                _currentComboStep++;
            }
            else
            {
                // 新しいコンボを開始
                _currentComboStep = 1;
            }

            // コンボステップに応じてアニメーションを再生
            switch (_currentComboStep)
            {
                case 1:
                    _animator.Play("Attack1");
                    break;
                case 2:
                    _animator.Play("Attack2");
                    break;
                case 3:
                    _animator.Play("Attack3");
                    break;
                default:
                    // コンボの段階数を超えた場合はリセット
                    ResetCombo();
                    return;
            }

            // 最終攻撃後の処理（必要に応じて）
            if (_currentComboStep >= 3)
            {
                // 例えば、特別なエフェクトを再生したり、クールダウンに入ったりする
                Debug.Log("コンボフィニッシュ！");
                // 必要であればここでコンボをリセットしない
                ResetCombo();
            }

            // 最後の攻撃時間を更新
            _lastAttackTime = Time.time;
        }

        void ResetCombo()
        {
            _currentComboStep = 0;
            // 必要であれば、アニメーターの状態をリセットする
            // animator.SetInteger("ComboStep", 0); // アニメーターにコンボの状態を伝える場合
        }
    }
}