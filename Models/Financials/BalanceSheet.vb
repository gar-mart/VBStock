Imports Newtonsoft.Json

Namespace Models.Financials


    Public Class BalanceSheet

        <JsonProperty("fiscalDateEnding")>
        Public Property FiscalDateEnding As String

        <JsonProperty("reportedCurrency")>
        Public Property ReportedCurrency As String

        <JsonProperty("totalAssets")>
        Public Property TotalAssets As String

        <JsonProperty("totalLiabilities")>
        Public Property TotalLiabilities As String

        <JsonProperty("totalShareholderEquity")>
        Public Property TotalShareholderEquity As String

        <JsonProperty("totalCurrentAssets")>
        Public Property TotalCurrentAssets As String

        <JsonProperty("totalCurrentLiabilities")>
        Public Property TotalCurrentLiabilities As String

        <JsonProperty("longTermDebt")>
        Public Property LongTermDebt As String

        <JsonProperty("cashAndCashEquivalentsAtCarryingValue")>
        Public Property CashAndEquivalents As String

        <JsonProperty("revenue")>
        Public Property Revenue As String

        <JsonProperty("netIncome")>
        Public Property NetIncome As String

    End Class

    Public Class BalanceSheetResponse

        <JsonProperty("annualReports")>
        Public Property AnnualReports As List(Of BalanceSheet)

    End Class

End Namespace
