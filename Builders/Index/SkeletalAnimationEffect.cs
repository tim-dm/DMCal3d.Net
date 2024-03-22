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
        public SkeletalAnimationEffect(string id) : base($"SkeletalAnimationEffect{id}") { }
        public SkeletalAnimationEffect() : base($"SkeletalAnimationEffect0") { }

        public void SetAssetName(string assetName)
        {
            XElement assetNameElement = new("AssetName")
            {
                Value = assetName
            };
            Element.Add(assetNameElement);
        }

        public EffectControls AddEffectControls()
        {
            EffectControls effectControls = new();
            Element.Add(effectControls);
            return effectControls;
        }
    }
}
