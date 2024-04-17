Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Newtonsoft.Json
Imports StockVBConsole.Models.Financials

Namespace Models.Entities

    Public Class Stock

        Public Sub New()
        End Sub

        Public Sub New(symbol As String)
            Me.Symbol = symbol
        End Sub

        Public Property Symbol As String
        Public Property Name As String

        <JsonProperty("Global Quote")>
        Public Property StockQuote As GlobalQuote

        Public Property BalanceSheet As List(Of BalanceSheet)


        Public Property Cashflow As List(Of Cashflow)
        Public Function GenerateStockQuoteSummary() As String
            Dim summary As New StringBuilder()
            If StockQuote IsNot Nothing Then
                summary.AppendLine($"Current Price: {StockQuote.Price}")
                summary.AppendLine($"Day's High: {StockQuote.High}")
                summary.AppendLine($"Day's Low: {StockQuote.Low}")
                summary.AppendLine($"Volume: {StockQuote.Volume}")
                summary.AppendLine($"Change: {StockQuote.Change} ({StockQuote.ChangePercent})")
                summary.AppendLine()
            End If
            Return summary.ToString()
        End Function

        Public Function GenerateLatestAnnualReportSummary() As String
            Dim summary As New StringBuilder()
            Dim latestAnnualReport = BalanceSheet.OrderByDescending(Function(r) r.FiscalDateEnding).FirstOrDefault()
            If latestAnnualReport IsNot Nothing Then
                summary.AppendLine($"Latest Fiscal Year Ending: {latestAnnualReport.FiscalDateEnding}")
                summary.AppendLine($"Total Assets: {latestAnnualReport.TotalAssets:N0}")
                summary.AppendLine($"Total Liabilities: {latestAnnualReport.TotalLiabilities:N0}")
                summary.AppendLine($"Total Shareholder Equity: {latestAnnualReport.TotalShareholderEquity:N0}")
                summary.AppendLine($"Revenue: {latestAnnualReport.Revenue:N0}")
                summary.AppendLine($"Net Income: {latestAnnualReport.NetIncome:N0}")
                summary.AppendLine()
            End If
            Return summary.ToString()
        End Function

        Public Function GenerateCashFlowSummary() As String
            Dim summary As New StringBuilder()

            Dim latestCashFlowReport = Cashflow.OrderByDescending(Function(c) c.FiscalDateEnding).FirstOrDefault()

            If latestCashFlowReport IsNot Nothing Then
                summary.AppendLine("Cash Flow Summary")
                summary.AppendLine($"Fiscal Date Ending: {latestCashFlowReport.FiscalDateEnding}")
                summary.AppendLine($"Operating Cashflow: {latestCashFlowReport.OperatingCashflow}")
                summary.AppendLine($"Capital Expenditures: {latestCashFlowReport.CapitalExpenditures}")
                summary.AppendLine($"Dividend Payout: {latestCashFlowReport.DividendPayout}")
                summary.AppendLine($"Net Income: {latestCashFlowReport.NetIncome}")
                summary.AppendLine($"Cashflow from Investment: {latestCashFlowReport.CashflowFromInvestment}")
                summary.AppendLine($"Cashflow from Financing: {latestCashFlowReport.CashflowFromFinancing}")
                summary.AppendLine($"Proceeds from Issuance of Common Stock: {latestCashFlowReport.ProceedsFromIssuanceOfCommonStock}")
                summary.AppendLine($"Payments for Repurchase of Equity: {latestCashFlowReport.PaymentsForRepurchaseOfEquity}")
                summary.AppendLine($"Change in Cash and Cash Equivalents: {latestCashFlowReport.ChangeInCashAndCashEquivalents}")
                summary.AppendLine()
            Else
                summary.AppendLine("No cash flow data available.")
            End If

            Return summary.ToString()
        End Function

    End Class

End Namespace
