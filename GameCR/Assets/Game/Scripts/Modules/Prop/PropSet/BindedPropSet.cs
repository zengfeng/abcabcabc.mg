using System;

namespace Games.Module.Props
{
    public class BindedPropSet : CalculatorPropSet
    {
        private IPropContainer _propSource;
        private bool _invalidatePropSource = true;

        public BindedPropSet(IPropContainer propSource, IPropSetCalculator calculator) : base(calculator)
        {
            if (propSource == null)
                throw new ArgumentNullException();

            _propSource = propSource;
            _propSource.Change += OnPropSourceChange;
        }

        private void OnPropSourceChange(IPropContainer propSource)
        {
            _invalidatePropSource = true;
        }

        override protected void ValidateFullProps()
        {
            ValidatePropSource();

            base.ValidateFullProps();
        }

        private void ValidatePropSource()
        {
            if (_invalidatePropSource)
            {
                _rawValues.PropClear();
                _rawValues.PropAdd(_propSource.props);

                _invalidatePropSource = false;
            }
        }
    }
}

