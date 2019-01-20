using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    public class FreeFall : MonoBehaviour, IPhysics
    {
        public GameObject obj;

        double g = 9.81;
        public double h, h0; //high and low point
        double s; //way
        double n; //coordinates counter
        double t, v, vmax; //time, current speed, maximum speed
        int i = 0; //direction counter
        void Start()
        {
            StartPosition();
        }
        void FixedUpdate()
        {
            Calculate();
        }

        public void StartPosition()
        {
            Vector3 vector0 = new Vector3(2, (float)h, -8);
            obj.transform.position = vector0;

            //print("t = " + t);
            //print("s = " + s);
            //print("v = " + v);
            //print("y = " + obj.transform.position.y);
        }
        public void Calculate()
        {
            if (obj.transform.position.y == h0) // the beginning of the movement up
                i++;
            if (obj.transform.position.y == h) // the beginning of the movement down
                i++;

            if (i % 2 == 0)
            {
                t += 0.02;
                v = g * t;
                s = (g * Math.Pow(t, 2) / 2) - n;
                n += s;
                if (obj.transform.position.y - s < h0) //if the next coordinate is below the lowest point, the path to the lowest point is calculated
                {
                    t = Math.Sqrt(h * 2 / g);
                    vmax = v;
                    s = obj.transform.position.y - h0;
                    t = 0;
                    n = 0;
                }

                obj.transform.Translate(0, -(float)s, 0); //movement
                //print("t = " + t);
                //print("s = " + s);
                //print("v = " + v);
                //print("vmax = " + vmax);
                //print("y = " + obj.transform.position.y);

            }
            else
            {

                t += 0.02;
                v = vmax - g * t;
                s = -(vmax * t - (g * Math.Pow(t, 2) / 2)) + n;
                n -= s;
                if (obj.transform.position.y + s > h)
                {
                    t = vmax / g;
                    s = obj.transform.position.y - h;
                    t = 0;
                    n = 0;
                }
                obj.transform.Translate(0, -(float)s, 0);
                //print("t = " + t);
                //print("s = " + s);
                //print("v = " + v);
                //print("vmax = " + vmax);
                //print("y = " + obj.transform.position.y);
            }
        }

    }
}
