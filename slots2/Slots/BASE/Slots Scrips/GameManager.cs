using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEditor;

/// <summary>
/// This GameScript runs through a Sequence of Parts,
/// -Can Define Time for Each Part (In Most Cases Time taken by events and Animations in between Parts)
/// -This is a one-off Play Sequence, ie- Once Sequence is Run, values probably shouldn't be changed till it stops/completes. Set All bools before run. 
/// -Checking Bool for parts if its true, it continues.
/// Bools are _ok_(number) // Set these true/false by calling functions "ok_1" / "no_1"from other scripts/events
/// -There's an event on every passing of part, + Complete + Fail which can be set directly via editor.
/// -Call Reset() from Button/script outside
/// -Progress Bar is visual system, To set its stop points acc to parts.
/// -Tip: If there are less than 10 needed numbers of parts, set bools after to true in inspector and time to complete 0 after your last part.
/// sz.sahaj@embracingearth.space
/// </summary>

namespace GameManager_Slot_sz
{

        public class GameManager : MonoBehaviour
        {
        [SerializeField]
        private Image _ProgressBar = null;

        /*
        [Range(1, 10)]
        public int numberofparts = 10;
        *///define number of parts and this awake sets all variables after defined number of parts to pass through.

        #region Decleration :: Events On Passing Part Successfully and Duration for these events.

        [Tooltip("Time it takes to complete Part 0-1//of Your Events")]
        public float TimeToComplete0_1 = 1;
        [Tooltip("Event On Passing `1 and Begining 2")]
        public UnityEvent PassPart1;
        [Tooltip("Time Part 1-2// of Your Events")]
        public float TimeToComplete1_2 = 1;
        [Tooltip("Pass `2 - Begin 3")]
        public UnityEvent PassPart2;

        public float TimeToComplete2_3 = 1;
        public UnityEvent PassPart3;
        public float TimeToComplete3_4 = 1;
        public UnityEvent PassPart4;
        public float TimeToComplete4_5 = 1;
        public UnityEvent PassPart5;
        public float TimeToComplete5_6 = 1;
        public UnityEvent PassPart6;
        public float TimeToComplete6_7 = 1;
        public UnityEvent PassPart7;
        public float TimeToComplete7_8 = 1;
        public UnityEvent PassPart8;
        public float TimeToComplete8_9 = 1;
        public UnityEvent PassPart9;
        public float TimeToComplete9_10 = 1;
        public UnityEvent PassPart10;
        public float TimeToComplete10_end = 1;
        public UnityEvent complete;
        #endregion

        public UnityEvent OnFail;
        [Tooltip("Call Reset from Button")]public UnityEvent OnReset;

        #region Declerations ok bools and progressbar Part Values// public for inspector ease
        public bool _ok_1 = false;
        public bool _ok_2 = false;
        public bool _ok_3 = false;
        public bool _ok_4 = false;
        public bool _ok_5 = false;
        public bool _ok_6 = false;
        public bool _ok_7 = false;
        public bool _ok_8 = false;
        public bool _ok_9 = false;
        public bool _ok_10 = false;

        [Tooltip("Progress Bar Value")] public float ProgressBarValueStart = 0f;
        [Tooltip("Progress Bar Value")]public float part1 = 0.054f;
        [Tooltip("Progress Bar Value")] public float part2 = 0.144f;
        [Tooltip("Progress Bar Value")] public float part3 = 0.255f;
        [Tooltip("Progress Bar Value")] public float part4 = 0.35f;
        [Tooltip("Progress Bar Value")] public float part5 = 0.445f;
        [Tooltip("Progress Bar Value")] public float part6 = 0.551f;
        [Tooltip("Progress Bar Value")] public float part7 = 0.654f;
        [Tooltip("Progress Bar Value")] public float part8 = 0.757f;
        [Tooltip("Progress Bar Value")] public float part9 = 0.85f;
        [Tooltip("Progress Bar Value")] public float part10 = 0.943f;
        [Tooltip("Progress Bar Value")] public float end = 1f;

        #endregion

        #region Functions to change state of _ok_
        //Call From Events On specific Objects.
        public void Ok_1()
        {
            _ok_1 = true;
        }
        public void No_1()
        {
            _ok_1 = false;
        }

        public void Ok_2()
        {
            _ok_2 = true;
        }
        public void No_2()
        {
            _ok_2 = false;
        }

        public void Ok_3()
        {
            _ok_3 = true;
        }
        public void No_3()
        {
            _ok_3 = false;
        }

        public void Ok_4()
        {
            _ok_4 = true;
        }
        public void No_4()
        {
            _ok_4 = false;
        }

        public void Ok_5()
        {
            _ok_5 = true;
        }

        public void No_5()
        {
            _ok_5 = false;
        }

        public void Ok_6()
        {
            _ok_6 = true;
        }

        public void No_6()
        {
            _ok_6 = false;
        }

        public void Ok_7()
        {
            _ok_7 = true;
        }

        public void No_7()
        {
            _ok_7 = false;
        }

        public void Ok_8()
        {
            _ok_8 = true;
        }

        public void No_8()
        {
            _ok_8 = false;
        }

        public void Ok_9()
        {
            _ok_9 = true;
        }

        public void No_9()
        {
            _ok_9 = false;
        }

        public void Ok_10()
        {
            _ok_10 = true;
        }

        public void No_10()
        {
            _ok_10 = false;
        }
        #endregion
         
        /*
        //You can access these as lists if need to iterate easily
        public List<float> timebools = new List<float>();
        public List<bool> _ok_Bools = new List<bool>();
        private void Start()
        {
             
            timebools.Add(TimeToComplete0_1);       _ok_Bools.Add(_ok_1);
            timebools.Add(TimeToComplete1_2);       _ok_Bools.Add(_ok_2);
            timebools.Add(TimeToComplete2_3);       _ok_Bools.Add(_ok_3);
            timebools.Add(TimeToComplete3_4);       _ok_Bools.Add(_ok_4);
            timebools.Add(TimeToComplete4_5);       _ok_Bools.Add(_ok_5);
            timebools.Add(TimeToComplete5_6);       _ok_Bools.Add(_ok_6);
            timebools.Add(TimeToComplete6_7);       _ok_Bools.Add(_ok_7);
            timebools.Add(TimeToComplete7_8);       _ok_Bools.Add(_ok_8);
            timebools.Add(TimeToComplete8_9);       _ok_Bools.Add(_ok_9);
            timebools.Add(TimeToComplete9_10);      _ok_Bools.Add(_ok_10);
            timebools.Add(TimeToComplete10_end);

            for(int i = 10 ; i > numberofparts; i--) // Set everything after numberofParts to instant passthrough value.
            {
                timebools[i] = 0;       _ok_Bools[i-1] = true;
            }

        }
        */

        private void Awake()
        {
           _ProgressBar.fillAmount = ProgressBarValueStart;
        }
        private void OnEnable()
        {
            _ProgressBar.fillAmount = ProgressBarValueStart;
        }

        #region PlaySequence
        /*Debug
        public void Start()
        {
            _ok_1 = true;
            _ok_2 = true;
            _ok_3 = true;
            _ok_4 = true;
            _ok_5 = true;
            _ok_6 = true;
            _ok_7 = true;
            _ok_8 = true;
            _ok_9 = true;
            _ok_10 = true;
            StartCoroutine(Part1());
        }
        */

        public void Run()
        {
            StartCoroutine(Part1());
        }

        #region parts
        IEnumerator Part1()
        {
            //ProgressBarStuff 0 to part1
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete0_1;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, part1, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }
            //check to moveforward 
            if(_ok_1==true){
                if(PassPart1!=null)
                    PassPart1.Invoke();
                StartCoroutine(Part2());
            }
            else
            {
                FailedSequence();
            }

        }
        IEnumerator Part2()
        {
            //ProgressBarStuff 1 to part2
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete1_2;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, part2, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }

            if(_ok_2)
            {
                if (PassPart2 != null) 
                    PassPart2.Invoke();
                StartCoroutine(Part3());
            }
            else
            {
                FailedSequence();
            }
        }
        IEnumerator Part3()
        {
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete2_3;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, part3, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }

            if (_ok_3)
            {
                if (PassPart3 != null)
                    PassPart3.Invoke();
                StartCoroutine(Part4());
            }
            else
            {
                FailedSequence();
            }
        }
        IEnumerator Part4()
        {
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete3_4;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, part4, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }

            if (_ok_4)
            {
                if (PassPart4 != null)
                    PassPart4.Invoke();
                StartCoroutine(Part5());
            }
            else
            {
                FailedSequence();
            }
        }
        IEnumerator Part5()
        {
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete4_5;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, part5, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }

            if (_ok_5)
            {
                if (PassPart5 != null)
                    PassPart5.Invoke();
                StartCoroutine(Part6());
            }
            else
            {
                FailedSequence();
            }
        }
        IEnumerator Part6()
        {
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete5_6;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, part6, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }

            if (_ok_6)
            {
                if (PassPart6 != null) 
                    PassPart6.Invoke();
                StartCoroutine(Part7());
            }
            else
            {
                FailedSequence();
            }
        }
        IEnumerator Part7()
        {
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete6_7;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, part7, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }

            if (_ok_7)
            {
                if (PassPart7 != null) 
                    PassPart7.Invoke();

                StartCoroutine(Part8());
            }
            else
            {
                FailedSequence();
            }
        }
        IEnumerator Part8()
        {
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete7_8;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, part8, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }

            if (_ok_8)
            {
                if (PassPart8 != null)
                    PassPart8.Invoke();
                StartCoroutine(Part9());
            }
            else
            {
                FailedSequence();
            }
        }
        IEnumerator Part9()
        {
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete8_9;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, part9, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }

            if (_ok_9)
            {
                if (PassPart9 != null)
                    PassPart9.Invoke();
                StartCoroutine(Part10());
            }
            else
            {
                FailedSequence();
            }
        }
        IEnumerator Part10()
        {
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete9_10;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, part10, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }

            if (_ok_10)
            {
                if (PassPart10 != null)
                    PassPart10.Invoke();
                StartCoroutine(End());
            }
            else
            {
                FailedSequence();
            }
        }
        IEnumerator End()
        {
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = TimeToComplete10_end;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, end, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }
            Complete();
        }

        #endregion
        private void Complete()
        {
            if (complete != null)
                complete.Invoke();
        }

        private void FailedSequence()
        {
            OnFail.Invoke();
        }

        public void Reset()
        {
            OnReset.Invoke();
            StartCoroutine(ResetProgressBar());
        }
        IEnumerator ResetProgressBar()
        {
            float time = 0;
            float startValue = _ProgressBar.fillAmount;
            float timetocomplete = 1;
            while (time < timetocomplete)
            {
                _ProgressBar.fillAmount = (Mathf.Lerp(startValue, ProgressBarValueStart, time / timetocomplete));
                time += Time.deltaTime;
                yield return null;
            }
        }


        #endregion
    }

}
