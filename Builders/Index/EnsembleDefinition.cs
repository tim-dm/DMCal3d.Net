using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCal3d.Net.Builders.Index
{
    public class EnsembleDefinition : Node
    {
        public const string TagName = "EnsembleDefinition";

        public EnsembleDefinition(string id) : base($"{TagName}{id}") { }

        public EnsembleDefinition() : base($"{TagName}0") { }

        public void SetId(string id)
        {
            Element.Name = $"{TagName}{id}";
        }

        public SkeletalAnimationEffect CreateSkeletalAnimationEffect()
        {
            SkeletalAnimationEffect effect = new();
            Element.Add(effect.Element);
            return effect;
        }
    }
}
