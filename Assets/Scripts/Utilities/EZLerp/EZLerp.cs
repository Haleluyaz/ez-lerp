/*
Copyright 2017, Nattapon (Pond) Chaiyasirisuwan, All rights reserved.
 __  __  ______  __      ______  __      __  __  __  __  ______    
/\ \_\ \/\  __ \/\ \    /\  ___\/\ \    /\ \/\ \/\ \_\ \/\  __ \   
\ \  __ \ \  __ \ \ \___\ \  __\\ \ \___\ \ \_\ \ \____ \ \  __ \  
 \ \_\ \_\ \_\ \_\ \_____\ \_____\ \_____\ \_____\/\_____\ \_\ \_\ 
  \/_/\/_/\/_/\/_/\/_____/\/_____/\/_____/\/_____/\/_____/\/_/\/_/     

 */
using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Super Easy Lerp Tools
/// Easing Reference : http://easings.net/
/// </summary>
public class EZLerp : MonoBehaviour
{
    //------------------------------------------------------------------------------------------------------------
    public enum TransformType
    {
        None = -1,
        Position,
        Rotation,
        Scale
    }

    //------------------------------------------------------------------------------------------------------------
    public static EZLerp Instance = null;

    //------------------------------------------------------------------------------------------------------------
    void Awake()
    {
        Instance = this;
    }
    //------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Lerp Vector3
    /// </summary>
    /// <param name="transformType">Position, Rotation, Scale</param>
    /// <param name="easingType">Make lerping more realistic by picking the right easing function</param>
    /// <param name="myTransform">Target transform</param>
    /// <param name="startPos">Vector3 Start Position</param>
    /// <param name="endPos">Vector3 End Position</param>
    /// <param name="duration">Lerp Time</param>
    /// <param name="isLocal">If you would like to lerp in local position, use true.</param>
    /// <param name="delay">Delay before function start</param>
    /// <param name="callback">Action call at the end of function</param>
    public void Lerp(TransformType transformType, Easing.Type easingType, Transform myTransform, Vector3 startPos, Vector3 endPos, float duration, bool isLocal, float delay, Action callback)
    {
        StartCoroutine(COLerp(transformType, easingType, myTransform, startPos, endPos, duration, isLocal, delay, callback));
    }

    //------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Lerp Vector2
    /// </summary>
    /// <param name="transformType">Position, Rotation, Scale</param>
    /// <param name="easingType">Make lerping more realistic by picking the right easing function</param>
    /// <param name="myTransform">Target transform</param>
    /// <param name="startPos">Vector2 Start Position</param>
    /// <param name="endPos">Vector2 End Position</param>
    /// <param name="duration">Lerp Time</param>
    /// <param name="isLocal">If you would like to lerp in local position, use true.</param>
    /// <param name="delay">Delay before function start</param>
    /// <param name="callback">Action call at the end of function</param>
    public void Lerp(TransformType transformType, Easing.Type easingType, Transform myTransform, Vector2 startPos, Vector2 endPos, float duration, bool isLocal, float delay, Action callback)
    {
        StartCoroutine(COLerp(transformType, easingType, myTransform, startPos, endPos, duration, isLocal, delay, callback));
    }

    //------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Lerp Float
    /// </summary>
    /* EX. 
        EZLerp.Instance.Lerp(
              Easing.Type.Linear,
              result => yourFloat = result,
              0,
              100,
              1,
              0,
              null
        );
    */
    /// <param name="easingType">Make lerping more realistic by picking the right easing function</param>
    /// <param name="target">Target to lerp</param>
    /// <param name="start">Start value</param>
    /// <param name="end">End value</param>
    /// <param name="duration">Lerp Time</param>
    /// <param name="delay">Delay before function start</param>
    /// <param name="callback">Action call at the end of function</param>
    public void Lerp(Easing.Type easingType, Action<float> target, float start, float end, float duration, float delay, Action callback)
    {
        StartCoroutine(COLerp(easingType, target, start, end, duration, delay, callback));
    }

    //------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Lerp Color
    /// </summary>
    /* EX. 
        EZLerp.Instance.Lerp(
              Easing.Type.Linear,
              result => yourColor = result,
              Color.White,
              Color.Black,
              1,
              0,
              null
        );
    */
    /// <param name="easingType">Make lerping more realistic by picking the right easing function</param>
    /// <param name="target">Target to lerp.</param>
    /// <param name="start">Start value</param>
    /// <param name="end">End value</param>
    /// <param name="duration">Lerp Time</param>
    /// <param name="delay">Delay before function start</param>
    /// <param name="callback">Action call at the end of function</param>
    public void Lerp(Easing.Type easingType, Action<Color> target, Color start, Color end, float duration, float delay, Action callback)
    {
        StartCoroutine(COLerp(easingType, target, start, end, duration, delay, callback));
    }

    //------------------------------------------------------------------------------------------------------------
    IEnumerator COLerp(TransformType transformType, Easing.Type easingType, Transform myTransform, Vector3 start, Vector3 end, float duration, bool isLocal, float delay, Action callback)
    {
        float currentLerpTime = 0;
        float perc = 0;
        float progress = 0;
        WaitForSeconds wait = new WaitForSeconds(delay);
        yield return wait;

        while (currentLerpTime <= duration)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > duration)
            {
                currentLerpTime = duration;
                break;
            }
            perc = currentLerpTime / duration;
            progress = Easing.GetEasingFunction(easingType, perc);
            switch (transformType)
            {
                case TransformType.Position:
                    {
                        if (isLocal)
                        {
                            myTransform.localPosition = Vector3.Lerp(start, end, progress);
                        }
                        else
                        {
                            myTransform.position = Vector3.Lerp(start, end, progress);
                        }
                    }
                    break;
                case TransformType.Rotation:
                    {
                        if (isLocal)
                        {
                            myTransform.localEulerAngles = Vector3.Lerp(start, end, progress);
                        }
                        else
                        {
                            myTransform.eulerAngles = Vector3.Lerp(start, end, progress);
                        }
                    }
                    break;
                case TransformType.Scale:
                    {
                        myTransform.localScale = Vector3.Lerp(start, end, progress);
                    }
                    break;
            }
            yield return null;
        }

        if (callback != null)
            callback();
    }

    //------------------------------------------------------------------------------------------------------------
    IEnumerator COLerp(TransformType transformType, Easing.Type easingType, Transform myTransform, Vector2 start, Vector2 end, float duration, bool isLocal, float delay, Action callback)
    {
        float currentLerpTime = 0;
        float perc = 0;
        float progress = 0;
        WaitForSeconds wait = new WaitForSeconds(delay);
        yield return wait;

        while (currentLerpTime <= duration)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > duration)
            {
                currentLerpTime = duration;
                break;
            }
            perc = currentLerpTime / duration;
            progress = Easing.GetEasingFunction(easingType, perc);
            switch (transformType)
            {
                case TransformType.Position:
                    {
                        if (isLocal)
                        {
                            myTransform.localPosition = Vector2.Lerp(start, end, progress);
                        }
                        else
                        {
                            myTransform.position = Vector2.Lerp(start, end, progress);
                        }
                    }
                    break;
                case TransformType.Rotation:
                    {
                        if (isLocal)
                        {
                            myTransform.localEulerAngles = Vector2.Lerp(start, end, progress);
                        }
                        else
                        {
                            myTransform.eulerAngles = Vector2.Lerp(start, end, progress);
                        }
                    }
                    break;
                case TransformType.Scale:
                    {
                        myTransform.localScale = Vector2.Lerp(start, end, progress);
                    }
                    break;
            }
            yield return null;
        }

        if (callback != null)
            callback();
    }

    //------------------------------------------------------------------------------------------------------------
    IEnumerator COLerp(Easing.Type easingType, Action<float> target, float start, float end, float duration, float delay, Action callback)
    {
        float currentLerpTime = 0;
        float perc = 0;
        float progress = 0;
        WaitForSeconds wait = new WaitForSeconds(delay);
        yield return wait;

        while (currentLerpTime <= duration)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > duration)
            {
                currentLerpTime = duration;
                break;
            }

            perc = currentLerpTime / duration;
            progress = Easing.GetEasingFunction(easingType, perc);
            target(Mathf.Lerp(start, end, progress));
            yield return null;
        }

        if (callback != null)
            callback();
    }

    //------------------------------------------------------------------------------------------------------------
    IEnumerator COLerp(Easing.Type easingType, Action<Color> target, Color start, Color end, float duration, float delay, Action callback)
    {
        float currentLerpTime = 0;
        float perc = 0;
        float progress = 0;
        WaitForSeconds wait = new WaitForSeconds(delay);
        yield return wait;

        while (currentLerpTime <= duration)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > duration)
            {
                currentLerpTime = duration;
                break;
            }

            perc = currentLerpTime / duration;
            progress = Easing.GetEasingFunction(easingType, perc);
            target(Color.Lerp(start, end, progress));
            yield return null;
        }

        if (callback != null)
            callback();
    }

    //------------------------------------------------------------------------------------------------------------
}