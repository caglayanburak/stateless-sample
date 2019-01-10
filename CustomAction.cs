using System;
using Stateless;

namespace StateMachineSample
{
    public class CustomAction
    {
        public void InvokeEntry(string message)
        {
            this.entrydelegated = OnEntry;
            this.entrydelegated.Invoke(message);
        }

        public void InvokeExit(string message)
        {
            this.exitdelegated = OnExit;
            this.exitdelegated.Invoke(message);
        }

        public Action<string> entrydelegated { get; set; }
        public Action<string> exitdelegated { get; set; }

        private void OnEntry(string message)
        {
            Console.WriteLine($"OnEntry {message}");
        }

        private void OnExit(string message)
        {
            Console.WriteLine($"OnExit {message}");
        }
    }
}