namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class PowerTransformerConverter
	{

		#region Populate ResourceDescription
		//public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		//{
		//	if ((cimIdentifiedObject != null) && (rd != null))
		//	{
		//		if (cimIdentifiedObject.MRIDHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
		//		}
		//		if (cimIdentifiedObject.NameHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.IDOBJ_NAME, cimIdentifiedObject.Name));
		//		}
		//		if (cimIdentifiedObject.DescriptionHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.IDOBJ_DESCRIPTION, cimIdentifiedObject.Description));
		//		}
		//	}
		//}

		//public static void PopulateLocationProperties(FTN.Location cimLocation, ResourceDescription rd)
		//{
		//	if ((cimLocation != null) && (rd != null))
		//	{
		//		PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimLocation, rd);

		//		if (cimLocation.CategoryHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.LOCATION_CATEGORY, cimLocation.Category));
		//		}
		//		if (cimLocation.CorporateCodeHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.LOCATION_CORPORATECODE, cimLocation.CorporateCode));
		//		}
		//	}
		//}

		//public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		//{
		//	if ((cimPowerSystemResource != null) && (rd != null))
		//	{
		//		PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);

		//		if (cimPowerSystemResource.CustomTypeHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.PSR_CUSTOMTYPE, cimPowerSystemResource.CustomType));
		//		}
		//		if (cimPowerSystemResource.LocationHasValue)
		//		{
		//			long gid = importHelper.GetMappedGID(cimPowerSystemResource.Location.ID);
		//			if (gid < 0)
		//			{
		//				report.Report.Append("WARNING: Convert ").Append(cimPowerSystemResource.GetType().ToString()).Append(" rdfID = \"").Append(cimPowerSystemResource.ID);
		//				report.Report.Append("\" - Failed to set reference to Location: rdfID \"").Append(cimPowerSystemResource.Location.ID).AppendLine(" \" is not mapped to GID!");
		//			}
		//			rd.AddProperty(new Property(ModelCode.PSR_LOCATION, gid));
		//		}
		//	}
		//}



		public static void PopulateIdentifiedObjectProperties(IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{
				// nema nista
			}
		}

		public static void PopulatePowerSystemResourceProperties(PowerSystemResource cimPowerSystemResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimPowerSystemResource != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);
			}
		}
		
		public static void PopulateEquipmentContainerProperties(EquipmentContainer cimEquipmentContainer, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimEquipmentContainer != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateConnectivityNodeContainerProperties(cimEquipmentContainer, rd, importHelper, report);
			}
		}

		public static void PopulateSwitchProperties(Switch cimSwitch, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimSwitch != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateConductingEquipmentProperties(cimSwitch, rd, importHelper, report);

				if (cimSwitch.NormalOpenHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SWITCH_NORMOPEN, cimSwitch.NormalOpen));
				}
				if (cimSwitch.RetainedHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SWITCH_RETAINED, cimSwitch.Retained));
				}
				if (cimSwitch.SwitchOnCountHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SWITCH_SWONCOUNT, cimSwitch.SwitchOnCount));
				}
				if (cimSwitch.SwitchOnDateHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SWITCH_SWONDATE, cimSwitch.SwitchOnDate));
				}
				if (cimSwitch.EquipmentContainerHasValue)
				{
					// GID EquipmentContainer-a koji je prethodno vec ubacen u deltu
					long gid = importHelper.GetMappedGID(cimSwitch.EquipmentContainer.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimSwitch.GetType().ToString()).Append(" rdfID = \"").Append(cimSwitch.ID);
						report.Report.Append("\" - Failed to set reference to EquipmentContainer: rdfID \"").Append(cimSwitch.EquipmentContainer.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.EQUIPMENT_EQCONTAINER, gid));
				}
			}
		}

		public static void PopulateConnectivityNodeProperties(ConnectivityNode cimConnectivityNode, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimConnectivityNode != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimConnectivityNode, rd);

				if (cimConnectivityNode.ConnectivityNodeContainerHasValue)
				{
					long gid = importHelper.GetMappedGID(cimConnectivityNode.ConnectivityNodeContainer.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimConnectivityNode.GetType().ToString()).Append(" rdfID = \"").Append(cimConnectivityNode.ID);
						report.Report.Append("\" - Failed to set reference to ConnectivityNodeContainer: rdfID \"").Append(cimConnectivityNode.ConnectivityNodeContainer.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.CONNODE_CONNODECONTAINER, gid));
				}
			}
		}

		public static void PopulateTerminalProperties(Terminal cimTerminal, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimTerminal != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTerminal, rd);

				
				if (cimTerminal.ConnectivityNodeHasValue)
				{
					long gid = importHelper.GetMappedGID(cimTerminal.ConnectivityNode.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
						report.Report.Append("\" - Failed to set reference to ConnectivityNode: rdfID \"").Append(cimTerminal.ConnectivityNode.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.TERMINAL_CONNODE, gid));
				}
				if (cimTerminal.ConductingEquipmentHasValue)
				{
					long gid = importHelper.GetMappedGID(cimTerminal.ConductingEquipment.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
						report.Report.Append("\" - Failed to set reference to ConductingEquipment: rdfID \"").Append(cimTerminal.ConductingEquipment.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.TERMINAL_CONDEQ, gid));
				}
			}
		}

		public static void PopulateMeasurementProperties(Measurement cimMeasurement, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimMeasurement != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimMeasurement, rd);

				if (cimMeasurement.TerminalHasValue)
				{
					long gid = importHelper.GetMappedGID(cimMeasurement.Terminal.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimMeasurement.GetType().ToString()).Append(" rdfID = \"").Append(cimMeasurement.ID);
						report.Report.Append("\" - Failed to set reference to Terminal: rdfID \"").Append(cimMeasurement.Terminal.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.MEASUREMENT_TERMINAL, gid));
				}
				if (cimMeasurement.PowerSystemResourceHasValue)
				{
					long gid = importHelper.GetMappedGID(cimMeasurement.PowerSystemResource.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimMeasurement.GetType().ToString()).Append(" rdfID = \"").Append(cimMeasurement.ID);
						report.Report.Append("\" - Failed to set reference to PowerSystemResource: rdfID \"").Append(cimMeasurement.PowerSystemResource.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.MEASUREMENT_PSR, gid));
				}
			}
		}

		public static void PopulateConductingEquipmentProperties(ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimConductingEquipment != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);
			}
		}

		public static void PopulateEquipmentProperties(Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimEquipment != null) && (rd != null))
			{
				PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd, importHelper, report);

				if (cimEquipment.AggregateHasValue)
				{
					rd.AddProperty(new Property(ModelCode.EQUIPMENT_AGGR, cimEquipment.Aggregate));
				}
				if (cimEquipment.NormallyInServiceHasValue)
				{
					rd.AddProperty(new Property(ModelCode.EQUIPMENT_NORMINSERV, cimEquipment.NormallyInService));
				}
			}
		}

		public static void PopulateConnectivityNodeContainerProperties(ConnectivityNodeContainer cimConnectivityNodeContainer, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimConnectivityNodeContainer != null) && (rd != null))
			{
				PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimConnectivityNodeContainer, rd, importHelper, report);
			}
		}







		//public static void PopulateBaseVoltageProperties(FTN.BaseVoltage cimBaseVoltage, ResourceDescription rd)
		//{
		//	if ((cimBaseVoltage != null) && (rd != null))
		//	{
		//		PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimBaseVoltage, rd);

		//		if (cimBaseVoltage.NominalVoltageHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.BASEVOLTAGE_NOMINALVOLTAGE, cimBaseVoltage.NominalVoltage));
		//		}
		//	}
		//}

		//public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		//{
		//	if ((cimEquipment != null) && (rd != null))
		//	{
		//		PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd, importHelper, report);

		//		if (cimEquipment.PrivateHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.EQUIPMENT_ISPRIVATE, cimEquipment.Private));
		//		}
		//		if (cimEquipment.IsUndergroundHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.EQUIPMENT_ISUNDERGROUND, cimEquipment.IsUnderground));
		//		}
		//	}
		//}

		//public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		//{
		//	if ((cimConductingEquipment != null) && (rd != null))
		//	{
		//		PowerTransformerConverter.PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);

		//		if (cimConductingEquipment.PhasesHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.CONDEQ_PHASES, (short)GetDMSPhaseCode(cimConductingEquipment.Phases)));
		//		}
		//		if (cimConductingEquipment.RatedVoltageHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.CONDEQ_RATEDVOLTAGE, cimConductingEquipment.RatedVoltage));
		//		}
		//		if (cimConductingEquipment.BaseVoltageHasValue)
		//		{
		//			long gid = importHelper.GetMappedGID(cimConductingEquipment.BaseVoltage.ID);
		//			if (gid < 0)
		//			{
		//				report.Report.Append("WARNING: Convert ").Append(cimConductingEquipment.GetType().ToString()).Append(" rdfID = \"").Append(cimConductingEquipment.ID);
		//				report.Report.Append("\" - Failed to set reference to BaseVoltage: rdfID \"").Append(cimConductingEquipment.BaseVoltage.ID).AppendLine(" \" is not mapped to GID!");
		//			}
		//			rd.AddProperty(new Property(ModelCode.CONDEQ_BASVOLTAGE, gid));
		//		}
		//	}
		//}

		//public static void PopulatePowerTransformerProperties(FTN.PowerTransformer cimPowerTransformer, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		//{
		//	if ((cimPowerTransformer != null) && (rd != null))
		//	{
		//		PowerTransformerConverter.PopulateEquipmentProperties(cimPowerTransformer, rd, importHelper, report);

		//		if (cimPowerTransformer.FunctionHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.POWERTR_FUNC, (short)GetDMSTransformerFunctionKind(cimPowerTransformer.Function)));
		//		}
		//		if (cimPowerTransformer.AutotransformerHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.POWERTR_AUTO, cimPowerTransformer.Autotransformer));
		//		}
		//	}
		//}

		//public static void PopulateTransformerWindingProperties(FTN.TransformerWinding cimTransformerWinding, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		//{
		//	if ((cimTransformerWinding != null) && (rd != null))
		//	{
		//		PowerTransformerConverter.PopulateConductingEquipmentProperties(cimTransformerWinding, rd, importHelper, report);

		//		if (cimTransformerWinding.ConnectionTypeHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.POWERTRWINDING_CONNTYPE, (short)GetDMSWindingConnection(cimTransformerWinding.ConnectionType)));
		//		}
		//		if (cimTransformerWinding.GroundedHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.POWERTRWINDING_GROUNDED, cimTransformerWinding.Grounded));
		//		}
		//		if (cimTransformerWinding.RatedSHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.POWERTRWINDING_RATEDS, cimTransformerWinding.RatedS));
		//		}
		//		if (cimTransformerWinding.RatedUHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.POWERTRWINDING_RATEDU, cimTransformerWinding.RatedU));
		//		}
		//		if (cimTransformerWinding.WindingTypeHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.POWERTRWINDING_WINDTYPE, (short)GetDMSWindingType(cimTransformerWinding.WindingType)));
		//		}
		//		if (cimTransformerWinding.PhaseToGroundVoltageHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.POWERTRWINDING_PHASETOGRNDVOLTAGE, cimTransformerWinding.PhaseToGroundVoltage));
		//		}
		//		if (cimTransformerWinding.PhaseToPhaseVoltageHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.POWERTRWINDING_PHASETOPHASEVOLTAGE, cimTransformerWinding.PhaseToPhaseVoltage));
		//		}
		//		if (cimTransformerWinding.PowerTransformerHasValue)
		//		{
		//			long gid = importHelper.GetMappedGID(cimTransformerWinding.PowerTransformer.ID);
		//			if (gid < 0)
		//			{
		//				report.Report.Append("WARNING: Convert ").Append(cimTransformerWinding.GetType().ToString()).Append(" rdfID = \"").Append(cimTransformerWinding.ID);
		//				report.Report.Append("\" - Failed to set reference to PowerTransformer: rdfID \"").Append(cimTransformerWinding.PowerTransformer.ID).AppendLine(" \" is not mapped to GID!");
		//			}
		//			rd.AddProperty(new Property(ModelCode.POWERTRWINDING_POWERTRW, gid));
		//		}
		//	}
		//}

		//public static void PopulateWindingTestProperties(FTN.WindingTest cimWindingTest, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		//{
		//	if ((cimWindingTest != null) && (rd != null))
		//	{
		//		PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimWindingTest, rd);

		//		if (cimWindingTest.LeakageImpedanceHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.WINDINGTEST_LEAKIMPDN, cimWindingTest.LeakageImpedance));
		//		}
		//		if (cimWindingTest.LoadLossHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.WINDINGTEST_LOADLOSS, cimWindingTest.LoadLoss));
		//		}
		//		if (cimWindingTest.NoLoadLossHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.WINDINGTEST_NOLOADLOSS, cimWindingTest.NoLoadLoss));
		//		}
		//		if (cimWindingTest.PhaseShiftHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.WINDINGTEST_PHASESHIFT, cimWindingTest.PhaseShift));
		//		}
		//		if (cimWindingTest.LeakageImpedance0PercentHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.WINDINGTEST_LEAKIMPDN0PERCENT, cimWindingTest.LeakageImpedance0Percent));
		//		}
		//		if (cimWindingTest.LeakageImpedanceMaxPercentHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.WINDINGTEST_LEAKIMPDNMAXPERCENT, cimWindingTest.LeakageImpedanceMaxPercent));
		//		}
		//		if (cimWindingTest.LeakageImpedanceMinPercentHasValue)
		//		{
		//			rd.AddProperty(new Property(ModelCode.WINDINGTEST_LEAKIMPDNMINPERCENT, cimWindingTest.LeakageImpedanceMinPercent));
		//		}

		//		if (cimWindingTest.From_TransformerWindingHasValue)
		//		{
		//			long gid = importHelper.GetMappedGID(cimWindingTest.From_TransformerWinding.ID);
		//			if (gid < 0)
		//			{
		//				report.Report.Append("WARNING: Convert ").Append(cimWindingTest.GetType().ToString()).Append(" rdfID = \"").Append(cimWindingTest.ID);
		//				report.Report.Append("\" - Failed to set reference to TransformerWinding: rdfID \"").Append(cimWindingTest.From_TransformerWinding.ID).AppendLine(" \" is not mapped to GID!");
		//			}
		//			rd.AddProperty(new Property(ModelCode.WINDINGTEST_POWERTRWINDING, gid));
		//		}
		//	}
		//}
		#endregion Populate ResourceDescription

		#region Enums convert
		//public static PhaseCode GetDMSPhaseCode(FTN.PhaseCode phases)
		//{
		//	switch (phases)
		//	{
		//		case FTN.PhaseCode.A:
		//			return PhaseCode.A;
		//		case FTN.PhaseCode.AB:
		//			return PhaseCode.AB;
		//		case FTN.PhaseCode.ABC:
		//			return PhaseCode.ABC;
		//		case FTN.PhaseCode.ABCN:
		//			return PhaseCode.ABCN;
		//		case FTN.PhaseCode.ABN:
		//			return PhaseCode.ABN;
		//		case FTN.PhaseCode.AC:
		//			return PhaseCode.AC;
		//		case FTN.PhaseCode.ACN:
		//			return PhaseCode.ACN;
		//		case FTN.PhaseCode.AN:
		//			return PhaseCode.AN;
		//		case FTN.PhaseCode.B:
		//			return PhaseCode.B;
		//		case FTN.PhaseCode.BC:
		//			return PhaseCode.BC;
		//		case FTN.PhaseCode.BCN:
		//			return PhaseCode.BCN;
		//		case FTN.PhaseCode.BN:
		//			return PhaseCode.BN;
		//		case FTN.PhaseCode.C:
		//			return PhaseCode.C;
		//		case FTN.PhaseCode.CN:
		//			return PhaseCode.CN;
		//		case FTN.PhaseCode.N:
		//			return PhaseCode.N;
		//		case FTN.PhaseCode.s12N:
		//			return PhaseCode.ABN;
		//		case FTN.PhaseCode.s1N:
		//			return PhaseCode.AN;
		//		case FTN.PhaseCode.s2N:
		//			return PhaseCode.BN;
		//		default: return PhaseCode.Unknown;
		//	}
		//}

		//public static TransformerFunction GetDMSTransformerFunctionKind(FTN.TransformerFunctionKind transformerFunction)
		//{
		//	switch (transformerFunction)
		//	{
		//		case FTN.TransformerFunctionKind.voltageRegulator:
		//			return TransformerFunction.Voltreg;
		//		default:
		//			return TransformerFunction.Consumer;
		//	}
		//}

		//public static WindingType GetDMSWindingType(FTN.WindingType windingType)
		//{
		//	switch (windingType)
		//	{
		//		case FTN.WindingType.primary:
		//			return WindingType.Primary;
		//		case FTN.WindingType.secondary:
		//			return WindingType.Secondary;
		//		case FTN.WindingType.tertiary:
		//			return WindingType.Tertiary;
		//		default:
		//			return WindingType.None;
		//	}
		//}

		//public static WindingConnection GetDMSWindingConnection(FTN.WindingConnection windingConnection)
		//{
		//	switch (windingConnection)
		//	{
		//		case FTN.WindingConnection.D:
		//			return WindingConnection.D;
		//		case FTN.WindingConnection.I:
		//			return WindingConnection.I;
		//		case FTN.WindingConnection.Z:
		//			return WindingConnection.Z;
		//		case FTN.WindingConnection.Y:
		//			return WindingConnection.Y;
		//		default:
		//			return WindingConnection.Y;
		//	}
		//}
		#endregion Enums convert
	}
}
