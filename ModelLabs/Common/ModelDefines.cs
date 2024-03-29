using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	// Enumeracija za sve konkretne klase u nasem profilu
	public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),

		MEASUREMENT							= 0x0001,
		TERMINAL							= 0x0002,
		CONNODE								= 0x0003,
		EQCONTAINER							= 0x0004,
		SWITCH								= 0x0005,

		//BASEVOLTAGE = 0x0001,
		//LOCATION = 0x0002,
		//POWERTR = 0x0003,
		//POWERTRWINDING = 0x0004,
		//WINDINGTEST = 0x0005,
	}

	// Nasledjivanje (8), DMSType (4), redni broj atributa (2), tip atributa (2)
    [Flags]
	public enum ModelCode : long
	{
		IDOBJ									= 0x1000000000000000,
		IDOBJ_GID								= 0x1000000000000104,
		//IDOBJ_DESCRIPTION						= 0x1000000000000207,
		//IDOBJ_MRID							= 0x1000000000000307,
		//IDOBJ_NAME							= 0x1000000000000407,	

		PSR										= 0x1100000000000000,
		//PSR_CUSTOMTYPE						= 0x1100000000000107,
		//PSR_LOCATION							= 0x1100000000000209,

		PSR_MEASUREMENTS						= 0x1100000000000119,

		MEASUREMENT								= 0x1200000000010000,
		MEASUREMENT_PSR							= 0x1200000000010109,
		MEASUREMENT_TERMINAL					= 0x1200000000010209,

		TERMINAL								= 0x1300000000020000,
		TERMINAL_MEASUREMENTS					= 0x1300000000020119,
		TERMINAL_CONNODE						= 0x1300000000020209,
		TERMINAL_CONDEQ							= 0x1300000000020309,

		CONNODE									= 0x1400000000030000,
		CONNODE_CONNODECONTAINER				= 0x1400000000030109,
		CONNODE_TERMINALS						= 0x1400000000030219,

        //BASEVOLTAGE = 0x1200000000010000,
        //BASEVOLTAGE_NOMINALVOLTAGE = 0x1200000000010105,
        //BASEVOLTAGE_CONDEQS = 0x1200000000010219,

        //LOCATION = 0x1300000000020000,
        //LOCATION_CORPORATECODE = 0x1300000000020107,
        //LOCATION_CATEGORY = 0x1300000000020207,
        //LOCATION_PSRS = 0x1300000000020319,

        //WINDINGTEST = 0x1400000000050000,
        //WINDINGTEST_LEAKIMPDN = 0x1400000000050105,
        //WINDINGTEST_LOADLOSS = 0x1400000000050205,
        //WINDINGTEST_NOLOADLOSS = 0x1400000000050305,
        //WINDINGTEST_PHASESHIFT = 0x1400000000050405,
        //WINDINGTEST_LEAKIMPDN0PERCENT = 0x1400000000050505,
        //WINDINGTEST_LEAKIMPDNMINPERCENT = 0x1400000000050605,
        //WINDINGTEST_LEAKIMPDNMAXPERCENT = 0x1400000000050705,
        //WINDINGTEST_POWERTRWINDING = 0x1400000000050809,

        EQUIPMENT								= 0x1110000000000000,
		//EQUIPMENT_ISUNDERGROUND				= 0x1110000000000101,
		//EQUIPMENT_ISPRIVATE					= 0x1110000000000201,	

		EQUIPMENT_AGGR							= 0x1110000000000101,
		EQUIPMENT_NORMINSERV					= 0x1110000000000201,
		EQUIPMENT_EQCONTAINER					= 0x1110000000000309,

		CONNODECONTAINER						= 0x1120000000000000,
		CONNODECONTAINER_CONNODES				= 0x1120000000000119,

		CONDEQ									= 0x1111000000000000,
        //CONDEQ_PHASES = 0x111100000000010a,
        //CONDEQ_RATEDVOLTAGE = 0x1111000000000205,
        //CONDEQ_BASVOLTAGE = 0x1111000000000309,

        CONDEQ_TERMINALS						= 0x1111000000000119,

		EQCONTAINER								= 0x1121000000040000,
		EQCONTAINER_EQUIPMENTS					= 0x1121000000040119,

		SWITCH									= 0x1111100000050000,
		SWITCH_NORMOPEN							= 0x1111100000050101,
		SWITCH_RETAINED							= 0x1111100000050201,
		SWITCH_SWONCOUNT						= 0x1111100000050303,
		SWITCH_SWONDATE							= 0x1111100000050408,

        //POWERTR = 0x1112000000030000,
        //POWERTR_FUNC = 0x111200000003010a,
        //POWERTR_AUTO = 0x1112000000030201,
        //POWERTR_WINDINGS = 0x1112000000030319,

        //POWERTRWINDING = 0x1111100000040000,
        //POWERTRWINDING_CONNTYPE = 0x111110000004010a,
        //POWERTRWINDING_GROUNDED = 0x1111100000040201,
        //POWERTRWINDING_RATEDS = 0x1111100000040305,
        //POWERTRWINDING_RATEDU = 0x1111100000040405,
        //POWERTRWINDING_WINDTYPE = 0x111110000004050a,
        //POWERTRWINDING_PHASETOGRNDVOLTAGE = 0x1111100000040605,
        //POWERTRWINDING_PHASETOPHASEVOLTAGE = 0x1111100000040705,
        //POWERTRWINDING_POWERTRW = 0x1111100000040809,
        //POWERTRWINDING_TESTS = 0x1111100000040919,
    }

	[Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


