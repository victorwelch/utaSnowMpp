using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cefW = CefSharp.WinForms;
using cefS = CefSharp;

namespace mySnowMpp
{
    public enum htmlSelected { _splashHtml, _mppHtml, _snowHtml, _projHtml, _none }
    public class uChrome
    {
        const String URL_BLANK = "about:blank";
        private static cefW.ChromiumWebBrowser myChrome;
        public uChrome()
        {
            if (myChrome == null)
            {
                cefS.CefSharpSettings.LegacyJavascriptBindingEnabled = true;
                myChrome = new cefW.ChromiumWebBrowser(URL_BLANK);
                myChrome.RegisterJsObject("formCall", new JsFormCall());
                myChrome.Dock = DockStyle.Fill;
            }
            else
            {
                this.uBrowser.Load(URL_BLANK);
            }
        }
        public uChrome(string argUrl)
        {
            if (myChrome == null)
            {
                cefS.CefSharpSettings.LegacyJavascriptBindingEnabled = true;
                myChrome = new cefW.ChromiumWebBrowser(argUrl);
                myChrome.RegisterJsObject("formCall", new JsFormCall());
                myChrome.Dock = DockStyle.Fill;
            }
            else
            {
                this.uBrowser.Load(argUrl);
            }
        }
        public cefW.ChromiumWebBrowser uBrowser { get { return myChrome; } }
        public void LoadHtml(string argHtml)
        {
            this.uBrowser.Load(URL_BLANK);
            cefS.WebBrowserExtensions.LoadHtml(this.uBrowser, "data:text/html," + argHtml, "http://rendering/");
        }
    }
    public class JsFormCall
    {
        public void calledFromJs(Object argObj)
        {
            uModule.projsysid = argObj.ToString();
            uModule.uHtmlSelected = htmlSelected._snowHtml;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Visible)
                {
                    f.Invoke(uModule.myAction);
                    break;
                }
            }
        }
    }
}
