using System;
using System.Collections.Generic;

namespace Games.Module.Props
{
    public class PropTree : IPropContainer
    {
        public event ChangeHandler Change;

        private List<IPropContainer> children = new List<IPropContainer>();

		private Prop[] _props;

        public Prop[] props
        {
            get {

                ValidateProps();
				if(_props == null)
				{
					_props = new Prop[]{};
				}
                return _props;
            }
        }
		
		public Prop GetProp(int propId)
		{
			ValidateProps();
			return _propSet.fullProps[propId];
		}

		public float GetPropValue(int propId)
		{
			ValidateProps();
			return _propSet.fullValues[propId];
		}

		public Prop[] GetProps(int[] propIds, bool clearZero, bool sort)
		{
			if(sort)
			{
				propIds.SortProp();
			}

			Prop[] props = new Prop[propIds.Length];
			for(int i = 0; i < propIds.Length; i ++)
			{
				props[i] = GetProp(propIds[i]);
			}

			if(clearZero)
			{
				props = props.FilterZero();
			}
			return props;
		}
		
		
		public Prop[] GetProps(int[] propIds, bool clearZero)
		{
			return GetProps(propIds, clearZero, true);
		}
		
		public Prop[] GetProps(int[] propIds)
		{
			return GetProps(propIds, true, true);
		}
		
		public Prop[] GetProps()
		{
			return props.SortProp();
		}



        private bool _invalidateProps = false;
		
		
		public void InvalidateProps()
		{
			_invalidateProps = true;
			
			if (Change != null)
				Change(this);
		}

        private void ValidateProps()
        {
            if (_invalidateProps)
            {
                _propSet.Clear();

                foreach (IPropContainer child in children)
                {
                    _propSet.Plus(child.props);
                }

                _props = _propSet.CreateFilterZero();

                _invalidateProps = false;
            }
        }

        private PropSet _propSet;
 
        public PropSet propSet
        {
            get {

                ValidateProps();
                
                return _propSet;                
            }
        }

        public PropTree()
        {
            _propSet = new PropSet();
        }

        public PropTree(PropSet propSet)
        {
            _propSet = propSet;
        }

        public void Add(IPropContainer child)
        {
            Add(child, true);
        }

        public void Add(IPropContainer child, bool bNotify)
        {
            // TODO: Remove this check for performance?
            if (!children.Contains(child))
            {
                child.Change += OnChildChange;
                children.Add(child);

                _invalidateProps = true;

                if (bNotify && Change != null)
                    Change(this);
            }
        }

        public void Remove(IPropContainer child)
        {
            Remove(child, true);
        }

        public void Remove(IPropContainer child, bool bNotify)
        {
            if (children.Contains(child))
            {
                child.Change -= OnChildChange;
                children.Remove(child);

                _invalidateProps = true;

                if (bNotify && Change != null)
                    Change(this);
            }
        }

        private void OnChildChange(IPropContainer child)
        {
            if (Change != null)
            {
                _invalidateProps = true;

                Change(this);
            }
        }

    }
}

