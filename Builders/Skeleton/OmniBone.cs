﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCal3d.Net.Builders.Skeleton
{
    public class OmniBone : Bone
    {
        private const string LightTypeAttributeName = "LIGHTTYPE";
        private const string LightColorAttributeName = "LIGHTCOLOR";

        public void SetLightType(int value)
        {
            SetAttribute(LightTypeAttributeName, value);
        }

        public void SetLightColor(int lightColorR, int lightColorG, int lightColorB)
        {
            SetAttribute(LightColorAttributeName, $"{lightColorR} {lightColorG} {lightColorB}");
        }
    }
}
