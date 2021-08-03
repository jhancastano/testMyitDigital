Imports System
Imports System.Net
Imports System.Web.Http
Imports Newtonsoft.Json.Linq
Imports System.Data.SqlClient
Imports System.Web.Configuration


Public Class CriptoController
    Inherits ApiController

    ' GET api/cripto
    Public Function GetValues() As JObject
        Dim BTC As String = "Data[0]"
        Dim THETER As String = "Data[3]"
        Dim NAME As String = ".CoinInfo.FullName"
        Dim PRICE As String = ".RAW.COP.PRICE"
        Dim HIGHDAY As String = ".RAW.COP.HIGHDAY"
        Dim LOWDAY As String = ".RAW.COP.LOWDAY"
        Dim CHANGEPCT24HOUR As String = ".RAW.COP.CHANGEPCT24HOUR"
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("connDB").ConnectionString
        Dim cn As New SqlConnection(connectionString)

        Dim webClient As New WebClient
        Dim result As String = webClient.DownloadString("https://min-api.cryptocompare.com/data/top/mktcapfull?limit=10&tsym=COP")
        Dim jsonBTC As JObject = New JObject(New JProperty("NAME", JObject.Parse(result).SelectToken(BTC + NAME)),
                                             New JProperty("PRICE", JObject.Parse(result).SelectToken(BTC + PRICE)),
                                             New JProperty("HIGHDAY", JObject.Parse(result).SelectToken(BTC + HIGHDAY)),
                                             New JProperty("LOWDAY", JObject.Parse(result).SelectToken(BTC + LOWDAY)),
                                             New JProperty("CHANGEPCT24HOUR", JObject.Parse(result).SelectToken(BTC + CHANGEPCT24HOUR)))

        Dim jsonTHETER As JObject = New JObject(New JProperty("NAME", JObject.Parse(result).SelectToken(THETER + NAME)),
                                             New JProperty("PRICE", JObject.Parse(result).SelectToken(THETER + PRICE)),
                                             New JProperty("HIGHDAY", JObject.Parse(result).SelectToken(THETER + HIGHDAY)),
                                             New JProperty("LOWDAY", JObject.Parse(result).SelectToken(THETER + LOWDAY)),
                                             New JProperty("CHANGEPCT24HOUR", JObject.Parse(result).SelectToken(THETER + CHANGEPCT24HOUR)))
        Dim Array As JArray = New JArray()
        Array.Add(jsonBTC)
        Array.Add(jsonTHETER)

        Dim THETERname As String = JObject.Parse(result).SelectToken(THETER + NAME)
        Dim THETERprice As String = JObject.Parse(result).SelectToken(THETER + PRICE)
        Dim THETERhighday As String = JObject.Parse(result).SelectToken(THETER + HIGHDAY)
        Dim THETERlowday As String = JObject.Parse(result).SelectToken(THETER + LOWDAY)
        Dim THETERchangepct24hour As String = JObject.Parse(result).SelectToken(THETER + CHANGEPCT24HOUR)


        Dim BTCname As String = JObject.Parse(result).SelectToken(BTC + NAME)
        Dim BTCprice As String = JObject.Parse(result).SelectToken(BTC + PRICE)
        Dim BTChighday As String = JObject.Parse(result).SelectToken(BTC + HIGHDAY)
        Dim BTClowday As String = JObject.Parse(result).SelectToken(BTC + LOWDAY)
        Dim BTCchangepct24hour As String = JObject.Parse(result).SelectToken(BTC + CHANGEPCT24HOUR)

        Dim jResponse As JObject = New JObject(New JProperty("Data", Array))

        Try
            cn.Open()

            Dim fecha As String = DateTime.Now.ToString("dd/MM/yyyy")
            Dim hora As String = DateTime.Now.ToString("hh:mm:ss")

            Dim CONSULTA As String = "INSERT INTO [dbo].[criptoHistoric]([Nombre]
           ,[PRICE]
           ,[HIGHDAY]
           ,[LOWDAY]
           ,[CHANGEPCT24HOUR]
           ,[DATEOPERATION]
           ,[HOUROPERATION])VALUES('" + BTCname + "','" + BTCprice + "','" + BTChighday + "','" + BTClowday + "','" + BTCchangepct24hour + "','" + fecha + "','" + hora + "')"
            Dim CONSULTA2 As String = "INSERT INTO [dbo].[criptoHistoric]([Nombre]
           ,[PRICE]
           ,[HIGHDAY]
           ,[LOWDAY]
           ,[CHANGEPCT24HOUR]
           ,[DATEOPERATION]
           ,[HOUROPERATION])VALUES('" + THETERname + "','" + THETERprice + "','" + THETERhighday + "','" + THETERlowday + "','" + THETERchangepct24hour + "','" + fecha + "','" + hora + "')"

            Dim comando As SqlCommand
            comando = New SqlCommand(CONSULTA, cn)
            comando.ExecuteNonQuery()
            comando = New SqlCommand(CONSULTA2, cn)
            comando.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            Console.WriteLine("No se puede conectar!")
            cn.Close()
        End Try


        Return jResponse
    End Function

    ' GET api/cripto/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/cripto
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/cripto/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/cripto/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
