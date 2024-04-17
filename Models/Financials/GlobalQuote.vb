Imports Newtonsoft.Json

Namespace Models.Financials

    Public Class GlobalQuote

        <JsonProperty("01. name")>
        Public Property Name As String

        <JsonProperty("02. open")>
        Public Property Open As String

        <JsonProperty("03. high")>
        Public Property High As String

        <JsonProperty("04. low")>
        Public Property Low As String

        <JsonProperty("05. price")>
        Public Property Price As String

        <JsonProperty("06. volume")>
        Public Property Volume As String

        <JsonProperty("07. latest trading day")>
        Public Property LatestTradingDay As String

        <JsonProperty("08. previous close")>
        Public Property PreviousClose As String

        <JsonProperty("09. change")>
        Public Property Change As String

        <JsonProperty("10. change percent")>
        Public Property ChangePercent As String

    End Class

    Public Class GlobalQuoteResponse

        <JsonProperty("Global Quote")>
        Public Property StockQuote As GlobalQuote

    End Class

End Namespace
