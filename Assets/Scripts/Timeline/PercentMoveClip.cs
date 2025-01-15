using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;
using UnityEngine.Timeline;

namespace Timeline
{
    [Serializable]
    public class PercentMoveClip : PlayableAsset, ITimelineClipAsset
    {
        public ClipCaps clipCaps => ClipCaps.None;

        [SerializeField] private ExposedReference<RectTransform> _space;
        [SerializeField] private ExposedReference<RectTransform> _target;

        [SerializeField] private Vector2 _startPercentPosition;
        [SerializeField] private Vector2 _endPercentPosition;
        [SerializeField] private AnimationCurve _curve;
        
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var behaviour = new PercentMoveBehaviour();
            var space = _space.Resolve(graph.GetResolver());
            var target = _target.Resolve(graph.GetResolver());
            behaviour.Initialize(space, target, _startPercentPosition, _endPercentPosition, _curve);
            
            return ScriptPlayable<PercentMoveBehaviour>.Create(graph, behaviour);
        }
    }
}