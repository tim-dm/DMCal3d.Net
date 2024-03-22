using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCal3d.Net.Builders.Index
{
    public class SkeletalAnimationEffect : Node
    {
        public SkeletalAnimationEffect(string id) : base($"SkeletalAnimationEffect{id}") { }
        public SkeletalAnimationEffect() : base($"SkeletalAnimationEffect0") { }
    }
}
