using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMCal3d.Net.Builders.Index
{
    

    public class SkeletalAnimationEffect : Node
    {
        private const string SkeletalAnimationEffectElementName = "SkeletalAnimationEffect";

        public SkeletalAnimationEffect(string id) : base($"{SkeletalAnimationEffectElementName}{id}") { }
        
        public SkeletalAnimationEffect() : base($"{SkeletalAnimationEffectElementName}0") { }

        public void SetId(string id)
        {
            Element.Name = $"{SkeletalAnimationEffectElementName}{id}";
        }

        public void SetAssetName(string name)
        {
            XElement assetName = new("AssetName")
            {
                Value = name
            };
            Element.Add(assetName);
        }

        public EffectControls AddEffectControls(string loopIterations, string playbackSpeedScale)
        {
            EffectControls effectControls = new();
            Element.Add(effectControls);
            return effectControls;
        }
    }
}
