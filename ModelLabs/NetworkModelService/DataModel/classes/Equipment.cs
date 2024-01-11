//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FTN {
    using System;
    using System.Collections.Generic;
    using FTN;
    using FTN.Common;


    /// The parts of a power system that are physical devices, electronic or mechanical.
    public class Equipment : PowerSystemResource 
    {

        private bool aggregate;

        private bool normallyInService;

        private long equipmentContainer = 0;


        public Equipment(long globalId) : base(globalId)
        {
        }


        public bool Aggregate
        {
            get
            {
                return aggregate;
            }

            set
            {
                aggregate = value;
            }
        }

        public bool NormallyInService
        {
            get
            {
                return normallyInService;
            }

            set
            {
                normallyInService = value;
            }
        }


        public long EquipmentContainer
        {
            get { return equipmentContainer; }
            set { equipmentContainer = value; }
        }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Equipment x = (Equipment)obj;
                return (x.aggregate == this.aggregate && x.normallyInService == this.normallyInService 
                        && x.equipmentContainer == this.equipmentContainer);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.EQUIPMENT_AGGR:
                case ModelCode.EQUIPMENT_NORMINSERV:
                case ModelCode.EQUIPMENT_EQCONTAINER:
                    return true;

                default:
                    return base.HasProperty(t);

            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.EQUIPMENT_AGGR:
                    property.SetValue(aggregate);
                    break;

                case ModelCode.EQUIPMENT_NORMINSERV:
                    property.SetValue(normallyInService);
                    break;

                case ModelCode.EQUIPMENT_EQCONTAINER:
                    property.SetValue(equipmentContainer);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.EQUIPMENT_AGGR:
                    aggregate = property.AsBool();
                    break;

                case ModelCode.EQUIPMENT_NORMINSERV:
                    normallyInService = property.AsBool();
                    break;

                case ModelCode.EQUIPMENT_EQCONTAINER:
                    equipmentContainer = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (equipmentContainer != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.EQUIPMENT_EQCONTAINER] = new List<long>();
                references[ModelCode.EQUIPMENT_EQCONTAINER].Add(equipmentContainer);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation
    }
}