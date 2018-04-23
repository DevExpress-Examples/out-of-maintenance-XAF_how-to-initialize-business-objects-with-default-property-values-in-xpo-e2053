Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace InitializeObjects.Module
	<DefaultClassOptions> _
	Public Class Contact
		Inherits Person
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Public Property TitleOfCourtesy() As TitleOfCourtesy
			Get
				Return GetPropertyValue(Of TitleOfCourtesy)("TitleOfCourtesy")
			End Get
			Set(ByVal value As TitleOfCourtesy)
				SetPropertyValue(Of TitleOfCourtesy)("TitleOfCourtesy", value)
			End Set
		End Property
		Public Property Manager() As Contact
			Get
				Return GetPropertyValue(Of Contact)("Manager")
			End Get
			Set(ByVal value As Contact)
				SetPropertyValue(Of Contact)("Manager", value)
			End Set
		End Property
		Public Overrides Sub AfterConstruction()
			MyBase.AfterConstruction()

			FirstName = "Sam"
			TitleOfCourtesy = TitleOfCourtesy.Mr

			Address1 = New Address(Session)
			Address1.Country = Session.FindObject(Of Country)(CriteriaOperator.Parse("Name = 'USA'"))
			If Address1.Country Is Nothing Then
				Address1.Country = New Country(Session)
				Address1.Country.Name = "USA"
				Address1.Country.Save()
			End If

			Manager = Session.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName = 'John' && LastName = 'Doe'"))

			Dim phone1 As PhoneNumber = Session.FindObject(Of PhoneNumber)(CriteriaOperator.Parse("Number = '555-0101'"))
			Dim phone2 As PhoneNumber = Session.FindObject(Of PhoneNumber)(CriteriaOperator.Parse("Number = '555-0102'"))
			PhoneNumbers.Add(phone1)
			PhoneNumbers.Add(phone2)
		End Sub
	End Class
	Public Enum TitleOfCourtesy
		Dr
		Miss
		Mr
		Mrs
		Ms
	End Enum
End Namespace
