
using Cysharp.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button buttonA;

    private void Start()
    {
        buttonA.onClick.AddListener(() =>
        {
            int COUNT = 1000;
            List<string> strings = new List<string>();
            for (int i = 0; i < 100; i++)
                strings.Add("123456789");


            Profiler.BeginSample("Append/ZString.StringBuilder()");
            for (int i = 0; i < COUNT; i++)
            {
                using (var sb = ZString.CreateStringBuilder(true))
                {
                    for (int j = 0; j < strings.Count; j++)
                    {
                        sb.Append(strings[j]);
                    }

                    sb.ToString();
                }
            }
            Profiler.EndSample();


            Profiler.BeginSample("Append/SharedStringBuilderScope()");
            {
                for (int i = 0; i < COUNT; i++)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    for (int j = 0; j < strings.Count; j++)
                    {
                        sb.Append(strings[j]);
                    }

                    sb.ToString();
                    // sb.Clear();
                }
            }
            Profiler.EndSample();
        });
    }
}