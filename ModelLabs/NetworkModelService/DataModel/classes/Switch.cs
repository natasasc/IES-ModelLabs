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
    using FTN;
    using FTN.Common;


    /// A generic device designed to close, or open, or both, one or more electric circuits.
    public class Switch : ConductingEquipment 
    {
        private bool normalOpen;

        // ratedCurrent je izbacen iz profila

        private bool retained;

        private int switchOnCount;

        private DateTime switchOnDate = new DateTime();

        public Switch(long globalId) : base(globalId)
        {
        }


        public bool NormalOpen
        {
            get
            {
                return normalOpen;
            }

            set
            {
                normalOpen = value;
            }
        }

        public bool Retained
        {
            get
            {
                return retained;
            }

            set
            {
                retained = value;
            }
        }

        public int SwitchOnCount
        {
            get
            {
                return switchOnCount;
            }

            set
            {
                switchOnCount = value;
            }
        }

        public DateTime SwitchOnDate
        {
            get
            {
                return switchOnDate;
            }

            set
            {
                switchOnDate = value;
            }
        }


        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Switch x = (Switch)obj;
                return (x.normalOpen == this.normalOpen && x.retained == this.retained 
                        && x.switchOnCount == this.switchOnCount && x.switchOnDate == this.switchOnDate);
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
                case ModelCode.SWITCH_NORMOPEN:
                case ModelCode.SWITCH_RETAINED:
                case ModelCode.SWITCH_SWONCOUNT:
                case ModelCode.SWITCH_SWONDATE:
                    return true;

                default:
                    return base.HasProperty(t);

            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.SWITCH_NORMOPEN:
                    property.SetValue(normalOpen);
                    break;

                case ModelCode.SWITCH_RETAINED:
                    property.SetValue(retained);
                    break;

                case ModelCode.SWITCH_SWONCOUNT:
                    property.SetValue(switchOnCount);
                    break;

                case ModelCode.SWITCH_SWONDATE:
                    property.SetValue(switchOnDate);
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
                case ModelCode.SWITCH_NORMOPEN:
                    normalOpen = property.AsBool();
                    break;

                case ModelCode.SWITCH_RETAINED:
                    retained = property.AsBool();
                    break;

                case ModelCode.SWITCH_SWONCOUNT:
                    switchOnCount = property.AsInt();
                    break;

                case ModelCode.SWITCH_SWONDATE:
                    switchOnDate = property.AsDateTime();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

    }
}
