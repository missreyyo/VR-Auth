<<<<<<< HEAD
using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor.TestTools.TestRunner.TestRun
{
    internal class TestJobDataHolder : ScriptableSingleton<TestJobDataHolder>
    {
        [SerializeField]
        public List<TestJobData> TestRuns = new List<TestJobData>();
        
        [InitializeOnLoadMethod]
        private static void ResumeRunningJobs()
        {
            foreach (var testRun in instance.TestRuns.ToArray())
            {
                if (testRun.isRunning)
                {
                    var runner = new TestJobRunner();
                    runner.RunJob(testRun);
                }
                else
                {
                    instance.TestRuns.Remove(testRun);
                }
            }
        }
    }
=======
using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor.TestTools.TestRunner.TestRun
{
    internal class TestJobDataHolder : ScriptableSingleton<TestJobDataHolder>
    {
        [SerializeField]
        public List<TestJobData> TestRuns = new List<TestJobData>();
        
        [InitializeOnLoadMethod]
        private static void ResumeRunningJobs()
        {
            foreach (var testRun in instance.TestRuns.ToArray())
            {
                if (testRun.isRunning)
                {
                    var runner = new TestJobRunner();
                    runner.RunJob(testRun);
                }
                else
                {
                    instance.TestRuns.Remove(testRun);
                }
            }
        }
    }
>>>>>>> 5386830ea95ecb9f6ce72cd172faa6cc6f38de24
}