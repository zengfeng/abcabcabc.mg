using System;
using System.Collections.Generic;

namespace Games.Module.Props
{
    public class PropSet
    {
		protected float[] _rawValues = new float[PropId.MAX];

        public float[] rawValues
        {
            get {return _rawValues;}
            set {
                if (_rawValues.Length != _fullProps.Length)
                    throw(new Exception("Size miss match"));

                _rawValues = value;

                _invalidateProps = true;
            }
        }

        public float[] fullValues
        {
            get {

                ValidateFullProps();

                return _rawValues;
            }
        }

        private Prop[] _fullProps;

        public Prop[] fullProps
        {
            get {

                ValidateFullProps();
                
                return _fullProps; 
            }
        }
       
        protected bool _invalidateProps = false;

        public void InvalidateProps()
        {
            _invalidateProps = true;
        }

        public PropSet()
        {
            _fullProps = new Prop[PropId.MAX];
            
            for (int id = 0; id < PropId.MAX; id++)
            {
                _fullProps[id] = Prop.CreateInstance(id, 0f);
            }
        }

        public void Plus(Prop prop)
        {
            _rawValues[prop.id] += prop.value;
            _invalidateProps = true;
        }
        
        public void Minus(Prop prop)
        {
            _rawValues[prop.id] -= prop.value;
            _invalidateProps = true;
        }
        
        public void Plus(int id, float value)
        {
            _rawValues[id] += value;
            _invalidateProps = true;
        }
        
        public void Minus(int id, float value)
        {
            _rawValues[id] -= value;
            _invalidateProps = true;
        }
        
        public void Plus(Prop[] props)
        {
            foreach (Prop prop in props)
            {
                _rawValues[prop.id] += prop.value;
            }
            _invalidateProps = true;
        }
        
        public void Minus(Prop[] props)
        {
            foreach (Prop prop in props)
            {
                _rawValues[prop.id] -= prop.value;
            }
            _invalidateProps = true;
        }
        
        public void Clear()
        {
            for (int i = 0; i < _rawValues.Length; i++)
            {
                _rawValues[i] = 0;
            }           
            _invalidateProps = true;
        }
  
        public PropSet Clone()
        {
            PropSet clone = new PropSet();

            clone.rawValues = _rawValues;

            return clone;
        }

        public Prop[] CreateSubset(int[] ids)
        {
            ValidateFullProps();

            Prop[] subset = new Prop[ids.Length];
            
            for (int i = 0;  i < ids.Length; i++)
            {
                int id = ids[i];
                Prop prop = _fullProps[id].Clone();
                subset[i] = prop;
            }
            
            return subset;
        }

        public Prop[] CreateFilterZero()
        {
            ValidateFullProps();

            return _rawValues.FilterZero();
        }

        virtual protected void ValidateFullProps()
        {
            if (_invalidateProps)
            {
                for (int i = 0; i < _fullProps.Length; i++)
                {
                    _fullProps[i].value = _rawValues[i];
                }
                _invalidateProps = true;
            }
        }
    }
}

