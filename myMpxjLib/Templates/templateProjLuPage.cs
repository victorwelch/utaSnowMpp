﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace myMpxjLib.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using myMpxjLib;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\_myMppStuff\utaSnowMpp4\myMpxjLib\Templates\templateProjLuPage.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class templateProjLuPage : templateProjLuPageBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(" \r\n<!doctype html>\r\n<html>\r\n<head>\r\n<meta charset=\"utf-8\">\r\n<title>Project List</" +
                    "title>\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"../Styles/mySite.css\">\r\n<li" +
                    "nk rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bo" +
                    "otstrap.min.css\">\r\n<link rel=\"stylesheet\" href=\"https://code.jquery.com/ui/1.12." +
                    "1/themes/base/jquery-ui.css\">\r\n<script type=\"text/javascript\" src=\"https://ajax." +
                    "googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js\"></script>\r\n<script type=\"te" +
                    "xt/javascript\" src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap" +
                    ".min.js\"></script>\r\n<script type=\"text/javascript\" src=\"https://code.jquery.com/" +
                    "ui/1.12.1/jquery-ui.min.js\"></script>\r\n<script type=\"text/javascript\" src=\"../sc" +
                    "ripts/ejs2.min.js\"></script>\r\n<script type=\"text/javascript\" src=\"../tmpscript/m" +
                    "yprojdata.js\"></script>\r\n<script type=\"text/javascript\" src=\"../Scripts/jquery.m" +
                    "yUtilPlugin.js\"></script>\r\n</head>\r\n<body>\r\n<div style=\"margin-left:10px;margin-" +
                    "top:10px;border-left:10px solid #555;\">\r\n\t<table id=\"tblLu\" class=\"lu\" style=\"bo" +
                    "rder-top:0 !important;border-left:0 !important;border-right:0 !important;border-" +
                    "bottom:solid 10px #555 !important;\">\t\r\n\t\t<tr>\r\n\t\t\t<th style=\"display:table-cell;" +
                    "text-align:left;border-bottom:none;text-align:center;\"><input id=\"inpProjNumberS" +
                    "earch\" type=\"text\" value=\"\" style=\"color:black;width:125px;\"/></th>\r\n\t\t\t<th styl" +
                    "e=\"display:table-cell;text-align:left;border-bottom:none;text-align:center;borde" +
                    "r-left:1px solid #fff;\"><input id=\"inpProjNameSearch\" type=\"text\" value=\"\" style" +
                    "=\"color:black;width:125px;\"/></th>\r\n\t\t\t<th style=\"display:table-cell;text-align:" +
                    "left;border-bottom:none;text-align:center;border-left:1px solid #fff;\"><input id" +
                    "=\"inpProjCreatedOnSearch\" type=\"text\" value=\"\" style=\"color:black;width:125px;\"/" +
                    "></th>\r\n\t\t\t<th style=\"display:table-cell;text-align:left;border-bottom:none;text" +
                    "-align:center;border-left:1px solid #fff;\"><input id=\"inpProjCreatedBySearch\" ty" +
                    "pe=\"text\" value=\"\" style=\"color:black;width:125px;\"/></th>\r\n\t\t\t<th style=\"displa" +
                    "y:table-cell;text-align:left;border-bottom:none;text-align:center;border-left:1p" +
                    "x solid #fff;\"><input id=\"inpProjUpdatedOnSearch\" type=\"text\" value=\"\" style=\"co" +
                    "lor:black;width:125px;\"/></th>\r\n\t\t\t<th style=\"display:table-cell;text-align:left" +
                    ";border-bottom:none;text-align:center;border-left:1px solid #fff;\"><input id=\"in" +
                    "pProjUpdatedBySearch\" type=\"text\" value=\"\" style=\"color:black;width:125px;\"/></t" +
                    "h>\r\n\t\t    <th style=\"display:table-cell;text-align:left;border-bottom:none;text-" +
                    "align:center;\">\r\n\t\t\t\t<div class=\"btn3luGlyph\" style=\"font-size:12px;width=100%;t" +
                    "ext-align:center;\"><span class=\"glyphicon glyphicon-search\" style=\"padding-left:" +
                    "5px;padding-right:5px;padding-bottom:2px;\"></span></div>\r\n\t\t\t</th>\r\n\t\t    <th st" +
                    "yle=\"display:table-cell;text-align:left;border-bottom:none;text-align:center;\">\r" +
                    "\n\t\t\t\t<div class=\"btn3luGlyph\" style=\"font-size:12px;width=100%;text-align:center" +
                    ";\"><span class=\"glyphicon glyphicon-remove\" style=\"padding-left:5px;padding-righ" +
                    "t:5px;padding-top:4px;\"></span></div>\r\n\t\t\t</th>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<th class=\"" +
                    "leftBbn\">\r\n\t\t\t\t<div class=\"divProjNumber\">\r\n\t\t\t\t\t<div style=\"display:inline-bloc" +
                    "k;padding-top:10px;padding-left:10px;\">Number</div>\r\n\t\t\t\t\t<div class=\"divProjSor" +
                    "t\">\r\n\t\t\t\t\t\t<div class=\"divProjSortGlyphL btn3SortGlyphLarge\" style=\"\"><span clas" +
                    "s=\"glyphicon glyphicon-sort-by-alphabet\"></span></div>\r\n\t\t\t\t\t\t<div class=\"divPro" +
                    "jSortGlyphR\"><span class=\"glyphicon glyphicon-sort-by-alphabet-alt\"></span></div" +
                    ">\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</th>\r\n\t\t\t<th class=\"leftBbn\" style=\"border-left:" +
                    "1px solid #fff;\">\r\n\t\t\t\t<div class=\"divProjName\">\r\n\t\t\t\t\t<div style=\"display:inlin" +
                    "e-block;padding-top:10px;padding-left:20px;\">Name</div>\r\n\t\t\t\t\t<div class=\"divPro" +
                    "jSort\">\r\n\t\t\t\t\t\t<div class=\"divProjSortGlyphL\"><span class=\"glyphicon glyphicon-s" +
                    "ort-by-alphabet\" style=\"vertical-align:bottom;\"></span></div>\r\n\t\t\t\t\t\t<div class=" +
                    "\"divProjSortGlyphR\"><span class=\"glyphicon glyphicon-sort-by-alphabet-alt\" style" +
                    "=\"vertical-align:bottom;\"></span></div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</th>\r\n\t\t\t<" +
                    "th class=\"leftBbn\" style=\"border-left:1px solid #fff;\">\r\n\t\t\t\t<div class=\"divProj" +
                    "CreatedOn\">\r\n\t\t\t\t\t<div style=\"display:inline-block;padding-top:10px;padding-left" +
                    ":10px;\">Created On</div>\r\n\t\t\t\t\t<div class=\"divProjSort\">\r\n\t\t\t\t\t\t<div class=\"divP" +
                    "rojSortGlyphL\"><span class=\"glyphicon glyphicon-sort-by-alphabet\" style=\"vertica" +
                    "l-align:bottom;\"></span></div>\r\n\t\t\t\t\t\t<div class=\"divProjSortGlyphR\"><span class" +
                    "=\"glyphicon glyphicon-sort-by-alphabet-alt\" style=\"vertical-align:bottom;\"></spa" +
                    "n></div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</th>\r\n\t\t\t<th class=\"leftBbn\" style=\"borde" +
                    "r-left:1px solid #fff;\">\r\n\t\t\t\t<div class=\"divProjCreatedBy\">\r\n\t\t\t\t\t<div style=\"d" +
                    "isplay:inline-block;padding-top:10px;padding-left:20px;\">Created By</div>\r\n\t\t\t\t\t" +
                    "<div class=\"divProjSort\">\r\n\t\t\t\t\t\t<div class=\"divProjSortGlyphL\"><span class=\"gly" +
                    "phicon glyphicon-sort-by-alphabet\" style=\"vertical-align:bottom;\"></span></div>\r" +
                    "\n\t\t\t\t\t\t<div class=\"divProjSortGlyphR\"><span class=\"glyphicon glyphicon-sort-by-a" +
                    "lphabet-alt\" style=\"vertical-align:bottom;\"></span></div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</di" +
                    "v>\r\n\t\t\t</th>\r\n\t\t\t<th class=\"leftBbn\" style=\"border-left:1px solid #fff;\">\r\n\t\t\t\t<" +
                    "div class=\"divProjUpdatedOn\">\r\n\t\t\t\t\t<div style=\"display:inline-block;padding-top" +
                    ":10px;padding-left:10px;\">Updated On</div>\r\n\t\t\t\t\t<div class=\"divProjSort\">\r\n\t\t\t\t" +
                    "\t\t<div class=\"divProjSortGlyphL\"><span class=\"glyphicon glyphicon-sort-by-alphab" +
                    "et\" style=\"vertical-align:bottom;\"></span></div>\r\n\t\t\t\t\t\t<div class=\"divProjSortG" +
                    "lyphR\"><span class=\"glyphicon glyphicon-sort-by-alphabet-alt\" style=\"vertical-al" +
                    "ign:bottom;\"></span></div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</th>\r\n\t\t\t<th class=\"lef" +
                    "tBbn\" style=\"border-left:1px solid #fff;\">\r\n\t\t\t\t<div class=\"divProjUpdatedBy\">\r\n" +
                    "\t\t\t\t\t<div style=\"display:inline-block;padding-top:10px;padding-left:20px;\">Updat" +
                    "ed By</div>\r\n\t\t\t\t\t<div class=\"divProjSort\">\r\n\t\t\t\t\t\t<div class=\"divProjSortGlyphL" +
                    "\"><span class=\"glyphicon glyphicon-sort-by-alphabet\" style=\"vertical-align:botto" +
                    "m;\"></span></div>\r\n\t\t\t\t\t\t<div class=\"divProjSortGlyphR\"><span class=\"glyphicon g" +
                    "lyphicon-sort-by-alphabet-alt\" style=\"vertical-align:bottom;\"></span></div>\r\n\t\t\t" +
                    "\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</th>\r\n\t\t\t<th style=\"border-bottom:0 !important;width:1" +
                    "0px;\">&nbsp;</th>\r\n\t\t\t<th style=\"border-bottom:0 !important;width:10px;\">&nbsp;<" +
                    "/th>\r\n\t\t</tr>\r\n\t\t<div id=\"divProjLu\">\r\n\t\t\t\r\n\t\t</div>\r\n\t</table>\r\n</div>\r\n</body>" +
                    "\r\n\t<script type=\"text/javascript\">\r\n\t\t$(window).on(\'load\',function()\r\n\t\t{\r\n\t\t});" +
                    "\t\t\r\n\t</script>\r\n</html>");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class templateProjLuPageBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
