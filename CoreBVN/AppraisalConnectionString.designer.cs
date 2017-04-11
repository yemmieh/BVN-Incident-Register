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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AppraisalDb")]
	public partial class AppraisalConnectionStringDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertzib_workflow_master(zib_workflow_master instance);
    partial void Updatezib_workflow_master(zib_workflow_master instance);
    partial void Deletezib_workflow_master(zib_workflow_master instance);
    #endregion
		
		public AppraisalConnectionStringDataContext() : 
				base(global::CoreBVN.Properties.Settings.Default.AppraisalDbConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AppraisalConnectionStringDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AppraisalConnectionStringDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AppraisalConnectionStringDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AppraisalConnectionStringDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<zib_workflow_master> zib_workflow_masters
		{
			get
			{
				return this.GetTable<zib_workflow_master>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.zib_workflow_master")]
	public partial class zib_workflow_master : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _appid;
		
		private string _workflowid;
		
		private int _requeststageid;
		
		private string _requeststage;
		
		private string _requeststatus;
		
		private System.DateTime _createdt;
		
		private System.DateTime _editdt;
		
		private string _lastapprovername;
		
		private string _lastapprovernumber;
		
		private string _initiatorname;
		
		private string _initiatornumber;
		
		private string _unitname;
		
		private string _unitcode;
		
		private string _deptname;
		
		private string _deptcode;
		
		private string _groupname;
		
		private string _groupcode;
		
		private string _supergroupname;
		
		private string _supergroupcode;
		
		private System.Xml.Linq.XElement _approvalhistory;
		
		private System.Xml.Linq.XElement _audithistory;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnappidChanging(string value);
    partial void OnappidChanged();
    partial void OnworkflowidChanging(string value);
    partial void OnworkflowidChanged();
    partial void OnrequeststageidChanging(int value);
    partial void OnrequeststageidChanged();
    partial void OnrequeststageChanging(string value);
    partial void OnrequeststageChanged();
    partial void OnrequeststatusChanging(string value);
    partial void OnrequeststatusChanged();
    partial void OncreatedtChanging(System.DateTime value);
    partial void OncreatedtChanged();
    partial void OneditdtChanging(System.DateTime value);
    partial void OneditdtChanged();
    partial void OnlastapprovernameChanging(string value);
    partial void OnlastapprovernameChanged();
    partial void OnlastapprovernumberChanging(string value);
    partial void OnlastapprovernumberChanged();
    partial void OninitiatornameChanging(string value);
    partial void OninitiatornameChanged();
    partial void OninitiatornumberChanging(string value);
    partial void OninitiatornumberChanged();
    partial void OnunitnameChanging(string value);
    partial void OnunitnameChanged();
    partial void OnunitcodeChanging(string value);
    partial void OnunitcodeChanged();
    partial void OndeptnameChanging(string value);
    partial void OndeptnameChanged();
    partial void OndeptcodeChanging(string value);
    partial void OndeptcodeChanged();
    partial void OngroupnameChanging(string value);
    partial void OngroupnameChanged();
    partial void OngroupcodeChanging(string value);
    partial void OngroupcodeChanged();
    partial void OnsupergroupnameChanging(string value);
    partial void OnsupergroupnameChanged();
    partial void OnsupergroupcodeChanging(string value);
    partial void OnsupergroupcodeChanged();
    partial void OnapprovalhistoryChanging(System.Xml.Linq.XElement value);
    partial void OnapprovalhistoryChanged();
    partial void OnaudithistoryChanging(System.Xml.Linq.XElement value);
    partial void OnaudithistoryChanged();
    #endregion
		
		public zib_workflow_master()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_appid", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string appid
		{
			get
			{
				return this._appid;
			}
			set
			{
				if ((this._appid != value))
				{
					this.OnappidChanging(value);
					this.SendPropertyChanging();
					this._appid = value;
					this.SendPropertyChanged("appid");
					this.OnappidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_workflowid", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string workflowid
		{
			get
			{
				return this._workflowid;
			}
			set
			{
				if ((this._workflowid != value))
				{
					this.OnworkflowidChanging(value);
					this.SendPropertyChanging();
					this._workflowid = value;
					this.SendPropertyChanged("workflowid");
					this.OnworkflowidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_requeststageid", DbType="Int NOT NULL")]
		public int requeststageid
		{
			get
			{
				return this._requeststageid;
			}
			set
			{
				if ((this._requeststageid != value))
				{
					this.OnrequeststageidChanging(value);
					this.SendPropertyChanging();
					this._requeststageid = value;
					this.SendPropertyChanged("requeststageid");
					this.OnrequeststageidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_requeststage", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string requeststage
		{
			get
			{
				return this._requeststage;
			}
			set
			{
				if ((this._requeststage != value))
				{
					this.OnrequeststageChanging(value);
					this.SendPropertyChanging();
					this._requeststage = value;
					this.SendPropertyChanged("requeststage");
					this.OnrequeststageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_requeststatus", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string requeststatus
		{
			get
			{
				return this._requeststatus;
			}
			set
			{
				if ((this._requeststatus != value))
				{
					this.OnrequeststatusChanging(value);
					this.SendPropertyChanging();
					this._requeststatus = value;
					this.SendPropertyChanged("requeststatus");
					this.OnrequeststatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createdt", DbType="DateTime NOT NULL")]
		public System.DateTime createdt
		{
			get
			{
				return this._createdt;
			}
			set
			{
				if ((this._createdt != value))
				{
					this.OncreatedtChanging(value);
					this.SendPropertyChanging();
					this._createdt = value;
					this.SendPropertyChanged("createdt");
					this.OncreatedtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_editdt", DbType="DateTime NOT NULL")]
		public System.DateTime editdt
		{
			get
			{
				return this._editdt;
			}
			set
			{
				if ((this._editdt != value))
				{
					this.OneditdtChanging(value);
					this.SendPropertyChanging();
					this._editdt = value;
					this.SendPropertyChanged("editdt");
					this.OneditdtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastapprovername", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string lastapprovername
		{
			get
			{
				return this._lastapprovername;
			}
			set
			{
				if ((this._lastapprovername != value))
				{
					this.OnlastapprovernameChanging(value);
					this.SendPropertyChanging();
					this._lastapprovername = value;
					this.SendPropertyChanged("lastapprovername");
					this.OnlastapprovernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastapprovernumber", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string lastapprovernumber
		{
			get
			{
				return this._lastapprovernumber;
			}
			set
			{
				if ((this._lastapprovernumber != value))
				{
					this.OnlastapprovernumberChanging(value);
					this.SendPropertyChanging();
					this._lastapprovernumber = value;
					this.SendPropertyChanged("lastapprovernumber");
					this.OnlastapprovernumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_initiatorname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string initiatorname
		{
			get
			{
				return this._initiatorname;
			}
			set
			{
				if ((this._initiatorname != value))
				{
					this.OninitiatornameChanging(value);
					this.SendPropertyChanging();
					this._initiatorname = value;
					this.SendPropertyChanged("initiatorname");
					this.OninitiatornameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_initiatornumber", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string initiatornumber
		{
			get
			{
				return this._initiatornumber;
			}
			set
			{
				if ((this._initiatornumber != value))
				{
					this.OninitiatornumberChanging(value);
					this.SendPropertyChanging();
					this._initiatornumber = value;
					this.SendPropertyChanged("initiatornumber");
					this.OninitiatornumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_unitname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string unitname
		{
			get
			{
				return this._unitname;
			}
			set
			{
				if ((this._unitname != value))
				{
					this.OnunitnameChanging(value);
					this.SendPropertyChanging();
					this._unitname = value;
					this.SendPropertyChanged("unitname");
					this.OnunitnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_unitcode", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string unitcode
		{
			get
			{
				return this._unitcode;
			}
			set
			{
				if ((this._unitcode != value))
				{
					this.OnunitcodeChanging(value);
					this.SendPropertyChanging();
					this._unitcode = value;
					this.SendPropertyChanged("unitcode");
					this.OnunitcodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deptname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string deptname
		{
			get
			{
				return this._deptname;
			}
			set
			{
				if ((this._deptname != value))
				{
					this.OndeptnameChanging(value);
					this.SendPropertyChanging();
					this._deptname = value;
					this.SendPropertyChanged("deptname");
					this.OndeptnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deptcode", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string deptcode
		{
			get
			{
				return this._deptcode;
			}
			set
			{
				if ((this._deptcode != value))
				{
					this.OndeptcodeChanging(value);
					this.SendPropertyChanging();
					this._deptcode = value;
					this.SendPropertyChanged("deptcode");
					this.OndeptcodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_groupname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string groupname
		{
			get
			{
				return this._groupname;
			}
			set
			{
				if ((this._groupname != value))
				{
					this.OngroupnameChanging(value);
					this.SendPropertyChanging();
					this._groupname = value;
					this.SendPropertyChanged("groupname");
					this.OngroupnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_groupcode", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string groupcode
		{
			get
			{
				return this._groupcode;
			}
			set
			{
				if ((this._groupcode != value))
				{
					this.OngroupcodeChanging(value);
					this.SendPropertyChanging();
					this._groupcode = value;
					this.SendPropertyChanged("groupcode");
					this.OngroupcodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_supergroupname", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string supergroupname
		{
			get
			{
				return this._supergroupname;
			}
			set
			{
				if ((this._supergroupname != value))
				{
					this.OnsupergroupnameChanging(value);
					this.SendPropertyChanging();
					this._supergroupname = value;
					this.SendPropertyChanged("supergroupname");
					this.OnsupergroupnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_supergroupcode", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string supergroupcode
		{
			get
			{
				return this._supergroupcode;
			}
			set
			{
				if ((this._supergroupcode != value))
				{
					this.OnsupergroupcodeChanging(value);
					this.SendPropertyChanging();
					this._supergroupcode = value;
					this.SendPropertyChanged("supergroupcode");
					this.OnsupergroupcodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_approvalhistory", DbType="Xml NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Xml.Linq.XElement approvalhistory
		{
			get
			{
				return this._approvalhistory;
			}
			set
			{
				if ((this._approvalhistory != value))
				{
					this.OnapprovalhistoryChanging(value);
					this.SendPropertyChanging();
					this._approvalhistory = value;
					this.SendPropertyChanged("approvalhistory");
					this.OnapprovalhistoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_audithistory", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
		public System.Xml.Linq.XElement audithistory
		{
			get
			{
				return this._audithistory;
			}
			set
			{
				if ((this._audithistory != value))
				{
					this.OnaudithistoryChanging(value);
					this.SendPropertyChanging();
					this._audithistory = value;
					this.SendPropertyChanged("audithistory");
					this.OnaudithistoryChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591