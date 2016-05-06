using System;
namespace Games.Module.Props
{
    public delegate void ChangeHandler (IPropContainer propContainer);

    public interface IPropContainer
    {
        event ChangeHandler Change;
        Prop[] props { get; }
		void InvalidateProps();
    }
}

