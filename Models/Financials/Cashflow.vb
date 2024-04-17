Imports Newtonsoft.Json

Namespace Models.Financials
    Public Class Cashflow

        <JsonProperty("fiscalDateEnding")>
        Public Property FiscalDateEnding As String

        <JsonProperty("operatingCashflow")>
        Public Property OperatingCashflow As String

        <JsonProperty("capitalExpenditures")>
        Public Property CapitalExpenditures As String

        <JsonProperty("dividendPayout")>
        Public Property DividendPayout As String

        <JsonProperty("netIncome")>
        Public Property NetIncome As String

        <JsonProperty("cashflowFromInvestment")>
        Public Property CashflowFromInvestment As String

        <JsonProperty("cashflowFromFinancing")>
        Public Property CashflowFromFinancing As String

        <JsonProperty("proceedsFromIssuanceOfCommonStock")>
        Public Property ProceedsFromIssuanceOfCommonStock As String

        <JsonProperty("paymentsForRepurchaseOfEquity")>
        Public Property PaymentsForRepurchaseOfEquity As String

        <JsonProperty("changeInCashAndCashEquivalents")>
        Public Property ChangeInCashAndCashEquivalents As String

    End Class

    Public Class CashFlowResponse

        <JsonProperty("annualReports")>
        Public Property AnnualReports As List(Of Cashflow)

    End Class

End Namespace
