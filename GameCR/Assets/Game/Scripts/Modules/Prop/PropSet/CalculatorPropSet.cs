using System;

namespace Games.Module.Props
{
    public class CalculatorPropSet : PropSet
    {
        private bool _invalidateCalculation = false;

        public void InvalidateCalculation()
        {
            _invalidateCalculation = true;
        }
        
        private IPropSetCalculator _calculator;

        public CalculatorPropSet(IPropSetCalculator calculator) 
        {
            if (calculator == null)
                throw new ArgumentNullException();

            _calculator = calculator;
        }

        override protected void ValidateFullProps()
        {
            if (_invalidateCalculation || _invalidateProps)
            {
                _calculator.Calculate(this);
                _invalidateCalculation = false;
            }

            base.ValidateFullProps();
        }


    }
}

