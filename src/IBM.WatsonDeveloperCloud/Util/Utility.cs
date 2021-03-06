﻿/**
* Copyright 2017 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IBM.WatsonDeveloperCloud.Util
{
    /// <summary>
    /// Utility classes for the Watson .NET Standard SDK.
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Async method for making a simple get request.
        /// </summary>
        /// <param name="url">The URL to make the request.</param>
        /// <param name="username">The username for request authentication.</param>
        /// <param name="password">The password for request authentication.</param>
        /// <returns>A string response from the request.</returns>
        public static async Task<string> SimpleGet(string url, string username = null, string password = null)
        {
            HttpClientHandler handler = null;

            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(password))
            {
                var credentials = new NetworkCredential(username, password);
                handler = new HttpClientHandler()
                {
                    Credentials = credentials
                };
            }

            var client = new HttpClient(handler == null ? null : handler);
            var stringTask = client.GetStringAsync(url);
            var msg = await stringTask;

            return msg;
        }

        /// <summary>
        /// Copies an input stream to an output stream.
        /// </summary>
        /// <param name="input">The input stream to copy.</param>
        /// <param name="output">The output stream to copy to.</param>
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        /// <summary>
        /// Add a top level object to a json string.
        /// </summary>
        /// <param name="json">The json string.</param>
        /// <param name="objectName">The name of the top level object.</param>
        /// <returns></returns>
        public static string AddTopLevelObjectToJson(string json, string objectName)
        {
            string convertedJson = json.Insert(1, "\"" + objectName + "\": {");
            return convertedJson.Insert(convertedJson.Length - 1, "}");
        }

        /// <summary>
        /// Checks if the string is wrapped or partially wrapped in bad characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns></returns>
        public static bool HasBadFirstOrLastCharacter(string value)
        {
            return value.StartsWith("{") || value.StartsWith("\"") || value.EndsWith("}") || value.EndsWith("\"");
        }

        /// <summary>
        /// Loads environment variables from an external file.
        /// </summary>
        /// <param name="filepath">The location in the file system from which to load environment variables.</param>
        public static bool LoadEnvFile(string filepath)
        {
            List<string> lines = new List<string>();
            string[] rawLines = { };

            try
            {
                rawLines = File.ReadAllLines(filepath);
            }
            catch
            {
                return false;
            }

            foreach(string line in rawLines)
            {
                if(!string.IsNullOrEmpty(line) && !line.StartsWith("#") && line.Contains("="))
                {
                    lines.Add(line);
                }
            }

            Dictionary<string, string> envDict = new Dictionary<string, string>();
            foreach(string line in lines)
            {
                string[] kvp = line.Split(new char[] { '=' }, 2);
                envDict.Add(kvp[0], kvp[1]);
            }

            foreach (KeyValuePair<string, string> keyValuePair in envDict)
            {
                Environment.SetEnvironmentVariable(keyValuePair.Key, keyValuePair.Value);
            }

            return true;
        }

        public static List<string> GetCredentialsPaths()
        {
            List<string> filePathsToLoad = new List<string>();
            string ibmCredentialsEnvVariable = Environment.GetEnvironmentVariable("IBM_CREDENTIALS_FILE");
            if (!string.IsNullOrEmpty(ibmCredentialsEnvVariable))
            {
                filePathsToLoad.Add(ibmCredentialsEnvVariable);
            }

            string unixHomePath = Environment.GetEnvironmentVariable("HOME") + "/ibm-credentials.env";
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")) && File.Exists(unixHomePath))
            {
                filePathsToLoad.Add(unixHomePath);
            }

            string windowsHomePath = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + "\\ibm-credentials.env";
            if (!string.IsNullOrEmpty(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%")) && File.Exists(windowsHomePath))
            {
                filePathsToLoad.Add(windowsHomePath);
            }

            string userProfilePath = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + "\\ibm-credentials.env";
            if (!string.IsNullOrEmpty(Environment.ExpandEnvironmentVariables("%USERPROFILE%")) && File.Exists(userProfilePath))
            {
                filePathsToLoad.Add(userProfilePath);
            }

            if (File.Exists(@"ibm-credentials.env"))
            {
                filePathsToLoad.Add(@"ibm-credentials.env");
            }

            return filePathsToLoad;
        }
    }
}
