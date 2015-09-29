Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.StudentGrades.ViewModel
    Public Class StudentGradesViewModel
        Inherits ViewModelBase

        Private _studentGrades As ObservableCollection(Of StudentGrade)
        Private dataAccess As IStudentGradeService

        Public Property StudentGrades As ObservableCollection(Of StudentGrade)
            Get
                Return Me._studentGrades
            End Get
            Set(value As ObservableCollection(Of StudentGrade))
                Me._studentGrades = value
                OnPropertyChanged("StudentGrades")
            End Set
        End Property

        ' Function to get all StudentGrades from service
        Private Function GetAllStudentGrades() As IQueryable(Of StudentGrade)
            Return Me.dataAccess.GetAllStudentGrades
        End Function

        Sub New()
            'Initialize property variable of courses
            Me._studentGrades = New ObservableCollection(Of StudentGrade)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IStudentGradeService)(New StudentGrade)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IStudentGradeService)()
            ' Populate courses property variable 
            For Each element In Me.GetAllStudentGrades
                Me._studentGrades.Add(element)
            Next
        End Sub
    End Class
End Namespace