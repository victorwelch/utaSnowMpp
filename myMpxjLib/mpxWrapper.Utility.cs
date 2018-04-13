using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using snh = System.Net.Http;
using snhHeaders = System.Net.Http.Headers;
using net.sf.mpxj;

using nj = Newtonsoft.Json;

namespace myMpxjLib
{
    public partial class mpxWrapper
    {
        // Utilities
        public static class Utility
        {
            // **************************************
            // Properties
            public static jsonRoot uHttpResultJsonRoot;
            public static jsonListRoot uHttpResultJsonListRoot;
            public static string uHttpResultJsonListString;
            public static jsonProjListRoot uHttpResultJsonProjListRoot;
            public static string uHttpResultJsonProjListString;
            public static jsonSnowProjListRoot uHttpResultJsonSnowProjListRoot;
            public static string uHttpResultJsonSnowProjListString;
            public static string uHttpResultJsonSnowUpdateString;
            public static bool uIsValidUser = false;
            public static string uUserId;

            public static lvlDict PortfolioDict;
            public static lvlDict ProgramDict;
            public static lvlDict ProjMgrDict;
            public static lvlDict AssignedToDict;
            public static lvlDict PhaseDict;
            public static lvlDict PhaseTypeDict;
            public static lvlDict CalculationTypeDict;
            public static lvlDict ScheduleDict;
            public static lvlDict StateDict;
            public static lvlDict PriorityDict;
            public static lvlDict RiskDict;
            public static lvlDict ConstraintDict;
            public static lvlDict CmdbciDict;
            public static lvlDict ImpactDict;
            public static lvlDict TaskTypeDict;
            public static lvlDict TaskAssignmentGroupDict;
            public static lvlDict TaskAssignedToDict;

            public static lvNode mtLvNode = new lvNode("", "");
            public static lvNode mtLvDateNode = new lvNode("YYYY-MM-DD HH:MM", "YYYY-MM-DD HH:MM");

            public static lvDataNode mtLvDataNode = new lvDataNode(Utility.mtLvNode, dStatus._empty);
            public static lvDataNode mtLvDateDataNode = new lvDataNode(Utility.mtLvDateNode, dStatus._empty);

            private class uWebServiceInfo
            {
                private static uWebServiceInfo myInstance;
                public string uWebCreate;
                public string uWebRead;
                public string uWebUpdate;
                //public string uDelete;
                public string uWebValidate;
                public string uWebLuLists;
                public string uWebProjLists;
                private uWebServiceInfo()
                {
                    string[] mySettingsList = Properties.Settings.Default.webService.Cast<string>().ToArray();
                    string[] mySplit;
                    string idStr, valueStr;
                    for (int i = 0, iLength = mySettingsList.Length; i < iLength; i++)
                    {
                        mySplit = mySettingsList[i].Split('|');
                        idStr = mySplit[0];
                        valueStr = mySplit[1];
                        switch(idStr)
                        {
                            case "create":
                                this.uWebCreate = valueStr;
                                break;
                            case "read":
                                this.uWebRead = valueStr;
                                break;
                            case "update":
                                this.uWebUpdate = valueStr;
                                break;
                            case "validate":
                                this.uWebValidate = valueStr;
                                break;
                            case "lulists":
                                this.uWebLuLists = valueStr;
                                break;
                            case "projlist":
                                this.uWebProjLists = valueStr;
                                break;
                        }
                    }
                }
                public static uWebServiceInfo uWebServiceInfoHandler
                {
                    get
                    {
                        if (myInstance == null)
                        {
                            myInstance = new uWebServiceInfo();
                        }
                        return myInstance;
                    }
                }
            }

            // **************************************
            // Methods
            public static string urlBuild(string argBase, string argParam)
            {
                string myBase = argBase.Trim();
                string myParam = argParam.Trim();
                if (myBase.Last() == '/')
                {
                    if (myParam.First() == '/') myParam = myParam.Substring(1);
                }
                else
                {
                    if (myParam.First() != '/') myParam = ('/').ToString() + myParam;
                }

                UriBuilder myUriBuilder = new UriBuilder(myBase + myParam);
                return myUriBuilder.ToString();
            }

            public static bool uValidateUser(string argUrl, string argUser, string argPassword)
            {
                uWebServiceInfo myWsi = uWebServiceInfo.uWebServiceInfoHandler;
                MppHelper myMppHelper = new MppHelper();
                string url = argUrl;
                //string urlParam = String.Format(@"/api/126085/umppmgr/uvaliduser/{0}", argUser);
                //string urlParam = String.Format(@"/api/x_126085_umppmgr/uimport/uvaliduser/{0}", argUser);
                string urlParam = String.Format(myWsi.uWebValidate, argUser);
                string user = argUser;
                string pwd = argPassword;
                myMppHelper.basicValidateUser(url, urlParam, user, pwd);
                return uIsValidUser;
            }
            public static jsonRoot uUploadMpp(string argJson, string argUrl, string argUser, string argPassword)
            {
                uWebServiceInfo myWsi = uWebServiceInfo.uWebServiceInfoHandler;
                MppHelper myMppHelper = new MppHelper();
                string url = argUrl;
                //string urlParm = @"/api/126085/umppmgr/create";
                //string urlParm = @"/api/x_126085_umppmgr/uimport/create";
                string urlParm = myWsi.uWebCreate;
                string user = argUser;
                string pwd = argPassword;
                myMppHelper.exportMpp(argJson, url, urlParm, user, pwd);
                return uHttpResultJsonRoot;
            }
            public static void uUploadSnowUpdate(string argJson, string argUrl, string argUser, string argPassword)
            {
                uWebServiceInfo myWsi = uWebServiceInfo.uWebServiceInfoHandler;
                MppHelper myMppHelper = new MppHelper();
                string url = argUrl;
                //string urlParm = @"/api/126085/umppmgr/update/1";
                //string urlParm = @"/api/x_126085_umppmgr/uimport/update/1";
                string urlParm = myWsi.uWebUpdate;
                string user = argUser;
                string pwd = argPassword;
                myMppHelper.putSnowProj(argJson, url, urlParm, user, pwd);
            }

            public static jsonCommon uGetLuLists(string argUrl, string argUser, string argPassword)
            {
                return uBuildLuLists(argUrl, argUser, argPassword);
            }
            public static jsonCommon uBuildLuLists(string argUrl, string argUser, string argPassword)
            {
                uWebServiceInfo myWsi = uWebServiceInfo.uWebServiceInfoHandler;
                MppHelper myMppHelper = new MppHelper();
                string url = argUrl;
                //string urlParm = @"/api/126085/umppmgr/lulist/1";
                //string urlParm = @"/api/x_126085_umppmgr/uimport/lulist/1";
                string urlParm = myWsi.uWebLuLists;
                string user = argUser;
                string pwd = argPassword;
                myMppHelper.getLuLists(argUrl, urlParm, argUser, argPassword);
                PortfolioDict = new lvlDict(uHttpResultJsonListRoot.result.portfolio);
                ProgramDict = new lvlDict(uHttpResultJsonListRoot.result.program);
                ProjMgrDict = new lvlDict(uHttpResultJsonListRoot.result.projmgr);
                AssignedToDict = new lvlDict(uHttpResultJsonListRoot.result.assignedto);
                PhaseDict = new lvlDict(uHttpResultJsonListRoot.result.phase);
                PhaseTypeDict = new lvlDict(uHttpResultJsonListRoot.result.phasetype);
                CalculationTypeDict = new lvlDict(uHttpResultJsonListRoot.result.calculationtype);
                ScheduleDict = new lvlDict(uHttpResultJsonListRoot.result.schedule);
                StateDict = new lvlDict(uHttpResultJsonListRoot.result.state);
                PriorityDict = new lvlDict(uHttpResultJsonListRoot.result.priority);
                RiskDict = new lvlDict(uHttpResultJsonListRoot.result.risk);
                ConstraintDict = new lvlDict(uHttpResultJsonListRoot.result.constraint);
                CmdbciDict = new lvlDict(uHttpResultJsonListRoot.result.cmdbci);
                ImpactDict = new lvlDict(uHttpResultJsonListRoot.result.pmtimpact);
                TaskTypeDict = new lvlDict(uHttpResultJsonListRoot.result.pmttasktype);
                TaskAssignmentGroupDict = new lvlDict(uHttpResultJsonListRoot.result.pmtassignmentgroup);
                TaskAssignedToDict = new lvlDict(uHttpResultJsonListRoot.result.pmtassignedto);
                return new jsonCommon(uHttpResultJsonListRoot, uHttpResultJsonListString);
            }

            public static string uGetProjList(string argUrl, string argUser, string argPassword)
            {
                string jsonStr = String.Empty;
                string htmlStr = String.Empty;
                uWebServiceInfo myWsi = uWebServiceInfo.uWebServiceInfoHandler;
                MppHelper myMppHelper = new MppHelper();
                string url = argUrl;
                //string urlParm = @"/api/126085/umppmgr/projlist/1";
                //string urlParm = @"/api/x_126085_umppmgr/uimport/projlist/1";
                string urlParm = myWsi.uWebProjLists;
                string user = argUser;
                string pwd = argPassword;
                myMppHelper.getProjList(argUrl, urlParm, argUser, argPassword);
                jsonStr = uHttpResultJsonProjListString;
                //htmlStr = uBuildHtmlProj(uHttpResultJsonProjListString);
                return jsonStr;
            }

            public static string uGetSnowProj(string argUrl, string argUser, string argPassword, string argSysId)
            {
                string jsonStr = String.Empty;
                string htmlStr = String.Empty;
                uWebServiceInfo myWsi = uWebServiceInfo.uWebServiceInfoHandler;
                MppHelper myMppHelper = new MppHelper();
                string url = argUrl;
                //string urlParm = String.Format(@"/api/126085/umppmgr/read/{0}", argSysId);
                //string urlParm = String.Format(@"/api/x_126085_umppmgr/uimport/read/{0}", argSysId);
                string urlParm = String.Format(myWsi.uWebRead, argSysId);
                string user = argUser;
                string pwd = argPassword;
                myMppHelper.getSnowProj(argUrl, urlParm, argUser, argPassword);
                htmlStr = uBuildHtmlSnowProj(uHttpResultJsonSnowProjListRoot);
                return htmlStr;
            }
            public static DateTime? GetDateTimme(java.util.Date date)
            {
                return (date == null) ? (DateTime?)null : new DateTime(date.getYear() + 1900, date.getMonth() + 1, date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds());
            }

            public static string uBuildTaskTreeJsonStr(MppProject argProject)
            {
                List<projectTree> myObjResult = new List<projectTree>();
                foreach (MppTask p in argProject.Tasks.ToList())
                {
                    myObjResult.Add(new projectTree(p));
                }
                string myResult = nj.JsonConvert.SerializeObject(myObjResult);
                return myResult;
            }
            public static List<projectTree> uBuildTaskTreeList(MppProject argProject)
            {
                List<projectTree> myObjResult = new List<projectTree>();
                foreach (MppTask p in argProject.Tasks.ToList())
                {
                    myObjResult.Add(new projectTree(p));
                }
                return myObjResult;
            }
            public static string uBuildHtml(string argFile)
            {
                MppHelper myMppHelper = new MppHelper();
                MppProject myMppProject = myMppHelper.LoadProjectFile(argFile);
                return uBuildHtml(myMppProject);
            }

            public static string uBuildHtml(MppProject argProject)
            {
                List<SnowProject> mySnowProjectList = uMppProj2SnowProj(argProject);
                int myTreeDepth = uTreeDepth(mySnowProjectList);

                myMpxjLib.Templates.templateWebPage myTwp = new myMpxjLib.Templates.templateWebPage(mySnowProjectList, myTreeDepth);
                string myPage = myTwp.TransformText();
                return myPage;
            }
            public static string uBuildHtmlProj(string argProjectList)
            {
                myMpxjLib.Templates.templateProjLuPage myTwp = new myMpxjLib.Templates.templateProjLuPage(argProjectList);
                string myPage = myTwp.TransformText();
                return myPage;
            }
            public static string uBuildHtmlSnowProj(jsonSnowProjListRoot myArgListRoot)
            {
                List<SnowProject> mySnowProjectList = uSnowProjList2SnowProj(myArgListRoot);
                int myTreeDepth = uTreeDepth(mySnowProjectList);

                myMpxjLib.Templates.templateWebPage myTwp = new myMpxjLib.Templates.templateWebPage(mySnowProjectList, myTreeDepth, false);
                string myPage = myTwp.TransformText();
                return myPage;
            }
            public static int uTreeDepth(List<SnowTask> argSnowTaskList)
            {
                int currDepth = 0;
                int newDepth = 0;
                foreach (SnowTask pt in argSnowTaskList)
                {
                    if (pt.ChildTasks.Count > 0)
                    {
                        newDepth = uTreeDepth(pt.ChildTasks);
                        currDepth = Math.Max(newDepth, currDepth);
                    }
                }
                return (1 + currDepth);
            }
            public static int uTreeDepth(List<SnowProject> argSnowProjectList)
            {
                int currDepth = 0;
                int newDepth = 0;
                foreach (SnowProject p in argSnowProjectList)
                {
                    if (p.ChildTasks.Count > 0)
                    {
                        newDepth = uTreeDepth(p.ChildTasks);
                        currDepth = Math.Max(newDepth, currDepth);
                    }
                }
                return (1 + currDepth);
            }
            public static int uTreeDepth(List<taskTree> argTaskTreeList)
            {
                int currDepth = 0;
                int newDepth = 0;
                foreach (taskTree tt in argTaskTreeList)
                {
                    if (tt.childtasks.Count > 0)
                    {
                        newDepth = uTreeDepth(tt.childtasks);
                        currDepth = Math.Max(newDepth, currDepth);
                    }
                }
                return (1 + currDepth);
            }
            public static int uTreeDepth(List<projectTree> argProjectTreeList)
            {
                int currDepth = 0;
                int newDepth = 0;
                foreach (taskTree pt in argProjectTreeList)
                {
                    if (pt.childtasks.Count > 0)
                    {
                        newDepth = uTreeDepth(pt.childtasks);
                        currDepth = Math.Max(newDepth, currDepth);
                    }
                }
                return (1 + currDepth);
            }
            public static List<SnowProject> uMppProj2SnowProj(MppProject argMpp)
            {
                List<projectTree> myProjectTreeList = uBuildTaskTreeList(argMpp);
                List<SnowProject> mySnowProjectList = new List<SnowProject>();
                foreach (projectTree pt in myProjectTreeList)
                {
                    mySnowProjectList.Add(new SnowProject(pt));
                }
                return mySnowProjectList;
            }
            public static List<SnowProject> uSnowProjList2SnowProj(jsonSnowProjListRoot argSpfclist)
            {
                List<SnowProject> mySnowProjectList = new List<SnowProject>();
                SnowProjFmChrome[] mySpfclist = argSpfclist.result;
                foreach (SnowProjFmChrome spfc in mySpfclist)
                {
                    mySnowProjectList.Add(new SnowProject(spfc));
                }
                return mySnowProjectList;
            }
        }
    }
}
