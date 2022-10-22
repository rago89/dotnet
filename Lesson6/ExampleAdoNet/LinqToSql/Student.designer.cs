﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinqToSql
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HackYourFuture")]
	public partial class StudentDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public StudentDataContext() : 
				base(global::LinqToSql.Properties.Settings.Default.HackYourFutureConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Student> Students
		{
			get
			{
				return this.GetTable<Student>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Student")]
	public partial class Student
	{
		
		private System.Nullable<int> _student_id;
		
		private string _name;
		
		private System.Nullable<int> _age;
		
		public Student()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_student_id", DbType="Int")]
		public System.Nullable<int> student_id
		{
			get
			{
				return this._student_id;
			}
			set
			{
				if ((this._student_id != value))
				{
					this._student_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(100)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_age", DbType="Int")]
		public System.Nullable<int> age
		{
			get
			{
				return this._age;
			}
			set
			{
				if ((this._age != value))
				{
					this._age = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
