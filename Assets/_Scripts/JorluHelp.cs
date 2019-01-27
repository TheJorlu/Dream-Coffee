using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class JorluHelp 
{
	/******************************
                VECTORS
    *******************************/
    public static Vector2 to2(this Vector3 vector) 
    {
        return vector;
    }

    public static Vector3 setX(this Vector3 vector, float x) 
    {
        return new Vector3(x, vector.y, vector.z);
    }

    public static Vector3 setY(this Vector3 vector, float y) 
    {
        return new Vector3(vector.x, y, vector.z);
    }

    public static Vector3 setZ(this Vector3 vector, float z) 
    {
        return new Vector3(vector.x, vector.y, z);
    }

    public static Vector3 setXY(this Vector3 vector, float x, float y) 
    {
        return new Vector3(x, y, vector.z);
    }

    public static Vector3 addX(this Vector3 vector, float plusX) 
    {
        return new Vector3(vector.x + plusX, vector.y, vector.z);
    }

    public static Vector3 addY(this Vector3 vector, float plusY) 
    {
        return new Vector3(vector.x, vector.y + plusY, vector.z);
    }

    public static Vector3 addZ(this Vector3 vector, float plusZ) 
    {
        return new Vector3(vector.x, vector.y, vector.z + plusZ);
    }

    public static Vector3 timesX(this Vector3 vector, float timesX) 
    {
        return new Vector3(vector.x * timesX, vector.y, vector.z);
    }

    public static Vector3 timesY(this Vector3 vector, float timesY) 
    {
        return new Vector3(vector.x, vector.y * timesY, vector.z);
    }

    public static Vector3 timesZ(this Vector3 vector, float timesZ) 
    {
        return new Vector3(vector.x, vector.y, vector.z * timesZ);
    }

    // Vector2
    //------------------------------------------------------------------------
    public static Vector2 setX(this Vector2 vector, float x) 
    {
        return new Vector2(x, vector.y);
    }

    public static Vector2 setY(this Vector2 vector, float y) 
    {
        return new Vector2(vector.x, y);
    }

    public static Vector2 addX(this Vector2 vector, float plusX) 
    {
        return new Vector2(vector.x + plusX, vector.y);
    }

    public static Vector2 addY(this Vector2 vector, float plusY) 
    {
        return new Vector2(vector.x, vector.y + plusY);
    }

    public static Vector2 timesX(this Vector2 vector, float timesX) 
    {
        return new Vector2(vector.x * timesX, vector.y);
    }

    public static Vector2 timesY(this Vector2 vector, float timesY) 
    {
        return new Vector2(vector.x, vector.y * timesY);
    }

    public static void PlayBackwards(this Animation anim, float speed) 
    {
       anim[anim.clip.name].speed = -speed;
       anim[anim.clip.name].time = anim[anim.clip.name].length;
       anim.Play();
    }

    public static void PlayNormal(this Animation anim, float speed) 
    {
       anim[anim.clip.name].speed = speed;
       anim[anim.clip.name].time = 0;
       anim.Play();
    }

    public static Vector2 RandomCardinalDirection()
    {
        int rand = UnityEngine.Random.Range(0,4);

        switch(rand)
        {
            case 0:
                return Vector2.down;
            case 1:
                return Vector2.left;
            case 2:
                return Vector2.right;
            case 3:
                return Vector2.up;
            default:
                return Vector2.up;
        }
    }

    public static Animation SetSpeed(this Animation anim, float speed)
    {
        anim[anim.clip.name].speed = speed;

        return anim;
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        for(int i=0; i<list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public static T GetRandom<T>(this IList<T> list)
    {
        int randomIndex = UnityEngine.Random.Range(0, list.Count);
        return list[randomIndex];
    }

    public static Color setAlpha(this Color color, float alphaValue) 
    {
        color = new Color(color.r, color.g, color.b, alphaValue);

        return color;
    } 

    public static IEnumerator NewWaitForSeconds(this MonoBehaviour b, float t)
    {
        float time = 0f;

        do
        {
            yield return null;
            if (Input.anyKey) yield break;
            time += Time.deltaTime;
        } while (time < t);
    }
}
