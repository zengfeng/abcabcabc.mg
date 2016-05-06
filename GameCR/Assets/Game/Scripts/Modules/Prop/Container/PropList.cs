using System;
using System.Collections.Generic;

namespace Games.Module.Props
{
    public class PropList : IPropContainer
    {
        public event ChangeHandler Change;

        private Prop[] _props;

        public Prop[] props
        {
            get {
                if (_invalidateProps)
                {
                    if (_invalidateList == null)
                        _props = null;
                    else
                        _props = _list.ToArray();

                    _invalidateProps = false;
                }
              
                if (_props == null)
                    _props = new Prop[0];

                return _props;
            }
        }

        public void SetProps(Prop[] props)
        {
            SetProps(props, true);
        }

        public void SetProps(Prop[] props, bool bNotify)
        {
            _props = props;

            _invalidateList = true;

            if (bNotify && Change != null)
                Change(this);
        }

        protected bool _invalidateProps = false;

        public PropList()
        {
        }

		
		
		public void InvalidateProps()
		{
			_invalidateProps = true;
			
			if (Change != null)
				Change(this);
		}

        private List<Prop> _list;
        private bool _invalidateList = false;

        public void Add(Prop propValue)
        {
            Add(propValue, true);
        }

        public void Add(Prop propValue, bool bNotify)
        {
            if (_invalidateList)            
                _list = new List<Prop>(_props);

            _list.Add(propValue);

            _invalidateProps = true;

            if (bNotify && Change != null)
                Change(this);
        }

        public void Remove(Prop propValue)
        {
            Remove(propValue, true);
        }

        public void Remove(Prop propValue, bool bNotify)
        {
            if (_invalidateList)            
                _list = new List<Prop>(_props);
            
            _list.Remove(propValue);
            
            _invalidateProps = true;
            
            if (bNotify && Change != null)
                Change(this);
        }
    }
}

