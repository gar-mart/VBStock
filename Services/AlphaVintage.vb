Imports System
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Threading.Tasks
Imports StockVBConsole.Models.Entities
Imports StockVBConsole.Models.Financials

Namespace Services


    Public Class AlphaVantageService
        Private ReadOnly _httpClient As HttpClient
        Private ReadOnly _apiKey As String

        Public Sub New(apiKey As String)
            _httpClient = New HttpClient()
            _httpClient.BaseAddress = New Uri("https://www.alphavantage.co/")
            _apiKey = apiKey
        End Sub

        Public Async Function GetStockDataAsync(symbol As String) As Task(Of Stock)
            Dim stock As New Stock()
            stock.Symbol = symbol

            ' Fetch Stock Quote

            Try
                stock.StockQuote = Await GetGlobalQuoteAsync(symbol)
            Catch ex As Exception
                stock.StockQuote = Nothing
            End Try

            ' Fetch Balance Sheet

            Try
                stock.BalanceSheet = Await GetBalanceSheetAsync(symbol)
            Catch ex As Exception
                stock.BalanceSheet = Nothing
            End Try

           ' Fetch Cashflow
            Try
                stock.Cashflow = Await GetCashFlowAsync(symbol)
            Catch ex As Exception
                stock.Cashflow = Nothing
            End Try

            Return stock
        End Function

        ' Get API response based on url
        Private Async Function GetApiResponseAsync(url As String) As Task(Of String)
            Dim response As HttpResponseMessage = Await _httpClient.GetAsync(url)
            If Not response.IsSuccessStatusCode Then
                Throw New HttpRequestException($"Error fetching data: {response.StatusCode}")
            End If
            Return Await response.Content.ReadAsStringAsync()


        End Function


        Private Async Function GetGlobalQuoteAsync(symbol As String) As Task(Of GlobalQuote)
            Dim url As String = $"query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={_apiKey}"
            Dim content As String = Await GetApiResponseAsync(url)
            Dim responseData = JsonConvert.DeserializeObject(Of GlobalQuoteResponse)(content)
            Return responseData.StockQuote
        End Function

        Public Async Function GetBalanceSheetAsync(symbol As String) As Task(Of List(Of BalanceSheet))
            Dim url As String = $"query?function=BALANCE_SHEET&symbol={symbol}&apikey={_apiKey}"
            Dim content As String = Await GetApiResponseAsync(url)
            Dim responseData = JsonConvert.DeserializeObject(Of BalanceSheetResponse)(content)
            Return responseData.AnnualReports
        End Function



        Public Async Function GetCashFlowAsync(symbol As String) As Task(Of List(Of Cashflow))
            Dim url As String = $"query?function=CASH_FLOW&symbol={symbol}&apikey={_apiKey}"
            Dim content As String = Await GetApiResponseAsync(url)
            Dim responseData = JsonConvert.DeserializeObject(Of CashFlowResponse)(content)
            Return responseData.AnnualReports
        End Function
        Public Function GetURL(symbol As String) As String
            Dim url As String = $"query?function=OVERVIEW&symbol={symbol}&apikey={_apiKey}"

            Return _httpClient.BaseAddress.AbsoluteUri + url

        End Function
    End Class
End Namespace

