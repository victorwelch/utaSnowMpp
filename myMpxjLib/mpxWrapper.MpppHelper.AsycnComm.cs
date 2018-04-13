using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using snh = System.Net.Http;
using snhHeaders = System.Net.Http.Headers;
using nj=Newtonsoft.Json;

namespace myMpxjLib
{
    public partial class mpxWrapper
    {
        public partial class MppHelper
        {
           internal async void basicValidateUser(string argUrl, string argUrlParam, string argUser, string argPwd)
            {
                string myUrl = Utility.urlBuild(argUrl, argUrlParam);

                snh.HttpClient myHttpClient = new snh.HttpClient();
                myHttpClient.BaseAddress = new Uri(myUrl);

                // Add an Accept header for JSON format.
                myHttpClient.DefaultRequestHeaders.Accept.Add(
                    new snhHeaders.MediaTypeWithQualityHeaderValue("application/json")
                );

                //myHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                byte[] myByteBuff = Encoding.ASCII.GetBytes(argUser + ":" + argPwd);
                myHttpClient.DefaultRequestHeaders.Authorization = new snhHeaders.AuthenticationHeaderValue("Basic", Convert.ToBase64String(myByteBuff));

                // List data response.
                snh.HttpResponseMessage myHttpResponse = myHttpClient.GetAsync(myUrl).Result;

                if (myHttpResponse.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    string myJsonData = await myHttpResponse.Content.ReadAsStringAsync();
                    jsonResult myResultObj = nj.JsonConvert.DeserializeObject<jsonResult>(myJsonData);
                    Utility.uUserId = myResultObj.result.ToString();
                    Utility.uIsValidUser = true;
                }
                else
                {
                    Utility.uIsValidUser = false;
                }
            }
            internal async void exportMpp(string argProjectJson, string argUrl, string argUrlParam, string argUser, string argPwd)
            {
                jsonRoot myResult = new jsonRoot();
                string myUrl = Utility.urlBuild(argUrl, argUrlParam);

                snh.HttpClient myHttpClient = new snh.HttpClient();
                myHttpClient.BaseAddress = new Uri(myUrl);

                // Add an Accept header for JSON format.
                myHttpClient.DefaultRequestHeaders.Accept.Add(
                    new snhHeaders.MediaTypeWithQualityHeaderValue("application/json")
                );

                byte[] myByteBuff = Encoding.ASCII.GetBytes(argUser + ":" + argPwd);
                myHttpClient.DefaultRequestHeaders.Authorization = new snhHeaders.AuthenticationHeaderValue("Basic", Convert.ToBase64String(myByteBuff));

                string myStringParam = argProjectJson;
                snh.StringContent myStringContent = new snh.StringContent(
                                                            myStringParam,
                                                            Encoding.UTF8,
                                                            "application/json"
                                                        );

                // List data response.
                snh.HttpResponseMessage myHttpResponse = myHttpClient.PostAsync(
                                                             myUrl,
                                                             myStringContent
                                                          ).Result;

                if (myHttpResponse.IsSuccessStatusCode)
                {
                    // Parse the response body. 
                    string myJsonData = await myHttpResponse.Content.ReadAsStringAsync();
                    myResult = nj.JsonConvert.DeserializeObject<jsonRoot>(myJsonData);
                    Utility.uHttpResultJsonRoot = myResult;
                }
                else
                {
                    Exception ex = new Exception(String.Format("{0} ({1})", (int)myHttpResponse.StatusCode, myHttpResponse.ReasonPhrase));
                    throw ex;
                }
            }

            internal async void getLuLists(string argUrl, string argUrlParam, string argUser, string argPwd)
            {
                jsonListRoot myJsonResult = new jsonListRoot();
                string myUrl = Utility.urlBuild(argUrl, argUrlParam);

                snh.HttpClient myHttpClient = new snh.HttpClient();
                myHttpClient.BaseAddress = new Uri(myUrl);

                // Add an Accept header for JSON format.
                myHttpClient.DefaultRequestHeaders.Accept.Add(
                    new snhHeaders.MediaTypeWithQualityHeaderValue("application/json")
                );

                //myHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                byte[] myByteBuff = Encoding.ASCII.GetBytes(argUser + ":" + argPwd);
                myHttpClient.DefaultRequestHeaders.Authorization = new snhHeaders.AuthenticationHeaderValue("Basic", Convert.ToBase64String(myByteBuff));

                // List data response.
                snh.HttpResponseMessage myHttpResponse = myHttpClient.GetAsync(
                                                             myUrl
                                                          ).Result;

                if (myHttpResponse.IsSuccessStatusCode)
                {
                    // Parse the response body. 
                    string myJsonData = await myHttpResponse.Content.ReadAsStringAsync();
                    Utility.uHttpResultJsonListString = myJsonData;
                    myJsonResult = nj.JsonConvert.DeserializeObject<jsonListRoot>(myJsonData);
                    Utility.uHttpResultJsonListRoot = myJsonResult;
                }
                else
                {
                    Exception ex = new Exception(String.Format("{0} ({1})", (int)myHttpResponse.StatusCode, myHttpResponse.ReasonPhrase));
                    throw ex;
                }
            }
            internal async void getProjList(string argUrl, string argUrlParam, string argUser, string argPwd)
            {
                jsonProjListRoot myJsonResult = new jsonProjListRoot();
                string myUrl = Utility.urlBuild(argUrl, argUrlParam);

                snh.HttpClient myHttpClient = new snh.HttpClient();
                myHttpClient.BaseAddress = new Uri(myUrl);

                // Add an Accept header for JSON format.
                myHttpClient.DefaultRequestHeaders.Accept.Add(
                    new snhHeaders.MediaTypeWithQualityHeaderValue("application/json")
                );

                //myHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                byte[] myByteBuff = Encoding.ASCII.GetBytes(argUser + ":" + argPwd);
                myHttpClient.DefaultRequestHeaders.Authorization = new snhHeaders.AuthenticationHeaderValue("Basic", Convert.ToBase64String(myByteBuff));

                // List data response.
                snh.HttpResponseMessage myHttpResponse = myHttpClient.GetAsync(
                                                             myUrl
                                                          ).Result;

                if (myHttpResponse.IsSuccessStatusCode)
                {
                    // Parse the response body. 
                    string myJsonData = await myHttpResponse.Content.ReadAsStringAsync();
                    Utility.uHttpResultJsonProjListString = myJsonData;
                    myJsonResult = nj.JsonConvert.DeserializeObject<jsonProjListRoot>(myJsonData);
                    Utility.uHttpResultJsonProjListRoot = myJsonResult;
                }
                else
                {
                    Exception ex = new Exception(String.Format("{0} ({1})", (int)myHttpResponse.StatusCode, myHttpResponse.ReasonPhrase));
                    throw ex;
                }
            }
            internal async void getSnowProj(string argUrl, string argUrlParam, string argUser, string argPwd)
            {
                jsonSnowProjListRoot myJsonResult = new jsonSnowProjListRoot();
                string myUrl = Utility.urlBuild(argUrl, argUrlParam);

                snh.HttpClient myHttpClient = new snh.HttpClient();
                myHttpClient.BaseAddress = new Uri(myUrl);

                // Add an Accept header for JSON format.
                myHttpClient.DefaultRequestHeaders.Accept.Add(
                    new snhHeaders.MediaTypeWithQualityHeaderValue("application/json")
                );

                //myHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                byte[] myByteBuff = Encoding.ASCII.GetBytes(argUser + ":" + argPwd);
                myHttpClient.DefaultRequestHeaders.Authorization = new snhHeaders.AuthenticationHeaderValue("Basic", Convert.ToBase64String(myByteBuff));

                // List data response.
                snh.HttpResponseMessage myHttpResponse = myHttpClient.GetAsync(
                                                             myUrl
                                                          ).Result;

                if (myHttpResponse.IsSuccessStatusCode)
                {
                    // Parse the response body. 
                    string myJsonData = await myHttpResponse.Content.ReadAsStringAsync();
                    Utility.uHttpResultJsonSnowProjListString = myJsonData;
                    myJsonResult = nj.JsonConvert.DeserializeObject<jsonSnowProjListRoot>(myJsonData);
                    Utility.uHttpResultJsonSnowProjListRoot = myJsonResult;
                }
                else
                {
                    Exception ex = new Exception(String.Format("{0} ({1})", (int)myHttpResponse.StatusCode, myHttpResponse.ReasonPhrase));
                    throw ex;
                }
            }
            internal async void putSnowProj(string argProjectJson, string argUrl, string argUrlParam, string argUser, string argPwd)
            {
                //jsonSnowProjListRoot myJsonResult = new jsonSnowProjListRoot();
                string myUrl = Utility.urlBuild(argUrl, argUrlParam);

                snh.HttpClient myHttpClient = new snh.HttpClient();
                myHttpClient.BaseAddress = new Uri(myUrl);

                // Add an Accept header for JSON format.
                myHttpClient.DefaultRequestHeaders.Accept.Add(
                    new snhHeaders.MediaTypeWithQualityHeaderValue("application/json")
                );

                //myHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                byte[] myByteBuff = Encoding.ASCII.GetBytes(argUser + ":" + argPwd);
                myHttpClient.DefaultRequestHeaders.Authorization = new snhHeaders.AuthenticationHeaderValue("Basic", Convert.ToBase64String(myByteBuff));

                //Create HttpContent
                string myStringParam = argProjectJson;
                snh.StringContent myStringContent = new snh.StringContent(
                                                            myStringParam,
                                                            Encoding.UTF8,
                                                            "application/json"
                                                        );

                // List data response.
                snh.HttpResponseMessage myHttpResponse = myHttpClient.PutAsync( 
                                                            myUrl,
                                                            myStringContent
                                                         ).Result;

                if (myHttpResponse.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    string myJsonData = await myHttpResponse.Content.ReadAsStringAsync();
                    Utility.uHttpResultJsonSnowUpdateString = myJsonData;
                    //myJsonResult = nj.JsonConvert.DeserializeObject<jsonSnowProjListRoot>(myJsonData);
                    //Utility.uHttpResultJsonSnowProjListRoot = myJsonResult;
                }
                else
                {
                    Exception ex = new Exception(String.Format("{0} ({1})", (int)myHttpResponse.StatusCode, myHttpResponse.ReasonPhrase));
                    throw ex;
                }
            }
        }
    }
}
