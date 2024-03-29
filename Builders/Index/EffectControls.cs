using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Index
{
    public enum EffectCompositionFunctions
    {
        EffectCompositionFunctionReplace
    }

    public class EffectControls : Node
    {
        public const string TagName = "EffectControls";
        public const string EffectCompositionFunctionTagName = "EffectCompositionFunction";
        public const string LoopIterationsTagName = "LoopIterations";
        public const string PlaybackSpeedScaleTagName = "PlaybackSpeedScale";

        public EffectControls() : base(TagName) { }

        public XElement CreateEffectCompositionFunction(EffectCompositionFunctions compositionFunction)
        {
            XElement effectCompositionFunction = new(EffectCompositionFunctionTagName) { Value = compositionFunction.ToString() };
            Element.Add(effectCompositionFunction);
            return effectCompositionFunction;
        }

        public XElement CreateLoopIterations(string num)
        {
            XElement loopIterationsElement = new(LoopIterationsTagName) { Value = num };
            Element.Add(loopIterationsElement);
            return loopIterationsElement;
        }

        public XElement CreatePlaybackSpeedScale(string num)
        {
            XElement playbackSpeedScaleElement = new(PlaybackSpeedScaleTagName) { Value = num };
            Element.Add(playbackSpeedScaleElement);
            return playbackSpeedScaleElement;
        }
    }
}
