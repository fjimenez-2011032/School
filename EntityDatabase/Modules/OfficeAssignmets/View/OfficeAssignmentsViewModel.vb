Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OfficeAssignmets.ViewModel
    Public Class OfficeAssignmetsViewModel
        Inherits ViewModelBase

        Private _OfficeAssignmets As ObservableCollection(Of OfficeAssignment)
        Private dataAccess As IOfficeAssignmentService

        Public Property OfficeAssignments As ObservableCollection(Of OfficeAssignment)
            Get
                Return Me._OfficeAssignmets
            End Get
            Set(value As ObservableCollection(Of OfficeAssignment))
                Me._OfficeAssignmets = value
                OnPropertyChanged("OfficeAssignmets")
            End Set
        End Property

        Private Function GetAllOfficeAssignmets() As IQueryable(Of OfficeAssignment)
            Return Me.dataAccess.GetAllOfficeAssignment
        End Function

        Sub New()

            Me._OfficeAssignmets = New ObservableCollection(Of OfficeAssignment)

            ServiceLocator.RegisterService(Of IOfficeAssignmentService)(New OfficeAssignmentService)

            Me.dataAccess = GetService(Of IOfficeAssignmentService)()

            For Each element In Me.GetAllOfficeAssignmets
                Me._OfficeAssignmets.Add(element)
            Next
        End Sub
    End Class
End Namespace

