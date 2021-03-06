﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreBVN
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Zenith")]
	public partial class XceedDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public XceedDataContext() : 
				base(global::CoreBVN.Properties.Settings.Default.ZenithConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public XceedDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public XceedDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public XceedDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public XceedDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<vw_employeeinfo> vw_employeeinfos
		{
			get
			{
				return this.GetTable<vw_employeeinfo>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vw_employeeinfo")]
	public partial class vw_employeeinfo
	{
		
		private string _employee_number;
		
		private string _name;
		
		private string _companyname;
		
		private int _employee_id;
		
		private System.Nullable<byte> _linemanager;
		
		private System.Nullable<byte> _emp_confirm;
		
		private System.Nullable<int> _grade_id;
		
		private System.Nullable<int> _department_id;
		
		private System.Nullable<System.DateTime> _employment_date;
		
		private System.Nullable<System.DateTime> _a_confirmdate;
		
		private System.Nullable<byte> _gender;
		
		private System.Nullable<byte> _marital_status;
		
		private string _title;
		
		private System.Nullable<byte> _employment_type;
		
		private System.Nullable<System.DateTime> _p_confirm_date;
		
		private string _unit;
		
		private System.Nullable<int> _status_id;
		
		private System.Nullable<System.DateTime> _last_promo_date;
		
		private string _maiden_name;
		
		private string _account_no;
		
		private string _nsitf_no;
		
		private string _nhf_no;
		
		private string _state;
		
		private System.Nullable<byte> _employee_status;
		
		private int _org_id;
		
		private string _dept;
		
		private string _paygroup;
		
		private string _lga;
		
		private System.Nullable<decimal> _annual_salary;
		
		private System.Nullable<int> _religion_id;
		
		private string _department_code;
		
		private string _grade;
		
		private System.Nullable<int> _ranking;
		
		private System.Nullable<System.DateTime> _date_of_birth;
		
		private System.Nullable<int> _title_id;
		
		private System.Nullable<int> _acting_title_id;
		
		private string _title_code;
		
		private string _jobtitle;
		
		private string _currency_name;
		
		private System.Nullable<int> _age;
		
		private System.Nullable<System.DateTime> _wedding_date;
		
		private System.Nullable<short> _len_service;
		
		private string _code;
		
		private System.Nullable<byte> _on_payroll;
		
		private string _Branch;
		
		private string _Branch_code;
		
		private string _random_hash;
		
		private System.Nullable<byte> _deferment;
		
		private System.Nullable<int> _analysis_id;
		
		private string _grade_code;
		
		private System.Nullable<byte> _step;
		
		private string _Category;
		
		private string _remark;
		
		private System.Nullable<int> _analysis_det_id;
		
		private System.Nullable<int> _paygroup_id;
		
		private System.Nullable<int> _state_id;
		
		private string _email;
		
		private string _employee_surname;
		
		private string _gsm;
		
		private string _mobile_phone;
		
		private string _office_ext;
		
		private string _employee_firstname;
		
		private string _employee_midname;
		
		private string _HEALTH_PLAN_CATEGORY;
		
		private System.Nullable<byte> _nsitf_entitled;
		
		private System.Nullable<byte> _nhf_entitled;
		
		private string _street1_r;
		
		private string _street2_r;
		
		private string _city_r;
		
		private string _country_r;
		
		private string _street1_p;
		
		private string _street2_p;
		
		private string _city_p;
		
		private string _logon_name;
		
		private System.Nullable<System.DateTime> _created_date;
		
		private string _homeplace;
		
		private string _employee_fileno;
		
		private string _country;
		
		private System.Nullable<int> _leaveBf;
		
		private System.Nullable<double> _leaveoutstanding;
		
		private System.Nullable<int> _total_leave_days;
		
		private string _state_code;
		
		private string _state_p;
		
		private string _state_r;
		
		private string _license_no;
		
		private string _license_type;
		
		private System.Nullable<System.DateTime> _license_date_issued;
		
		private System.Nullable<System.DateTime> _license_expires;
		
		private string _passport_no;
		
		private System.Nullable<System.DateTime> _passport_date_issued;
		
		private System.Nullable<System.DateTime> _passport_expires;
		
		private string _phone;
		
		private string _next_of_kin_name;
		
		public vw_employeeinfo()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employee_number", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string employee_number
		{
			get
			{
				return this._employee_number;
			}
			set
			{
				if ((this._employee_number != value))
				{
					this._employee_number = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(205)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_companyname", DbType="VarChar(100)")]
		public string companyname
		{
			get
			{
				return this._companyname;
			}
			set
			{
				if ((this._companyname != value))
				{
					this._companyname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employee_id", DbType="Int NOT NULL")]
		public int employee_id
		{
			get
			{
				return this._employee_id;
			}
			set
			{
				if ((this._employee_id != value))
				{
					this._employee_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_linemanager", DbType="TinyInt")]
		public System.Nullable<byte> linemanager
		{
			get
			{
				return this._linemanager;
			}
			set
			{
				if ((this._linemanager != value))
				{
					this._linemanager = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_emp_confirm", DbType="TinyInt")]
		public System.Nullable<byte> emp_confirm
		{
			get
			{
				return this._emp_confirm;
			}
			set
			{
				if ((this._emp_confirm != value))
				{
					this._emp_confirm = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_grade_id", DbType="Int")]
		public System.Nullable<int> grade_id
		{
			get
			{
				return this._grade_id;
			}
			set
			{
				if ((this._grade_id != value))
				{
					this._grade_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_department_id", DbType="Int")]
		public System.Nullable<int> department_id
		{
			get
			{
				return this._department_id;
			}
			set
			{
				if ((this._department_id != value))
				{
					this._department_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employment_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> employment_date
		{
			get
			{
				return this._employment_date;
			}
			set
			{
				if ((this._employment_date != value))
				{
					this._employment_date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_a_confirmdate", DbType="DateTime")]
		public System.Nullable<System.DateTime> a_confirmdate
		{
			get
			{
				return this._a_confirmdate;
			}
			set
			{
				if ((this._a_confirmdate != value))
				{
					this._a_confirmdate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gender", DbType="TinyInt")]
		public System.Nullable<byte> gender
		{
			get
			{
				return this._gender;
			}
			set
			{
				if ((this._gender != value))
				{
					this._gender = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_marital_status", DbType="TinyInt")]
		public System.Nullable<byte> marital_status
		{
			get
			{
				return this._marital_status;
			}
			set
			{
				if ((this._marital_status != value))
				{
					this._marital_status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="VarChar(100)")]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this._title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employment_type", DbType="TinyInt")]
		public System.Nullable<byte> employment_type
		{
			get
			{
				return this._employment_type;
			}
			set
			{
				if ((this._employment_type != value))
				{
					this._employment_type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_p_confirm_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> p_confirm_date
		{
			get
			{
				return this._p_confirm_date;
			}
			set
			{
				if ((this._p_confirm_date != value))
				{
					this._p_confirm_date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_unit", DbType="VarChar(100)")]
		public string unit
		{
			get
			{
				return this._unit;
			}
			set
			{
				if ((this._unit != value))
				{
					this._unit = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status_id", DbType="Int")]
		public System.Nullable<int> status_id
		{
			get
			{
				return this._status_id;
			}
			set
			{
				if ((this._status_id != value))
				{
					this._status_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_last_promo_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> last_promo_date
		{
			get
			{
				return this._last_promo_date;
			}
			set
			{
				if ((this._last_promo_date != value))
				{
					this._last_promo_date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maiden_name", DbType="VarChar(100)")]
		public string maiden_name
		{
			get
			{
				return this._maiden_name;
			}
			set
			{
				if ((this._maiden_name != value))
				{
					this._maiden_name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_account_no", DbType="VarChar(100)")]
		public string account_no
		{
			get
			{
				return this._account_no;
			}
			set
			{
				if ((this._account_no != value))
				{
					this._account_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nsitf_no", DbType="VarChar(100)")]
		public string nsitf_no
		{
			get
			{
				return this._nsitf_no;
			}
			set
			{
				if ((this._nsitf_no != value))
				{
					this._nsitf_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nhf_no", DbType="VarChar(100)")]
		public string nhf_no
		{
			get
			{
				return this._nhf_no;
			}
			set
			{
				if ((this._nhf_no != value))
				{
					this._nhf_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state", DbType="VarChar(8000)")]
		public string state
		{
			get
			{
				return this._state;
			}
			set
			{
				if ((this._state != value))
				{
					this._state = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employee_status", DbType="TinyInt")]
		public System.Nullable<byte> employee_status
		{
			get
			{
				return this._employee_status;
			}
			set
			{
				if ((this._employee_status != value))
				{
					this._employee_status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_org_id", DbType="Int NOT NULL")]
		public int org_id
		{
			get
			{
				return this._org_id;
			}
			set
			{
				if ((this._org_id != value))
				{
					this._org_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dept", DbType="VarChar(100)")]
		public string dept
		{
			get
			{
				return this._dept;
			}
			set
			{
				if ((this._dept != value))
				{
					this._dept = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_paygroup", DbType="VarChar(100)")]
		public string paygroup
		{
			get
			{
				return this._paygroup;
			}
			set
			{
				if ((this._paygroup != value))
				{
					this._paygroup = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lga", DbType="VarChar(100)")]
		public string lga
		{
			get
			{
				return this._lga;
			}
			set
			{
				if ((this._lga != value))
				{
					this._lga = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_annual_salary", DbType="Money")]
		public System.Nullable<decimal> annual_salary
		{
			get
			{
				return this._annual_salary;
			}
			set
			{
				if ((this._annual_salary != value))
				{
					this._annual_salary = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_religion_id", DbType="Int")]
		public System.Nullable<int> religion_id
		{
			get
			{
				return this._religion_id;
			}
			set
			{
				if ((this._religion_id != value))
				{
					this._religion_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_department_code", DbType="VarChar(100)")]
		public string department_code
		{
			get
			{
				return this._department_code;
			}
			set
			{
				if ((this._department_code != value))
				{
					this._department_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_grade", DbType="VarChar(100)")]
		public string grade
		{
			get
			{
				return this._grade;
			}
			set
			{
				if ((this._grade != value))
				{
					this._grade = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ranking", DbType="Int")]
		public System.Nullable<int> ranking
		{
			get
			{
				return this._ranking;
			}
			set
			{
				if ((this._ranking != value))
				{
					this._ranking = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_of_birth", DbType="DateTime")]
		public System.Nullable<System.DateTime> date_of_birth
		{
			get
			{
				return this._date_of_birth;
			}
			set
			{
				if ((this._date_of_birth != value))
				{
					this._date_of_birth = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title_id", DbType="Int")]
		public System.Nullable<int> title_id
		{
			get
			{
				return this._title_id;
			}
			set
			{
				if ((this._title_id != value))
				{
					this._title_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_acting_title_id", DbType="Int")]
		public System.Nullable<int> acting_title_id
		{
			get
			{
				return this._acting_title_id;
			}
			set
			{
				if ((this._acting_title_id != value))
				{
					this._acting_title_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title_code", DbType="VarChar(100)")]
		public string title_code
		{
			get
			{
				return this._title_code;
			}
			set
			{
				if ((this._title_code != value))
				{
					this._title_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_jobtitle", DbType="VarChar(100)")]
		public string jobtitle
		{
			get
			{
				return this._jobtitle;
			}
			set
			{
				if ((this._jobtitle != value))
				{
					this._jobtitle = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_currency_name", DbType="VarChar(100)")]
		public string currency_name
		{
			get
			{
				return this._currency_name;
			}
			set
			{
				if ((this._currency_name != value))
				{
					this._currency_name = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_wedding_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> wedding_date
		{
			get
			{
				return this._wedding_date;
			}
			set
			{
				if ((this._wedding_date != value))
				{
					this._wedding_date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_len_service", DbType="SmallInt")]
		public System.Nullable<short> len_service
		{
			get
			{
				return this._len_service;
			}
			set
			{
				if ((this._len_service != value))
				{
					this._len_service = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_code", DbType="VarChar(100)")]
		public string code
		{
			get
			{
				return this._code;
			}
			set
			{
				if ((this._code != value))
				{
					this._code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_on_payroll", DbType="TinyInt")]
		public System.Nullable<byte> on_payroll
		{
			get
			{
				return this._on_payroll;
			}
			set
			{
				if ((this._on_payroll != value))
				{
					this._on_payroll = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Branch", DbType="VarChar(100)")]
		public string Branch
		{
			get
			{
				return this._Branch;
			}
			set
			{
				if ((this._Branch != value))
				{
					this._Branch = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Branch_code", DbType="VarChar(100)")]
		public string Branch_code
		{
			get
			{
				return this._Branch_code;
			}
			set
			{
				if ((this._Branch_code != value))
				{
					this._Branch_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_random_hash", DbType="VarChar(200)")]
		public string random_hash
		{
			get
			{
				return this._random_hash;
			}
			set
			{
				if ((this._random_hash != value))
				{
					this._random_hash = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deferment", DbType="TinyInt")]
		public System.Nullable<byte> deferment
		{
			get
			{
				return this._deferment;
			}
			set
			{
				if ((this._deferment != value))
				{
					this._deferment = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_analysis_id", DbType="Int")]
		public System.Nullable<int> analysis_id
		{
			get
			{
				return this._analysis_id;
			}
			set
			{
				if ((this._analysis_id != value))
				{
					this._analysis_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_grade_code", DbType="VarChar(100)")]
		public string grade_code
		{
			get
			{
				return this._grade_code;
			}
			set
			{
				if ((this._grade_code != value))
				{
					this._grade_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_step", DbType="TinyInt")]
		public System.Nullable<byte> step
		{
			get
			{
				return this._step;
			}
			set
			{
				if ((this._step != value))
				{
					this._step = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="VarChar(100)")]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this._Category = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_remark", DbType="VarChar(250)")]
		public string remark
		{
			get
			{
				return this._remark;
			}
			set
			{
				if ((this._remark != value))
				{
					this._remark = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_analysis_det_id", DbType="Int")]
		public System.Nullable<int> analysis_det_id
		{
			get
			{
				return this._analysis_det_id;
			}
			set
			{
				if ((this._analysis_det_id != value))
				{
					this._analysis_det_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_paygroup_id", DbType="Int")]
		public System.Nullable<int> paygroup_id
		{
			get
			{
				return this._paygroup_id;
			}
			set
			{
				if ((this._paygroup_id != value))
				{
					this._paygroup_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state_id", DbType="Int")]
		public System.Nullable<int> state_id
		{
			get
			{
				return this._state_id;
			}
			set
			{
				if ((this._state_id != value))
				{
					this._state_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(100)")]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this._email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employee_surname", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string employee_surname
		{
			get
			{
				return this._employee_surname;
			}
			set
			{
				if ((this._employee_surname != value))
				{
					this._employee_surname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gsm", DbType="VarChar(100)")]
		public string gsm
		{
			get
			{
				return this._gsm;
			}
			set
			{
				if ((this._gsm != value))
				{
					this._gsm = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mobile_phone", DbType="VarChar(100)")]
		public string mobile_phone
		{
			get
			{
				return this._mobile_phone;
			}
			set
			{
				if ((this._mobile_phone != value))
				{
					this._mobile_phone = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_office_ext", DbType="VarChar(100)")]
		public string office_ext
		{
			get
			{
				return this._office_ext;
			}
			set
			{
				if ((this._office_ext != value))
				{
					this._office_ext = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employee_firstname", DbType="VarChar(100)")]
		public string employee_firstname
		{
			get
			{
				return this._employee_firstname;
			}
			set
			{
				if ((this._employee_firstname != value))
				{
					this._employee_firstname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employee_midname", DbType="VarChar(100)")]
		public string employee_midname
		{
			get
			{
				return this._employee_midname;
			}
			set
			{
				if ((this._employee_midname != value))
				{
					this._employee_midname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HEALTH_PLAN_CATEGORY", DbType="VarChar(100)")]
		public string HEALTH_PLAN_CATEGORY
		{
			get
			{
				return this._HEALTH_PLAN_CATEGORY;
			}
			set
			{
				if ((this._HEALTH_PLAN_CATEGORY != value))
				{
					this._HEALTH_PLAN_CATEGORY = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nsitf_entitled", DbType="TinyInt")]
		public System.Nullable<byte> nsitf_entitled
		{
			get
			{
				return this._nsitf_entitled;
			}
			set
			{
				if ((this._nsitf_entitled != value))
				{
					this._nsitf_entitled = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nhf_entitled", DbType="TinyInt")]
		public System.Nullable<byte> nhf_entitled
		{
			get
			{
				return this._nhf_entitled;
			}
			set
			{
				if ((this._nhf_entitled != value))
				{
					this._nhf_entitled = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_street1_r", DbType="VarChar(100)")]
		public string street1_r
		{
			get
			{
				return this._street1_r;
			}
			set
			{
				if ((this._street1_r != value))
				{
					this._street1_r = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_street2_r", DbType="VarChar(100)")]
		public string street2_r
		{
			get
			{
				return this._street2_r;
			}
			set
			{
				if ((this._street2_r != value))
				{
					this._street2_r = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city_r", DbType="VarChar(100)")]
		public string city_r
		{
			get
			{
				return this._city_r;
			}
			set
			{
				if ((this._city_r != value))
				{
					this._city_r = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_country_r", DbType="VarChar(100)")]
		public string country_r
		{
			get
			{
				return this._country_r;
			}
			set
			{
				if ((this._country_r != value))
				{
					this._country_r = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_street1_p", DbType="VarChar(100)")]
		public string street1_p
		{
			get
			{
				return this._street1_p;
			}
			set
			{
				if ((this._street1_p != value))
				{
					this._street1_p = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_street2_p", DbType="VarChar(100)")]
		public string street2_p
		{
			get
			{
				return this._street2_p;
			}
			set
			{
				if ((this._street2_p != value))
				{
					this._street2_p = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city_p", DbType="VarChar(100)")]
		public string city_p
		{
			get
			{
				return this._city_p;
			}
			set
			{
				if ((this._city_p != value))
				{
					this._city_p = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logon_name", DbType="VarChar(100)")]
		public string logon_name
		{
			get
			{
				return this._logon_name;
			}
			set
			{
				if ((this._logon_name != value))
				{
					this._logon_name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> created_date
		{
			get
			{
				return this._created_date;
			}
			set
			{
				if ((this._created_date != value))
				{
					this._created_date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_homeplace", DbType="VarChar(100)")]
		public string homeplace
		{
			get
			{
				return this._homeplace;
			}
			set
			{
				if ((this._homeplace != value))
				{
					this._homeplace = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employee_fileno", DbType="VarChar(10)")]
		public string employee_fileno
		{
			get
			{
				return this._employee_fileno;
			}
			set
			{
				if ((this._employee_fileno != value))
				{
					this._employee_fileno = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_country", DbType="VarChar(100)")]
		public string country
		{
			get
			{
				return this._country;
			}
			set
			{
				if ((this._country != value))
				{
					this._country = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_leaveBf", DbType="Int")]
		public System.Nullable<int> leaveBf
		{
			get
			{
				return this._leaveBf;
			}
			set
			{
				if ((this._leaveBf != value))
				{
					this._leaveBf = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_leaveoutstanding", DbType="Float")]
		public System.Nullable<double> leaveoutstanding
		{
			get
			{
				return this._leaveoutstanding;
			}
			set
			{
				if ((this._leaveoutstanding != value))
				{
					this._leaveoutstanding = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_total_leave_days", DbType="Int")]
		public System.Nullable<int> total_leave_days
		{
			get
			{
				return this._total_leave_days;
			}
			set
			{
				if ((this._total_leave_days != value))
				{
					this._total_leave_days = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state_code", DbType="VarChar(100)")]
		public string state_code
		{
			get
			{
				return this._state_code;
			}
			set
			{
				if ((this._state_code != value))
				{
					this._state_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state_p", DbType="VarChar(100)")]
		public string state_p
		{
			get
			{
				return this._state_p;
			}
			set
			{
				if ((this._state_p != value))
				{
					this._state_p = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state_r", DbType="VarChar(100)")]
		public string state_r
		{
			get
			{
				return this._state_r;
			}
			set
			{
				if ((this._state_r != value))
				{
					this._state_r = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_license_no", DbType="VarChar(100)")]
		public string license_no
		{
			get
			{
				return this._license_no;
			}
			set
			{
				if ((this._license_no != value))
				{
					this._license_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_license_type", DbType="VarChar(100)")]
		public string license_type
		{
			get
			{
				return this._license_type;
			}
			set
			{
				if ((this._license_type != value))
				{
					this._license_type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_license_date_issued", DbType="DateTime")]
		public System.Nullable<System.DateTime> license_date_issued
		{
			get
			{
				return this._license_date_issued;
			}
			set
			{
				if ((this._license_date_issued != value))
				{
					this._license_date_issued = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_license_expires", DbType="DateTime")]
		public System.Nullable<System.DateTime> license_expires
		{
			get
			{
				return this._license_expires;
			}
			set
			{
				if ((this._license_expires != value))
				{
					this._license_expires = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_passport_no", DbType="VarChar(100)")]
		public string passport_no
		{
			get
			{
				return this._passport_no;
			}
			set
			{
				if ((this._passport_no != value))
				{
					this._passport_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_passport_date_issued", DbType="DateTime")]
		public System.Nullable<System.DateTime> passport_date_issued
		{
			get
			{
				return this._passport_date_issued;
			}
			set
			{
				if ((this._passport_date_issued != value))
				{
					this._passport_date_issued = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_passport_expires", DbType="DateTime")]
		public System.Nullable<System.DateTime> passport_expires
		{
			get
			{
				return this._passport_expires;
			}
			set
			{
				if ((this._passport_expires != value))
				{
					this._passport_expires = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="VarChar(100)")]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this._phone = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_next_of_kin_name", DbType="VarChar(100)")]
		public string next_of_kin_name
		{
			get
			{
				return this._next_of_kin_name;
			}
			set
			{
				if ((this._next_of_kin_name != value))
				{
					this._next_of_kin_name = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
