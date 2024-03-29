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
        public EffectControls() : base("EffectControls") { }

        public XElement CreateEffectCompositionFunction(EffectCompositionFunctions compositionFunction)
        {
            XElement effectCompositionFunction = new("EffectCompositionFunction") { Value = compositionFunction.ToString() };
            Element.Add(effectCompositionFunction);
            return effectCompositionFunction;
        }

        public XElement CreateLoopIterations(string num)
        {
            XElement loopIterationsElement = new("LoopIterations") { Value = num };
            Element.Add(loopIterationsElement);
            return loopIterationsElement;
        }

        public XElement CreatePlaybackSpeedScale(string num)
        {
            XElement playbackSpeedScaleElement = new("PlaybackSpeedScale") { Value = num };
            Element.Add(playbackSpeedScaleElement);
            return playbackSpeedScaleElement;
        }
    }
}
