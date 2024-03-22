using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCal3d.Net.Builders.Index
{
    public class EnsembleDefinition : Node
    {
        public EnsembleDefinition(string id) : base($"EnsembleDefinition{id}") { }

        public EnsembleDefinition() : base($"EnsembleDefinition0") { }

        public void SetId(string id)
        {
            Element.Name = $"EnsembleDefinition{id}";
        }

        public SkeletalAnimationEffect AddSkeletalAnimationEffect()
        {
            SkeletalAnimationEffect skeletalAnimationEffect = new();
            Element.Add(skeletalAnimationEffect);
            return skeletalAnimationEffect;
        }
    }
}
