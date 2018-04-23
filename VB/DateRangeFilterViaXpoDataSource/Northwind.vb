Imports Microsoft.VisualBasic
	Imports System
	Imports DevExpress.Xpo
Namespace Northwind

	<Persistent("Customers")> _
	Public Class Customer
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private customerID_Renamed As String

		<Key> _
		Public Property CustomerID() As String
			Get
				Return customerID_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("CustomerID", customerID_Renamed, value)
			End Set
		End Property

		Private contactTitle_Renamed As String
		Public Property ContactTitle() As String
			Get
				Return contactTitle_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("ContactTitle", contactTitle_Renamed, value)
			End Set
		End Property

		Private companyName_Renamed As String
		Public Property CompanyName() As String
			Get
				Return companyName_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("CompanyName", companyName_Renamed, value)
			End Set
		End Property

	Private address_Renamed As String
		Public Property Address() As String
			Get
				Return address_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Address", address_Renamed, value)
			End Set
		End Property

		<Association("CustomerOrders", GetType(Order))> _
		Public ReadOnly Property Orders() As XPCollection(Of Order)
			Get
				Return GetCollection(Of Order)("Orders")
			End Get
		End Property
	End Class

	<Persistent("Orders")> _
	Public Class Order
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Key(True), Persistent> _
		Private OrderID As Integer

		<PersistentAlias("OrderID")> _
		Public ReadOnly Property ID() As Integer
			Get
				Return OrderID
			End Get
		End Property

		Private shippedDate_Renamed As DateTime
		Public Property ShippedDate() As DateTime
			Get
				Return shippedDate_Renamed
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue("ShippedDate", shippedDate_Renamed, value)
			End Set
		End Property

		Private customer_Renamed As Customer
		<Persistent("CustomerID"), Association("CustomerOrders")> _
		Public Property Customer() As Customer
			Get
				Return customer_Renamed
			End Get
			Set(ByVal value As Customer)
				SetPropertyValue("Customer", customer_Renamed, value)
			End Set
		End Property
	End Class

	<Persistent("Employees")> _
	Public Class Employee
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Key(True), Persistent> _
		Public EmployeeID As Integer

		Private _FirstName As String
		Public Property FirstName() As String
			Get
				Return _FirstName
			End Get
			Set(ByVal value As String)
				SetPropertyValue("FirstName", _FirstName, value)
			End Set
		End Property
		Private _LastName As String
		Public Property LastName() As String
			Get
				Return _LastName
			End Get
			Set(ByVal value As String)
				SetPropertyValue("LastName", _LastName, value)
			End Set
		End Property

		<PersistentAlias("Concat([FirstName], ' ', [LastName])")> _
		Public ReadOnly Property FullName() As String
			Get
				Return CStr(EvaluateAlias("FullName"))
			End Get
		End Property
	End Class
End Namespace
