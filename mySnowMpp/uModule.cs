using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using myMpxjLib;

using sysD = System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Threading.Tasks;
using nj = Newtonsoft.Json;
using cefW = CefSharp.WinForms;
using cefS = CefSharp;

namespace mySnowMpp
{

    public class uModule
    {   
        // ******************************************
        // Singleton Pattern
        private static uModule myInstance;
        private uModule()
        {
            _dgvInit();
            uLocalAppData = Application.LocalUserAppDataPath;
            uEjsScriptPath = Path.Combine(uLocalAppData, cEjsScript);
            uPluginScriptPath = Path.Combine(uLocalAppData, cPluginScript);
            uSiteCssPath = Path.Combine(uLocalAppData, cSiteCss);
            uHtmlDirPath = Path.Combine(uLocalAppData, cHtml);
            uTmpHtmlDirPath = Path.Combine(uLocalAppData, cTmpHtml);
            uTmpScriptDirPath = Path.Combine(uLocalAppData, cTmpScript);
            //if (System.Diagnostics.Debugger.IsAttached)
            //{
            //    foreach (String fp in System.IO.Directory.GetFiles(uLocalAppData,"*", System.IO.SearchOption.AllDirectories))
            //    {
            //        System.IO.File.Delete(fp);
            //    }
            //}
            uIsInitComplete = File.Exists(uEjsScriptPath) &&
                              File.Exists(uPluginScriptPath) &&
                              File.Exists(uSiteCssPath) &&
                              Directory.Exists(uTmpHtmlDirPath) &&
                              Directory.Exists(uTmpScriptDirPath);
            //if (!uIsInitComplete)
            //{
            //    uThisDirectory = Application.StartupPath.Remove(Application.StartupPath.IndexOf(@"\bin"));
            //    uZipFilePath = Path.Combine(uThisDirectory, cSnowMppZip);
            //    try
            //    {
            //        foreach (String fp in System.IO.Directory.GetFiles(uLocalAppData, "*", System.IO.SearchOption.AllDirectories))
            //        {
            //            System.IO.File.Delete(fp);
            //        }
            //        ZipFile.ExtractToDirectory(uZipFilePath, uLocalAppData);
            //    }
            //    catch(Exception ex)
            //    {

            //    }
            //}
            uLuData = Path.Combine(uTmpScriptDirPath, cLuData);
            uProjData = Path.Combine(uTmpScriptDirPath, cProjData);
            uMppHtml = Path.Combine(uTmpHtmlDirPath, cMppHtml);
            uMppHtmlUrl = @"file:///" + uMppHtml.Replace(cBackSlash, cFwdSlash);
            uSplashHtml = Path.Combine(uHtmlDirPath, cSplashHtml);
            uSplashHtmlUrl = @"file:///" + uSplashHtml.Replace(cBackSlash, cFwdSlash);
            uProjHtml = Path.Combine(uHtmlDirPath, cProjHtml);
            uProjHtmlUrl = @"file:///" + uProjHtml.Replace(cBackSlash, cFwdSlash);
            uSnowHtml = Path.Combine(uTmpHtmlDirPath, cSnowHtml);
            uSnowHtmlUrl = @"file:///" + uSnowHtml.Replace(cBackSlash, cFwdSlash);
        }
        public static uModule uModuleInstanceHandler
        {
            get
            {
                if (myInstance == null)
                {
                    myInstance = new uModule();
                }
                return myInstance;
            }
        }

        // ******************************************
        // Constants
        private const string cEjsScript = @"scripts\ejs2.min.js";
        private const string cPluginScript = @"scripts\jquery.myUtilPlugin.js";
        private const string cSiteCss = @"styles\mySite.css";
        private const string cHtml = @"html";
        private const string cTmpHtml = @"tmphtml";
        private const string cTmpScript = @"tmpscript";
        private const string cSplashHtml = @"splash.html";
        private const string cMppHtml = @"mympp.html";
        private const string cProjHtml = @"myproj.html";
        private const string cSnowHtml = @"mysnow.html";
        private const string cLuData = @"myludata.js";
        private const string cProjData = @"myprojdata.js";
        private const string cSnowMppZip = @"Zip\snowmpp.zip";

        private const string cLaunchUrl =
@"/nav_to.do?uri=/pm_project.do?sys_id={0}&sysparm_record_target=pm_project&sysparm_record_row=1&sysparm_record_rows=22&sysparm_record_list=sys_class_name=pm_project^ORDERBYDESCtask";

        private const char cBackSlash = '\\';
        private const char cFwdSlash = '/';

        // ******************************************
        // Properties
        public static Action myAction;
        private string[] myProperties;
        public class uInstance
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public uInstance(string argName, string argUrl)
            {
                Name = argName;
                Url = argUrl;
            }
        }
        private string[] _uProperties { get { return myProperties; } set { myProperties = value; } }
        private uInstance _uInstanceNode;
        private List<uInstance> _uInstanceList;
        private BindingList<uInstance> _uDgvList;
        public BindingList<uInstance> uDgvList { get { return _uDgvList; } }
        public static mpxWrapper.jsonRoot uJsonRoot;
        public static string projsysid;
        public mpxWrapper.jsonListRoot uJsonListRoot;
        public mpxWrapper.jsonCommon uJsonCommon;

        public static mpxWrapper.SnowProjFmChrome[] uSnowFmChromeList;
        public static string uSnowFmChromeListStr;

        public static string uFileName;
        public static string uUrl;
        public static string uUser;
        public static string uPassword;
        public string uHtml;
        public bool isBindingListUpdate = false;
       
        public string uLocalAppData;
        protected string uEjsScriptPath;
        protected string uPluginScriptPath;
        protected string uSiteCssPath;
        protected string uHtmlDirPath;
        protected string uTmpHtmlDirPath;
        protected string uTmpScriptDirPath;
        protected bool uIsInitComplete;
        protected string uThisDirectory;
        protected string uZipFilePath;
        protected string uLuData;
        protected string uProjData;
        protected string uMppHtml;
        protected string uProjHtml;
        protected string uSnowHtml;
        internal string uSplashHtml;
        internal string uMppHtmlUrl;
        internal string uSplashHtmlUrl;
        internal string uProjHtmlUrl;
        internal string uSnowHtmlUrl;

        internal static htmlSelected uHtmlSelected = htmlSelected._splashHtml;

        // ******************************************
        // Methods
        public void uDgvUpdate(DataGridView argDgv)
        {
            string myTempStr;
            Properties.Settings.Default.Instances.Clear();
            Properties.Settings.Default.Save();
            foreach (DataGridViewRow row in argDgv.Rows)
            {
                myTempStr=String.Format("{0}|{1}", row.Cells[0].Value, row.Cells[1].Value);
                Properties.Settings.Default.Instances.Add(myTempStr);
            }
            Properties.Settings.Default.Save();
            _dgvInit();
        }
        private void _dgvInit()
        {
            isBindingListUpdate = true; 
            _uInstanceList = new List<uInstance>();
            string[] mySplit;
            _uProperties = Properties.Settings.Default.Instances.Cast<string>().ToArray();
            for (int i = 0, iLength = _uProperties.Length; i < iLength; i++)
            {
                mySplit = _uProperties[i].Split('|');
                _uInstanceNode = new uInstance(mySplit[0], mySplit[1]);
                _uInstanceList.Add(_uInstanceNode);
            }
            _uDgvList = new BindingList<uInstance>(_uInstanceList);
        }

        public string uGetMppHtml(string argFile)
        {
            return myMpxjLib.mpxWrapper.Utility.uBuildHtml(argFile);
        }
        public void uCreateWebFiles(string argFile)
        {
            StringBuilder mySb = new StringBuilder(";$.myLuData=");
            mySb.Append(uJsonCommon.strData);
            using (System.IO.StreamWriter myLuDataFile =
                new System.IO.StreamWriter(uLuData, false))
            {
                myLuDataFile.Write(mySb.ToString());
            }

            mySb = new StringBuilder(uGetMppHtml(argFile));
            using (System.IO.StreamWriter myMppHtmlFile =
                new System.IO.StreamWriter(uMppHtml, false))
            {
                myMppHtmlFile.Write(mySb.ToString());
            }
        }
        public void uCreateProjListFile(string argProjList)
        {
            StringBuilder mySb = new StringBuilder(";$.myProData=");
            mySb.Append(argProjList);
            using (System.IO.StreamWriter myProjDataFile =
                new System.IO.StreamWriter(uProjData, false))
            {
                myProjDataFile.Write(mySb.ToString());
            }
        }
        public void uCreateSnowProjFile(string argHtml)
        {
            using (System.IO.StreamWriter mySnowHtmlFile =
                new System.IO.StreamWriter(uSnowHtml, false))
            {
                mySnowHtmlFile.Write(argHtml);
            }
        }

        public const string cDataGatherJs = @"(function() { return $().myUtilPlugin().uGather(); })();";
        public static cefS.JavascriptResponse uJsResponse;

        public static cefS.JavascriptResponse uJsExec(uChrome agrBrowser, string argJs)
        {
            List<long> frameIdList = agrBrowser.uBrowser.GetBrowser().GetFrameIdentifiers();
            cefS.IFrame frame = agrBrowser.uBrowser.GetBrowser().GetFrame(frameIdList.First());
            var t = frame.EvaluateScriptAsync(argJs);
            t.Wait();
            return t.Result;
        }

        public static void uStoreResponse(cefS.JavascriptResponse argResponse)
        {
            uModule.uSnowFmChromeListStr = argResponse.Result.ToString();
            uModule.uSnowFmChromeList = nj.JsonConvert.DeserializeObject<mpxWrapper.SnowProjFmChrome[]>(argResponse.Result.ToString());
        }

        public static void uUpload(string argUrl, string argUser, string argPassword)
        {
            uModule.uJsonRoot = myMpxjLib.mpxWrapper.Utility.uUploadMpp(
                                        uModule.uSnowFmChromeListStr,
                                        argUrl,
                                        argUser,
                                        argPassword
                                );
        }

        public static void uUpdate(string argUrl, string argUser, string argPassword)
        {
            myMpxjLib.mpxWrapper.Utility.uUploadSnowUpdate(
                uModule.uSnowFmChromeListStr,
                argUrl,
                argUser,
                argPassword
            );
        }

        public static void buildTree(TreeNodeCollection pNodes)
        {
            uModule.projsysid = uModule.uJsonRoot.result[0].sysId;
            buildTree(pNodes, uModule.uJsonRoot.result);
        }

        private static void buildTree(TreeNodeCollection pNodes, mpxWrapper.jsonNode[] argList)
        {
            if (argList.Length < 1) return;
            int parentIndex = 0;
            TreeNode currentNode;
            for (int i = 0, iLen = argList.Length; i < iLen; i++)
            {
                TreeNode myNode = new TreeNode(argList[i].number + ": " + argList[i].name);
                parentIndex = pNodes.Add(myNode);
                currentNode = pNodes[parentIndex];
                buildTree(currentNode.Nodes, argList[i].childlist);
            }
        }

        public static void launchSnow()
        {
            string myLaunchUrl = String.Format(uModule.cLaunchUrl, uModule.projsysid);
            myLaunchUrl = mpxWrapper.Utility.urlBuild(uModule.uUrl, myLaunchUrl);
            ProcessStartInfo sInfo = new ProcessStartInfo(myLaunchUrl);

            Boolean isDone = false;
            int stepCtr = 0;
            while (!isDone)
            {
                try
                {
                    switch (stepCtr)
                    {
                        case 0:
                            Process.Start(sInfo);
                            break;
                        case 1:
                            Process.Start("chrome.exe", sInfo.FileName);
                            break;
                        case 2:
                            Process.Start("firefox.exe", sInfo.FileName);
                            break;
                        case 3:
                            Process.Start("iexplore.exe", sInfo.FileName);
                            break;
                    }
                    isDone = true;
                }
                catch (Exception ex)
                {
                    stepCtr++;
                    if (stepCtr>3)
                    {
                        isDone = true;
                        throw;
                    }
                }
            }
        }

    }
}
