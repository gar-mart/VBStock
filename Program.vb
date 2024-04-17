Imports System
Imports System.Threading.Tasks
Imports StockVBConsole.Models.Entities
Imports StockVBConsole.Services

Module Program

    Sub Main()
        MainAsync().GetAwaiter().GetResult()
    End Sub

    Async Function MainAsync() As Task
        Dim r = Await FetchStockAsync("AAPL")
        Console.WriteLine(r)
    End Function

    Async Function FetchStockAsync(symbol As String) As Task(Of String)

        Dim ApiKey As String = "GN6SPTY8X4LGRVA0"
        Dim service As New AlphaVantageService(ApiKey)
        Dim stock As Stock = Await service.GetStockDataAsync(symbol)

        Dim s As String = stock.GenerateStockQuoteSummary()

        Return s


    End Function






End Module
