Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Services
Imports Newtonsoft.Json

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class JsonService
    Inherits System.Web.Services.WebService

    <WebMethod()>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json, XmlSerializeString:=False)>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json, XmlSerializeString:=False)>
    Public Function GetJson() As String
        Dim example As New Employee
        With example
            .Name = "Ivan"
            .LastName = "Ivanovich"
            .Age = 45
            .Country = "Ukraine"
        End With

        Dim json = JsonConvert.SerializeObject(example)
        Context.Response.Write(json)
        Context.Response.End()
        Return json
    End Function
End Class

Public Class Employee
    Public Name As String
    Public LastName As String
    Public Age As Integer
    Public Country As String
End Class
