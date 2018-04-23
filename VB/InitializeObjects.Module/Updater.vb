Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

Namespace InitializeObjects.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal session As Session, ByVal currentDBVersion As Version)
			MyBase.New(session, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()

			Dim phone1 As PhoneNumber = Session.FindObject(Of PhoneNumber)(CriteriaOperator.Parse("Number = '555-0101'"))
			If phone1 Is Nothing Then
				phone1 = New PhoneNumber(Session)
				phone1.Number = "555-0101"
				phone1.PhoneType = "Home"
				phone1.Save()
			End If
			Dim phone2 As PhoneNumber = Session.FindObject(Of PhoneNumber)(CriteriaOperator.Parse("Number = '555-0102'"))
			If phone2 Is Nothing Then
				phone2 = New PhoneNumber(Session)
				phone2.Number = "555-0102"
				phone2.PhoneType = "Work"
				phone2.Save()
			End If
			Dim johnDoe As Contact = Session.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName = 'John' && LastName = 'Doe'"))
			If johnDoe Is Nothing Then
				johnDoe = New Contact(Session)
				johnDoe.FirstName = "John"
				johnDoe.LastName = "Doe"
				johnDoe.Save()
			End If
		End Sub
	End Class
End Namespace
