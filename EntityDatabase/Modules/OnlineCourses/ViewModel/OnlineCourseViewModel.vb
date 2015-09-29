Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OnlineCourses.ViewModel
    Public Class OnlineCourseViewModel
        Inherits ViewModelBase

        Private _OnlineCourses As ObservableCollection(Of OnlineCourse)
        Private dataAccess As IOnlineCourseService

        Public Property OnlineCourses As ObservableCollection(Of OnlineCourse)
            Get
                Return Me._OnlineCourses
            End Get
            Set(value As ObservableCollection(Of OnlineCourse))
                Me._OnlineCourses = value
                OnPropertyChanged("OnlineCourses")
            End Set
        End Property

        Private Function GetAllOnlineCourses() As IQueryable(Of OnlineCourse)
            Return Me.dataAccess.GetAllOnlineCourses
        End Function

        Sub New()

            Me._OnlineCourses = New ObservableCollection(Of OnlineCourse)

            ServiceLocator.RegisterService(Of IOnlineCourseService)(New OnlineCourseService)

            Me.dataAccess = GetService(Of IOnlineCourseService)()

            For Each element In Me.GetAllOnlineCourses
                Me._OnlineCourses.Add(element)
            Next
        End Sub
    End Class
End Namespace






