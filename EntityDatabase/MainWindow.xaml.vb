Imports Modules.Courses.ViewModels
Imports Modules.Departments.ViewModels
Imports Modules.OfficeAssignmets.ViewModel
Imports Modules.OnlineCourses.ViewModel
Imports Modules.OnsiteCourses.ViewModel
Imports Modules.Persons.ViewModel
Imports Modules.StudentGrades.ViewModel
Class MainWindow
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DepartmenstUserControl.MainGrid.DataContext = New DepartmentsViewModel()
        Me.CoursesUserControl.MainGrid.DataContext = New CourseViewModel()
        Me.OfficeAssignmentsUserControl.MainGrid.DataContext = New OfficeAssignmetsViewModel()
        Me.OnlineCoursesUserControl.MainGrid.DataContext = New OnlineCourseViewModel()
        Me.OnsiteCoursesUserControl.MainGrid.DataContext = New OnsiteCourseViewModel()
        'Me.StudentGradesUserControl.MainGrid.DataContext = New StudentGradesViewModel()


    End Sub
End Class
