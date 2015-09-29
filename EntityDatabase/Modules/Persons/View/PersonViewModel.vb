Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.Persons.ViewModel
    Public Class PersonViewModel

        Inherits ViewModelBase

        Private _persons As ObservableCollection(Of Person)
        Private dataAccess As IPersonsService

        Public Property person As ObservableCollection(Of Person)
            Get
                Return Me._persons
            End Get
            Set(value As ObservableCollection(Of Person))
                Me._persons = value
                OnPropertyChanged("persons")
            End Set
        End Property

        Private Function GetAllPersons() As IQueryable(Of Person)
            Return Me.dataAccess.GetAllpersons
        End Function

        Sub New()

            Me._persons = New ObservableCollection(Of Person)

            ServiceLocator.RegisterService(Of IPersonsService)(New PersonService)

            Me.dataAccess = GetService(Of IPersonsService)()

            For Each element In Me.GetAllPersons
                Me._persons.Add(element)
            Next
        End Sub
    End Class
End Namespace