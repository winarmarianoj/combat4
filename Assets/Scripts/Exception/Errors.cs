using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Exception
{
    public class Errors
    {
        private static string LOG_PATH = "ErrorLog.txt";
        private static TextWriter _textWriter;

        public Errors() {
            OpenLog();
        }
        
        private void OpenLog(){
            try
            {
                _textWriter = new StreamWriter(LOG_PATH);
            } catch (IOException e)
            {
                var eStackTrace = e.StackTrace;
                Debug.Log(eStackTrace);
            }
        }
        
        public async Task LogErrors(String message)
        {
            await _textWriter.WriteLineAsync(message);
            
        }
    }
}