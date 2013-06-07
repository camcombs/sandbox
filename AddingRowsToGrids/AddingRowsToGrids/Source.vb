Public Class Source

    Private _sourceID As String
    Public Property SourceID() As String
        Get
            Return _sourceID
        End Get
        Set(ByVal value As String)
            _sourceID = value
        End Set
    End Property


    Private _sourceTypeCode As String
    Public Property SourceTypeCode() As String
        Get
            Return _sourceTypeCode
        End Get
        Set(ByVal value As String)
            _sourceTypeCode = value
        End Set
    End Property

End Class