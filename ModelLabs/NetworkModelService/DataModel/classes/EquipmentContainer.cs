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


    /// A modeling construct to provide a root class for containing equipment.
    public class EquipmentContainer : ConnectivityNodeContainer 
    {
        private List<long> equipments = new List<long>();

        public EquipmentContainer(long globalId) : base(globalId)
        {
        }

        public List<long> Equipments
        {
            get { return equipments; }
            set { equipments = value; }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                EquipmentContainer x = (EquipmentContainer)obj;
                return (CompareHelper.CompareLists(x.equipments, this.equipments));
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
                case ModelCode.EQCONTAINER_EQUIPMENTS:
                    return true;

                default:
                    return base.HasProperty(t);

            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.EQCONTAINER_EQUIPMENTS:
                    property.SetValue(equipments);
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
                // Ne ide za listu ref

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return equipments.Count != 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (equipments != null && equipments.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.EQCONTAINER_EQUIPMENTS] = equipments.GetRange(0, equipments.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.EQUIPMENT_EQCONTAINER:
                    equipments.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.EQUIPMENT_EQCONTAINER:

                    if (equipments.Contains(globalId))
                    {
                        equipments.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }

        #endregion IReference implementation
    }
}
