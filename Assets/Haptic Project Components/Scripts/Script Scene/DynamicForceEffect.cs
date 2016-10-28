using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class DynamicForceEffect : MonoBehaviour
{

    public string Type;
    public int effect_index;
    public float gain;
    public float magnitude;
    public float duration;
    public float frequency;
    public float[] positionEffect = new float[3];
    public float[] directionEffect = new float[3];

    private IntPtr _type, _position, _direction;
    public Transform target;


    // Use this for initialization
    void Start()
    {
        Type = "constant";
        setIntPtr();
        PluginImport.SetEffect(_type, effect_index, gain, magnitude, duration, frequency, _position, _direction);
        PluginImport.StartEffect(effect_index);

        InvokeRepeating("ChangeForce", 2.0f, 0.5f);
    }

    void ChangeForce()
    {
        Vector3 vec = transform.position - target.position;
        magnitude = (vec.magnitude) / 1000;
        directionEffect[0] = vec[0];
        directionEffect[1] = vec[1];
        directionEffect[2] = vec[2];
        setIntPtr();
        PluginImport.StopEffect(effect_index);
        //Set the effect
        PluginImport.SetEffect(_type, effect_index, gain, magnitude, duration, frequency, _position, _direction);
        PluginImport.StartEffect(effect_index);
    }

    void setIntPtr()
    {
        //convert String to IntPtr
        _type = ConverterClass.ConvertStringToByteToIntPtr(Type);
        //Convert float[3] to intptr
        _position = ConverterClass.ConvertFloat3ToIntPtr(positionEffect);
        //Convert float[3] to intptr
        _direction = ConverterClass.ConvertFloat3ToIntPtr(directionEffect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
