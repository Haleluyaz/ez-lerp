using UnityEngine;

/*
 * Created by C.J. Kimberlin (http://cjkimberlin.com)
 * 
 * The MIT License (MIT)
 * 
 * Copyright (c) 2015
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 * 
 * TERMS OF USE - EASING EQUATIONS
 * Open source under the BSD License.
 * Copyright (c)2001 Robert Penner
 * All rights reserved.
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
 * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
 * Neither the name of the author nor the names of contributors may be used to endorse or promote products derived from this software without specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
 * THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE 
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; 
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT 
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
/* 
 * Functions taken from Tween.js - Licensed under the MIT license
 * at https://github.com/sole/tween.js
 */
public class Easing
{
    public enum Type
    {
        EaseInQuad = 0,
        EaseOutQuad,
        EaseInOutQuad,
        EaseInCubic,
        EaseOutCubic,
        EaseInOutCubic,
        EaseInQuart,
        EaseOutQuart,
        EaseInOutQuart,
        EaseInQuint,
        EaseOutQuint,
        EaseInOutQuint,
        EaseInSine,
        EaseOutSine,
        EaseInOutSine,
        EaseInExpo,
        EaseOutExpo,
        EaseInOutExpo,
        EaseInCirc,
        EaseOutCirc,
        EaseInOutCirc,
        Linear,
        EaseInBounce,
        EaseOutBounce,
        EaseInOutBounce,
        EaseInBack,
        EaseOutBack,
        EaseInOutBack,
        EaseInElastic,
        EaseOutElastic,
        EaseInOutElastic,
    }

    //------------------------------------------------------------------------------------------------------------

    public static float Linear(float k)
    {
        return k;
    }

	//------------------------------------------------------------------------------------------------------------

    public class Quadratic
    {
        public static float In(float k)
        {
            return k * k;
        }

        public static float Out(float k)
        {
            return k * (2f - k);
        }

        public static float InOut(float k)
        {
            if ((k *= 2f) < 1f) return 0.5f * k * k;
            return -0.5f * ((k -= 1f) * (k - 2f) - 1f);
        }
    };

	//------------------------------------------------------------------------------------------------------------

    public class Cubic
    {
        public static float In(float k)
        {
            return k * k * k;
        }

        public static float Out(float k)
        {
            return 1f + ((k -= 1f) * k * k);
        }

        public static float InOut(float k)
        {
            if ((k *= 2f) < 1f) return 0.5f * k * k * k;
            return 0.5f * ((k -= 2f) * k * k + 2f);
        }
    };

	//------------------------------------------------------------------------------------------------------------

    public class Quartic
    {
        public static float In(float k)
        {
            return k * k * k * k;
        }

        public static float Out(float k)
        {
            return 1f - ((k -= 1f) * k * k * k);
        }

        public static float InOut(float k)
        {
            if ((k *= 2f) < 1f) return 0.5f * k * k * k * k;
            return -0.5f * ((k -= 2f) * k * k * k - 2f);
        }
    };

	//------------------------------------------------------------------------------------------------------------

    public class Quintic
    {
        public static float In(float k)
        {
            return k * k * k * k * k;
        }

        public static float Out(float k)
        {
            return 1f + ((k -= 1f) * k * k * k * k);
        }

        public static float InOut(float k)
        {
            if ((k *= 2f) < 1f) return 0.5f * k * k * k * k * k;
            return 0.5f * ((k -= 2f) * k * k * k * k + 2f);
        }
    };

	//------------------------------------------------------------------------------------------------------------

    public class Sinusoidal
    {
        public static float In(float k)
        {
            return 1f - Mathf.Cos(k * Mathf.PI / 2f);
        }

        public static float Out(float k)
        {
            return Mathf.Sin(k * Mathf.PI / 2f);
        }

        public static float InOut(float k)
        {
            return 0.5f * (1f - Mathf.Cos(Mathf.PI * k));
        }
    };

	//------------------------------------------------------------------------------------------------------------

    public class Exponential
    {
        public static float In(float k)
        {
            return k == 0f ? 0f : Mathf.Pow(1024f, k - 1f);
        }

        public static float Out(float k)
        {
            return k == 1f ? 1f : 1f - Mathf.Pow(2f, -10f * k);
        }

        public static float InOut(float k)
        {
            if (k == 0f) return 0f;
            if (k == 1f) return 1f;
            if ((k *= 2f) < 1f) return 0.5f * Mathf.Pow(1024f, k - 1f);
            return 0.5f * (-Mathf.Pow(2f, -10f * (k - 1f)) + 2f);
        }
    };

	//------------------------------------------------------------------------------------------------------------

    public class Circular
    {
        public static float In(float k)
        {
            return 1f - Mathf.Sqrt(1f - k * k);
        }

        public static float Out(float k)
        {
            return Mathf.Sqrt(1f - ((k -= 1f) * k));
        }

        public static float InOut(float k)
        {
            if ((k *= 2f) < 1f) return -0.5f * (Mathf.Sqrt(1f - k * k) - 1);
            return 0.5f * (Mathf.Sqrt(1f - (k -= 2f) * k) + 1f);
        }
    };

	//------------------------------------------------------------------------------------------------------------

    public class Elastic
    {
        public static float In(float k)
        {
            if (k == 0) return 0;
            if (k == 1) return 1;
            return -Mathf.Pow(2f, 10f * (k -= 1f)) * Mathf.Sin((k - 0.1f) * (2f * Mathf.PI) / 0.4f);
        }

        public static float Out(float k)
        {
            if (k == 0) return 0;
            if (k == 1) return 1;
            return Mathf.Pow(2f, -10f * k) * Mathf.Sin((k - 0.1f) * (2f * Mathf.PI) / 0.4f) + 1f;
        }

        public static float InOut(float k)
        {
            if ((k *= 2f) < 1f) return -0.5f * Mathf.Pow(2f, 10f * (k -= 1f)) * Mathf.Sin((k - 0.1f) * (2f * Mathf.PI) / 0.4f);
            return Mathf.Pow(2f, -10f * (k -= 1f)) * Mathf.Sin((k - 0.1f) * (2f * Mathf.PI) / 0.4f) * 0.5f + 1f;
        }
    };

	//------------------------------------------------------------------------------------------------------------

    public class Back
    {
        static float s = 1.70158f;
        static float s2 = 2.5949095f;

        public static float In(float k)
        {
            return k * k * ((s + 1f) * k - s);
        }

        public static float Out(float k)
        {
            return (k -= 1f) * k * ((s + 1f) * k + s) + 1f;
        }

        public static float InOut(float k)
        {
            if ((k *= 2f) < 1f) return 0.5f * (k * k * ((s2 + 1f) * k - s2));
            return 0.5f * ((k -= 2f) * k * ((s2 + 1f) * k + s2) + 2f);
        }
    };

    //------------------------------------------------------------------------------------------------------------

    public class Bounce
    {
        public static float In(float k)
        {
            return 1f - Out(1f - k);
        }

        public static float Out(float k)
        {
            if (k < (1f / 2.75f))
            {
                return 7.5625f * k * k;
            }
            else if (k < (2f / 2.75f))
            {
                return 7.5625f * (k -= (1.5f / 2.75f)) * k + 0.75f;
            }
            else if (k < (2.5f / 2.75f))
            {
                return 7.5625f * (k -= (2.25f / 2.75f)) * k + 0.9375f;
            }
            else
            {
                return 7.5625f * (k -= (2.625f / 2.75f)) * k + 0.984375f;
            }
        }

        public static float InOut(float k)
        {
            if (k < 0.5f) return In(k * 2f) * 0.5f;
            return Out(k * 2f - 1f) * 0.5f + 0.5f;
        }
    };

    //------------------------------------------------------------------------------------------------------------

    public static float GetEasingFunction(Type easingFunction, float t)
    {
        // Quad
        if (easingFunction == Type.EaseInQuad)
        {
            return Quadratic.In(t);
        }

        if (easingFunction == Type.EaseOutQuad)
        {
            return Quadratic.Out(t);
        }

        if (easingFunction == Type.EaseInOutQuad)
        {
            return Quadratic.InOut(t);
        }

        // Cubic
        if (easingFunction == Type.EaseInCubic)
        {
            return Cubic.In(t);
        }

        if (easingFunction == Type.EaseOutCubic)
        {
            return Cubic.Out(t);
        }

        if (easingFunction == Type.EaseInOutCubic)
        {
            return Cubic.InOut(t);
        }

        // Quart
        if (easingFunction == Type.EaseInQuart)
        {
            return Quartic.In(t);
        }

        if (easingFunction == Type.EaseOutQuart)
        {
            return Quartic.Out(t); ;
        }

        if (easingFunction == Type.EaseInOutQuart)
        {
            return Quartic.InOut(t); ;
        }

        // Quint
        if (easingFunction == Type.EaseInQuint)
        {
            return Quintic.In(t);
        }

        if (easingFunction == Type.EaseOutQuint)
        {
            return Quintic.Out(t);
        }

        if (easingFunction == Type.EaseInOutQuint)
        {
            return Quintic.InOut(t);
        }

        // Sine
        if (easingFunction == Type.EaseInSine)
        {
            return Sinusoidal.In(t);
        }

        if (easingFunction == Type.EaseOutSine)
        {
            return Sinusoidal.Out(t);
        }

        if (easingFunction == Type.EaseInOutSine)
        {
            return Sinusoidal.InOut(t);
        }

        // Expo
        if (easingFunction == Type.EaseInExpo)
        {
            return Exponential.In(t);
        }

        if (easingFunction == Type.EaseOutExpo)
        {
            return Exponential.Out(t);
        }

        if (easingFunction == Type.EaseInOutExpo)
        {
            return Exponential.InOut(t);
        }

        // CirC
        if (easingFunction == Type.EaseInCirc)
        {
            return Circular.In(t);
        }

        if (easingFunction == Type.EaseOutCirc)
        {
            return Circular.Out(t);
        }

        if (easingFunction == Type.EaseInOutCirc)
        {
            return Circular.InOut(t);
        }

        // Linear
        if (easingFunction == Type.Linear)
        {
            return Linear(t);
        }

        //  Bounce
        if (easingFunction == Type.EaseInBounce)
        {
            return Bounce.In(t);
        }

        if (easingFunction == Type.EaseOutBounce)
        {
            return Bounce.Out(t);
        }

        if (easingFunction == Type.EaseInOutBounce)
        {
            return Bounce.InOut(t);
        }

        // Back
        if (easingFunction == Type.EaseInBack)
        {
            return Back.In(t);
        }

        if (easingFunction == Type.EaseOutBack)
        {
            return Back.Out(t);
        }

        if (easingFunction == Type.EaseInOutBack)
        {
            return Back.InOut(t);
        }

        // Elastic
        if (easingFunction == Type.EaseInElastic)
        {
            return Elastic.In(t);
        }

        if (easingFunction == Type.EaseOutElastic)
        {
            return Elastic.Out(t);
        }

        if (easingFunction == Type.EaseInOutElastic)
        {
            return Elastic.InOut(t);
        }

        return 0;
    }
}