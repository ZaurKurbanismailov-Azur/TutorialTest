using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Timeline
{
    [Serializable]
    public class PercentMoveBehaviour : PlayableBehaviour
    {
        private RectTransform _space;
        private RectTransform _target;

        private Vector2 _startPercentPosition;
        private Vector2 _endPercentPosition;
        private AnimationCurve _curve;
        
        
        public void Initialize(RectTransform space, RectTransform target, Vector2 startPercentPosition, Vector2 endPercentPosition, AnimationCurve curve)
        {
            _space = space;
            _target = target;
            _startPercentPosition = startPercentPosition;
            _endPercentPosition = endPercentPosition;
            _curve = curve;
        }
        
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (_space == null || _target == null)
                return;
            
            var targetParent = (RectTransform)_target.parent;
            _target.SetParent(_space, true);
            
            var playPercent = (float)(playable.GetTime() / playable.GetDuration());
            playPercent = _curve.Evaluate(playPercent);
            var percentPosition = Vector2.Lerp(_startPercentPosition, _endPercentPosition, playPercent);
            var position = _space.rect.size;
            position.Scale(percentPosition);
            _target.anchoredPosition = position;
            
            _target.SetParent(targetParent, true);
        }
    }
}