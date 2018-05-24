<%@ Application Codebehind="Global.asax.cs" Language="C#" %> 

<%@ Import Namespace="System.IO" %> 
<%@ Import Namespace="System.IO.Compression" %> 

<script runat="server"> 
protected void Application_PreRequestHandlerExecute(object sender, EventArgs e) 
    { 
        HttpCompress((HttpApplication)sender); 
    } 


    private void HttpCompress(HttpApplication app) 
    { 
        string acceptEncoding = app.Request.Headers["Accept-Encoding"]; 
        Stream prevUncompressedStream = app.Response.Filter; 


        if (!(app.Context.CurrentHandler is Page) || 
            app.Request["HTTP_X_MICROSOFTAJAX"] != null) 
            return; 


        if (string.IsNullOrEmpty(acceptEncoding)) 
            return; 


        acceptEncoding = acceptEncoding.ToLower(); 


        if ((acceptEncoding.Contains("deflate") || acceptEncoding == "*") 
            && CompressScript(Request.ServerVariables["SCRIPT_NAME"])) 
        { 
            // deflate 
            app.Response.Filter = new DeflateStream(prevUncompressedStream, 
                CompressionMode.Compress); 
            app.Response.AppendHeader("Content-Encoding", "deflate"); 
        } 
        else if (acceptEncoding.Contains("gzip") 
            && CompressScript(Request.ServerVariables["SCRIPT_NAME"])) 
        { 
            // gzip 
            app.Response.Filter = new GZipStream(prevUncompressedStream, 
                CompressionMode.Compress); 
            app.Response.AppendHeader("Content-Encoding", "gzip"); 
        } 
    } 


    private static bool CompressScript(string scriptName) 
    { 
        if (scriptName.ToLower().Contains(".axd")) return false; 
        return true; 
    } 
</script>  